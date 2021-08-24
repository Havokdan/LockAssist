﻿using KeePass;
using KeePass.Forms;
using KeePass.Plugins;
using KeePass.UI;
using KeePassLib;
using KeePassLib.Collections;
using KeePassLib.Keys;
using KeePassLib.Security;
using KeePassLib.Serialization;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using PluginTranslation;
using PluginTools;

namespace LockAssist
{
	/* 
	* QuickUnlock part is inspired by KeePass2Android's QuickUnlock and https://github.com/JanisEst/KeePassQuickUnlock
	* Additional features added:
	*   - DB specific settings
	*   - Restore previously used masterkey (allow QuickUnlock multiple times in a row, allow printing of emergency sheets, ...)
	*   - Show explicit error message if wrong QuickUnlock key is entered
	*   - Automate creation of QuickUnlock entry
	*   - Additional smaller adjustments
	*/
	internal partial class QuickUnlock
	{
		private  QuickUnlockKeyProv m_kp = null;

		public QuickUnlock()
        {
			Init();
        }
		private void Init()
		{
			m_kp = new QuickUnlockKeyProv();
			Program.KeyProviderPool.Add(m_kp);
			Program.MainForm.FileClosingPre += OnFileClosePre_QU;
			Program.MainForm.FileOpened += OnFileOpened_QU;
			GlobalWindowManager.WindowAdded += OnWindowAdded_QU;
			PluginDebug.AddInfo("Quick Unlock: Initialized", 0);
		}

		#region Eventhandler for opening and closing a DB
		private void OnFileOpened_QU(object sender, FileOpenedEventArgs e)
		{
			var MyOptions = LockAssistConfig.GetOptions(e.Database);
			if (LockAssistConfig.FirstTime &&
				(!MyOptions.QU_UsePassword && (GetQuickUnlockEntry(e.Database) == null)
				|| (MyOptions.QU_UsePassword && !Program.Config.Security.MasterPassword.RememberWhileOpen)))
			{
				Tools.ShowInfo(PluginTranslate.FirstTimeInfo);
				Tools.ShowOptions();
				LockAssistConfig.FirstTime = false;
			}
			if (!MyOptions.QU_Active) return;
			//Restore previously stored information about the masterkey
			QuickUnlockOldKeyInfo quOldKey = QuickUnlockKeyProv.GetOldKey(e.Database);
			if (quOldKey == null)
			{
				PluginDebug.AddInfo("Quick Unlock: DB opened, no encrypted master key available to restore");
				return;
			}
			PluginDebug.AddInfo("Quick Unlock: DB opened, restore encrypted master key");
			KcpCustomKey ck = (KcpCustomKey)e.Database.MasterKey.GetUserKey(typeof(KcpCustomKey));
			if ((ck == null) || (ck.Name != QuickUnlockKeyProv.KeyProviderName))
			{
				//Quick Unlock was not used
				return;
			}
			e.Database.MasterKey.RemoveUserKey(ck);
			if (quOldKey.pwHash != null)
			{
				KcpPassword p;
				p = QuickUnlockKeyProv.DeserializePassword(quOldKey.pwHash, Program.Config.Security.MasterPassword.RememberWhileOpen);
				if (p.Password == null && quOldKey.HasPassword) p = new KcpPassword(new byte[0] { }, Program.Config.Security.MasterPassword.RememberWhileOpen);
				e.Database.MasterKey.AddUserKey(p);
			}
			if (!string.IsNullOrEmpty(quOldKey.keyFile)) e.Database.MasterKey.AddUserKey(new KcpKeyFile(quOldKey.keyFile));
			if (quOldKey.account) e.Database.MasterKey.AddUserKey(new KcpUserAccount());
			Program.Config.Defaults.SetKeySources(e.Database.IOConnectionInfo, e.Database.MasterKey);
		}

		private void OnFileClosePre_QU(object sender, FileClosingEventArgs e)
		{
			//Do quick unlock only in case of locking
			//Do NOT do quick unlock in case of closing the database
			PluginDebug.AddInfo("Quick Unlock: File closing = " + e.Flags.ToString());
			if (e.Flags != FileEventFlags.Locking)
			{
				QuickUnlockKeyProv.RemoveDb(e.Database);
				return;
			}
			var MyOptions = LockAssistConfig.GetOptions(e.Database);
			if (!MyOptions.QU_Active) return;
			ProtectedString QuickUnlockKey = null;
			if (Program.Config.Security.MasterPassword.RememberWhileOpen && MyOptions.QU_UsePassword)
				QuickUnlockKey = GetQuickUnlockKeyFromMasterKey(e.Database);
			if (QuickUnlockKey == null)
				QuickUnlockKey = GetQuickUnlockKeyFromEntry(e.Database);
			QuickUnlockKey = TrimQuickUnlockKey(QuickUnlockKey, MyOptions);
			if (QuickUnlockKey == null)
			{
				PluginDebug.AddError("Quick Unlock: Can't derive key, Quick Unlock not possible");
				return;
			}
			QuickUnlockKeyProv.AddDb(e.Database, QuickUnlockKey, Program.Config.Security.MasterPassword.RememberWhileOpen && MyOptions.QU_UsePassword);
			PluginDebug.AddInfo("Quick Unlock: key added");
		}
		#endregion

		#region Unlock / KeyPromptForm
		private void OnWindowAdded_QU(object sender, GwmWindowEventArgs e)
		{
			if (!(e.Form is KeyPromptForm) && !(e.Form is KeyCreationForm)) return;
			PluginDebug.AddInfo(e.Form.GetType().Name + " added", 0);
			e.Form.Shown += (o, x) => OnKeyFormShown_QU(o, false);
		}

		public static void OnKeyFormShown_QU(object sender, bool resetFile)
		{
			Form keyform = (sender as Form);
			try
			{
				ComboBox cmbKeyFile = (ComboBox)Tools.GetControl("m_cmbKeyFile", keyform);
				if (cmbKeyFile == null)
				{
					PluginDebug.AddError("Cant't find m_cmbKeyFile'", 0, "Form: " + keyform.GetType().Name);
					return;
				}
				int index = cmbKeyFile.Items.IndexOf(QuickUnlockKeyProv.KeyProviderName);
				//Quick Unlock cannot be used to create a key ==> Remove it from list of key providers
				if (keyform is KeyCreationForm)
				{
					PluginDebug.AddInfo("Removing Quick Unlock from key providers", 0);
					if (index == -1) return;
					cmbKeyFile.Items.RemoveAt(index);
					List<string> keyfiles = (List<string>)Tools.GetField("m_lKeyFileNames", keyform);
					if (keyfiles != null) keyfiles.Remove(QuickUnlockKeyProv.KeyProviderName);
					return;
				}

				//Key prompt form is shown
				IOConnectionInfo dbIOInfo = (IOConnectionInfo)Tools.GetField("m_ioInfo", keyform);
				//If Quick Unlock is possible show the Quick Unlock form
				if ((index != -1) && (dbIOInfo != null) && QuickUnlockKeyProv.HasDB(dbIOInfo.Path))
				{
					cmbKeyFile.SelectedIndex = index;
					CheckBox cbPassword = (CheckBox)Tools.GetControl("m_cbPassword", keyform);
					CheckBox cbAccount = (CheckBox)Tools.GetControl("m_cbUserAccount", keyform);
					Button bOK = (Button)Tools.GetControl("m_btnOK", keyform);
					if ((bOK != null) && (cbPassword != null) && (cbAccount != null))
					{
						UIUtil.SetChecked(cbPassword, false);
						UIUtil.SetChecked(cbAccount, false);
						bOK.PerformClick();
					}
					else
					{
						PluginDebug.AddError("Quick Unlock form cannot be shown", 0, 
							"Form: "+keyform.GetType().Name,
							"Password checkbox: " + (cbPassword == null ? "null" : cbPassword.Name + " / " + cbPassword.GetType().Name),
							"Account checkbox: " + (cbAccount == null ? "null" : cbAccount.Name + " / " + cbAccount.GetType().Name),
							"OK button: " + (bOK == null ? "null" : bOK.Name + " / " + bOK.GetType().Name)
							);
					}
					return;
				}

				//Quick Unlock is not possible => Remove it from list of key providers
				if ((resetFile || ((dbIOInfo != null) && !QuickUnlockKeyProv.HasDB(dbIOInfo.Path))) && (index != -1))
				{
					cmbKeyFile.Items.RemoveAt(index);
					List<string> keyfiles = (List<string>)Tools.GetField("m_lKeyFileNames", keyform);
					if (keyfiles != null) keyfiles.Remove(QuickUnlockKeyProv.KeyProviderName);
					if (resetFile) cmbKeyFile.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				PluginDebug.AddError(ex.Message);
			}
		}
		#endregion

		#region QuickUnlockKey handling
		private ProtectedString GetQuickUnlockKeyFromMasterKey(PwDatabase db)
		{
			/*
             * Try to create QuickUnlockKey based on password
             * 
             * If no password is contained in MasterKey there is
             * EITHER no password at all
             * OR the database was unlocked with Quick Unlock
             * In these case ask our key provider for the original password
             */
			ProtectedString QuickUnlockKey = null;
			try
			{
				KcpPassword pw = (KcpPassword)db.MasterKey.GetUserKey(typeof(KcpPassword));
				if (pw != null)
					QuickUnlockKey = pw.Password;
			}
			catch (Exception ex) { PluginDebug.AddError("Quick Unlock: " + ex.Message); }
			if (QuickUnlockKey != null) //Do NOT check QuickUnlockKey.Length, an empty string is treated like no password otherwise
			{
				PluginDebug.AddInfo("Quick Unlock: Quick Unlock key found", 0);
				return QuickUnlockKey;
			}
			PluginDebug.AddError("Quick Unlock: Quick Unlock key NOT found", 0,
				"MasterPassword.RememberWhileOpen: " + Program.Config.Security.MasterPassword.RememberWhileOpen.ToString());
			return null;
		}

		private ProtectedString GetQuickUnlockKeyFromEntry(PwDatabase db)
		{
			PwEntry QuickUnlockEntry = GetQuickUnlockEntry(db);
			if (QuickUnlockEntry == null)
			{
				PluginDebug.AddInfo("Quick Unlock: Quick Unlock entry NOT found", 0);
				return null;
			}
			PluginDebug.AddInfo("Quick Unlock: Quick Unlock entry found", 0);
			return QuickUnlockEntry.Strings.GetSafe(PwDefs.PasswordField);
		}

		public static PwEntry GetQuickUnlockEntry(PwDatabase db)
		{
			if ((db == null) || !db.IsOpen) return null;
			SearchParameters sp = new SearchParameters();
			sp.SearchInTitles = true;
			sp.ExcludeExpired = true;
			sp.SearchString = QuickUnlockKeyProv.KeyProviderName;
			PwObjectList<PwEntry> entries = new PwObjectList<PwEntry>();
			db.RootGroup.SearchEntries(sp, entries);
			if ((entries == null) || (entries.UCount == 0)) return null;
			return entries.GetAt(0);
		}

		private ProtectedString TrimQuickUnlockKey(ProtectedString QuickUnlockKey, LockAssistConfig lac)
		{
			if ((QuickUnlockKey == null) || (QuickUnlockKey.Length <= lac.QU_PINLength)) return QuickUnlockKey;
			int startIndex = 0;
			if (!lac.QU_UsePasswordFromEnd) startIndex = lac.QU_PINLength;
			QuickUnlockKey = QuickUnlockKey.Remove(startIndex, QuickUnlockKey.Length - lac.QU_PINLength);
			return QuickUnlockKey;
		}
		#endregion

		internal void Clear()
		{
			Program.KeyProviderPool.Remove(m_kp);
			m_kp = null;
			QuickUnlockKeyProv.Clear();
			Program.MainForm.FileClosingPre -= OnFileClosePre_QU;
			Program.MainForm.FileOpened -= OnFileOpened_QU;
			GlobalWindowManager.WindowAdded -= OnWindowAdded_QU;
			PluginDebug.AddInfo("Quick Unlock: Terminated", 0);
		}
	}
}

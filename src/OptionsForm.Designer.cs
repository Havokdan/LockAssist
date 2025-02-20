﻿namespace LockAssist
{
	partial class OptionsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tcLockAssistOptions = new System.Windows.Forms.TabControl();
            this.tabQuickUnlock = new System.Windows.Forms.TabPage();
            this.tbModeExplain = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbPINDBSpecific = new System.Windows.Forms.CheckBox();
            this.cbQUValidity = new System.Windows.Forms.ComboBox();
            this.nQUValidity = new System.Windows.Forms.NumericUpDown();
            this.cbQUValidityActive = new System.Windows.Forms.CheckBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.lQUPINLength = new System.Windows.Forms.Label();
            this.lQUMode = new System.Windows.Forms.Label();
            this.rbPINEnd = new System.Windows.Forms.RadioButton();
            this.rbPINFront = new System.Windows.Forms.RadioButton();
            this.tbPINLength = new System.Windows.Forms.TextBox();
            this.cbPINMode = new System.Windows.Forms.ComboBox();
            this.tabLockWorkspace = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbLockWorkspace = new System.Windows.Forms.CheckBox();
            this.tbLockWorkspace = new System.Windows.Forms.TextBox();
            this.tcLockAssistOptions.SuspendLayout();
            this.tabQuickUnlock.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nQUValidity)).BeginInit();
            this.tabLockWorkspace.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcLockAssistOptions
            // 
            this.tcLockAssistOptions.Controls.Add(this.tabQuickUnlock);
            this.tcLockAssistOptions.Controls.Add(this.tabLockWorkspace);
            this.tcLockAssistOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLockAssistOptions.Location = new System.Drawing.Point(0, 0);
            this.tcLockAssistOptions.Margin = new System.Windows.Forms.Padding(5);
            this.tcLockAssistOptions.Name = "tcLockAssistOptions";
            this.tcLockAssistOptions.SelectedIndex = 0;
            this.tcLockAssistOptions.Size = new System.Drawing.Size(853, 697);
            this.tcLockAssistOptions.TabIndex = 6;
            // 
            // tabQuickUnlock
            // 
            this.tabQuickUnlock.BackColor = System.Drawing.Color.Transparent;
            this.tabQuickUnlock.Controls.Add(this.tbModeExplain);
            this.tabQuickUnlock.Controls.Add(this.panel2);
            this.tabQuickUnlock.Location = new System.Drawing.Point(10, 48);
            this.tabQuickUnlock.Margin = new System.Windows.Forms.Padding(5);
            this.tabQuickUnlock.Name = "tabQuickUnlock";
            this.tabQuickUnlock.Padding = new System.Windows.Forms.Padding(5);
            this.tabQuickUnlock.Size = new System.Drawing.Size(833, 639);
            this.tabQuickUnlock.TabIndex = 0;
            this.tabQuickUnlock.Text = "Quick Unlock settings";
            this.tabQuickUnlock.UseVisualStyleBackColor = true;
            // 
            // tbModeExplain
            // 
            this.tbModeExplain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbModeExplain.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbModeExplain.Location = new System.Drawing.Point(5, 407);
            this.tbModeExplain.Margin = new System.Windows.Forms.Padding(5);
            this.tbModeExplain.Multiline = true;
            this.tbModeExplain.Name = "tbModeExplain";
            this.tbModeExplain.ReadOnly = true;
            this.tbModeExplain.Size = new System.Drawing.Size(823, 178);
            this.tbModeExplain.TabIndex = 34;
            this.tbModeExplain.TabStop = false;
            this.tbModeExplain.Text = "Requirements for mode \'Database password\'\r\n - Database masterkey contains a passw" +
    "ord\r\n - Option \'Remember master password\' is active\r\n\r\nQuick Unlock Entry will b" +
    "e used as fallback";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbPINDBSpecific);
            this.panel2.Controls.Add(this.cbQUValidity);
            this.panel2.Controls.Add(this.nQUValidity);
            this.panel2.Controls.Add(this.cbQUValidityActive);
            this.panel2.Controls.Add(this.cbActive);
            this.panel2.Controls.Add(this.lQUPINLength);
            this.panel2.Controls.Add(this.lQUMode);
            this.panel2.Controls.Add(this.rbPINEnd);
            this.panel2.Controls.Add(this.rbPINFront);
            this.panel2.Controls.Add(this.tbPINLength);
            this.panel2.Controls.Add(this.cbPINMode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 402);
            this.panel2.TabIndex = 35;
            // 
            // cbPINDBSpecific
            // 
            this.cbPINDBSpecific.AutoSize = true;
            this.cbPINDBSpecific.Location = new System.Drawing.Point(14, 338);
            this.cbPINDBSpecific.Margin = new System.Windows.Forms.Padding(5);
            this.cbPINDBSpecific.Name = "cbPINDBSpecific";
            this.cbPINDBSpecific.Size = new System.Drawing.Size(354, 36);
            this.cbPINDBSpecific.TabIndex = 46;
            this.cbPINDBSpecific.Text = "Settings are DB specific";
            this.cbPINDBSpecific.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbPINDBSpecific.UseVisualStyleBackColor = true;
            // 
            // cbQUValidity
            // 
            this.cbQUValidity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbQUValidity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQUValidity.FormattingEnabled = true;
            this.cbQUValidity.Location = new System.Drawing.Point(357, 278);
            this.cbQUValidity.Name = "cbQUValidity";
            this.cbQUValidity.Size = new System.Drawing.Size(456, 39);
            this.cbQUValidity.TabIndex = 45;
            // 
            // nQUValidity
            // 
            this.nQUValidity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nQUValidity.DecimalPlaces = 2;
            this.nQUValidity.Location = new System.Drawing.Point(189, 276);
            this.nQUValidity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nQUValidity.Name = "nQUValidity";
            this.nQUValidity.Size = new System.Drawing.Size(142, 38);
            this.nQUValidity.TabIndex = 44;
            // 
            // cbQUValidityActive
            // 
            this.cbQUValidityActive.AutoSize = true;
            this.cbQUValidityActive.Location = new System.Drawing.Point(14, 278);
            this.cbQUValidityActive.Name = "cbQUValidityActive";
            this.cbQUValidityActive.Size = new System.Drawing.Size(155, 36);
            this.cbQUValidityActive.TabIndex = 43;
            this.cbQUValidityActive.Text = "Validity:";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(14, 17);
            this.cbActive.Margin = new System.Windows.Forms.Padding(5);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(317, 36);
            this.cbActive.TabIndex = 42;
            this.cbActive.Text = "Enable Quick Unlock";
            this.cbActive.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // lQUPINLength
            // 
            this.lQUPINLength.AutoSize = true;
            this.lQUPINLength.Location = new System.Drawing.Point(7, 133);
            this.lQUPINLength.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lQUPINLength.Name = "lQUPINLength";
            this.lQUPINLength.Size = new System.Drawing.Size(155, 32);
            this.lQUPINLength.TabIndex = 41;
            this.lQUPINLength.Text = "PIN length:";
            // 
            // lQUMode
            // 
            this.lQUMode.AutoSize = true;
            this.lQUMode.Location = new System.Drawing.Point(7, 68);
            this.lQUMode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lQUMode.Name = "lQUMode";
            this.lQUMode.Size = new System.Drawing.Size(94, 32);
            this.lQUMode.TabIndex = 40;
            this.lQUMode.Text = "Mode:";
            // 
            // rbPINEnd
            // 
            this.rbPINEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPINEnd.AutoSize = true;
            this.rbPINEnd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbPINEnd.Location = new System.Drawing.Point(483, 225);
            this.rbPINEnd.Margin = new System.Windows.Forms.Padding(5);
            this.rbPINEnd.Name = "rbPINEnd";
            this.rbPINEnd.Size = new System.Drawing.Size(334, 36);
            this.rbPINEnd.TabIndex = 39;
            this.rbPINEnd.TabStop = true;
            this.rbPINEnd.Text = "Use {0} last characters";
            this.rbPINEnd.UseVisualStyleBackColor = true;
            // 
            // rbPINFront
            // 
            this.rbPINFront.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPINFront.AutoSize = true;
            this.rbPINFront.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbPINFront.Location = new System.Drawing.Point(484, 178);
            this.rbPINFront.Margin = new System.Windows.Forms.Padding(5);
            this.rbPINFront.Name = "rbPINFront";
            this.rbPINFront.Size = new System.Drawing.Size(335, 36);
            this.rbPINFront.TabIndex = 38;
            this.rbPINFront.TabStop = true;
            this.rbPINFront.Text = "Use {0} first characters";
            this.rbPINFront.UseVisualStyleBackColor = true;
            // 
            // tbPINLength
            // 
            this.tbPINLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPINLength.Location = new System.Drawing.Point(639, 129);
            this.tbPINLength.Margin = new System.Windows.Forms.Padding(5);
            this.tbPINLength.MaxLength = 3;
            this.tbPINLength.Name = "tbPINLength";
            this.tbPINLength.Size = new System.Drawing.Size(175, 38);
            this.tbPINLength.TabIndex = 37;
            this.tbPINLength.Tag = "32";
            this.tbPINLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPINLength.TextChanged += new System.EventHandler(this.tbPINLength_TextChanged);
            // 
            // cbPINMode
            // 
            this.cbPINMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPINMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPINMode.FormattingEnabled = true;
            this.cbPINMode.Items.AddRange(new object[] {
            "Quick Unlock entry only",
            "Database password"});
            this.cbPINMode.Location = new System.Drawing.Point(189, 64);
            this.cbPINMode.Margin = new System.Windows.Forms.Padding(5);
            this.cbPINMode.Name = "cbPINMode";
            this.cbPINMode.Size = new System.Drawing.Size(624, 39);
            this.cbPINMode.TabIndex = 36;
            this.cbPINMode.SelectedIndexChanged += new System.EventHandler(this.cbPINMode_SelectedIndexChanged);
            // 
            // tabLockWorkspace
            // 
            this.tabLockWorkspace.BackColor = System.Drawing.Color.Transparent;
            this.tabLockWorkspace.Controls.Add(this.tbLockWorkspace);
            this.tabLockWorkspace.Controls.Add(this.panel1);
            this.tabLockWorkspace.Location = new System.Drawing.Point(10, 48);
            this.tabLockWorkspace.Margin = new System.Windows.Forms.Padding(5);
            this.tabLockWorkspace.Name = "tabLockWorkspace";
            this.tabLockWorkspace.Padding = new System.Windows.Forms.Padding(5);
            this.tabLockWorkspace.Size = new System.Drawing.Size(833, 639);
            this.tabLockWorkspace.TabIndex = 0;
            this.tabLockWorkspace.Text = "Lock Workspace";
            this.tabLockWorkspace.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbLockWorkspace);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 87);
            this.panel1.TabIndex = 36;
            // 
            // cbLockWorkspace
            // 
            this.cbLockWorkspace.AutoSize = true;
            this.cbLockWorkspace.Location = new System.Drawing.Point(14, 17);
            this.cbLockWorkspace.Margin = new System.Windows.Forms.Padding(5);
            this.cbLockWorkspace.Name = "cbLockWorkspace";
            this.cbLockWorkspace.Size = new System.Drawing.Size(261, 36);
            this.cbLockWorkspace.TabIndex = 42;
            this.cbLockWorkspace.Text = "Lock Workspace";
            this.cbLockWorkspace.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbLockWorkspace.UseVisualStyleBackColor = true;
            // 
            // tbLockWorkspace
            // 
            this.tbLockWorkspace.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbLockWorkspace.Location = new System.Drawing.Point(5, 92);
            this.tbLockWorkspace.Multiline = true;
            this.tbLockWorkspace.Name = "tbLockWorkspace";
            this.tbLockWorkspace.ReadOnly = true;
            this.tbLockWorkspace.Size = new System.Drawing.Size(823, 259);
            this.tbLockWorkspace.TabIndex = 37;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tcLockAssistOptions);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OptionsForm";
            this.Size = new System.Drawing.Size(853, 697);
            this.Load += new System.EventHandler(this.UnlockOptions_Load);
            this.tcLockAssistOptions.ResumeLayout(false);
            this.tabQuickUnlock.ResumeLayout(false);
            this.tabQuickUnlock.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nQUValidity)).EndInit();
            this.tabLockWorkspace.ResumeLayout(false);
            this.tabLockWorkspace.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TabControl tcLockAssistOptions;
		private System.Windows.Forms.TabPage tabQuickUnlock;
        private System.Windows.Forms.TabPage tabLockWorkspace; 
        private System.Windows.Forms.CheckBox cbPINDBSpecific;
		private System.Windows.Forms.TextBox tbModeExplain;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckBox cbActive;
		private System.Windows.Forms.Label lQUPINLength;
		private System.Windows.Forms.Label lQUMode;
		private System.Windows.Forms.RadioButton rbPINEnd;
		private System.Windows.Forms.RadioButton rbPINFront;
		private System.Windows.Forms.TextBox tbPINLength;
		internal System.Windows.Forms.ComboBox cbPINMode;
        private System.Windows.Forms.ComboBox cbQUValidity;
        private System.Windows.Forms.NumericUpDown nQUValidity;
        private System.Windows.Forms.CheckBox cbQUValidityActive;
        private System.Windows.Forms.TextBox tbLockWorkspace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbLockWorkspace;
    }
}
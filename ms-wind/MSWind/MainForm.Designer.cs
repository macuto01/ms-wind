namespace MSWind
{
    partial class MainForm
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
            // Close all maple connections in Players[]
            
            AccountDialog.Dispose();
            ModifyDialog.Dispose();

            base.Dispose(disposing);

            foreach(Client Player in AccountInfo.Players)
            {
                if(Player!=null)
                    Player.MapleConnect.ReceiveLoopThread.Abort();
            }

            System.Windows.Forms.Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editoReader.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.buttonAccountSettings = new System.Windows.Forms.Button();
            this.comboBoxCharacters = new System.Windows.Forms.ComboBox();
            this.comboBoxAccounts = new System.Windows.Forms.ComboBox();
            this.buttonLoginCharacter = new System.Windows.Forms.Button();
            this.buttonAddAccount = new System.Windows.Forms.Button();
            this.buttonRemoveCharacter = new System.Windows.Forms.Button();
            this.buttonLoginAccount = new System.Windows.Forms.Button();
            this.buttonAddCharacter = new System.Windows.Forms.Button();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.buttonAccountSettings);
            this.groupBoxLogin.Controls.Add(this.comboBoxCharacters);
            this.groupBoxLogin.Controls.Add(this.comboBoxAccounts);
            this.groupBoxLogin.Controls.Add(this.buttonLoginCharacter);
            this.groupBoxLogin.Controls.Add(this.buttonAddAccount);
            this.groupBoxLogin.Controls.Add(this.buttonRemoveCharacter);
            this.groupBoxLogin.Controls.Add(this.buttonLoginAccount);
            this.groupBoxLogin.Controls.Add(this.buttonAddCharacter);
            this.groupBoxLogin.Location = new System.Drawing.Point(3, -3);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(300, 72);
            this.groupBoxLogin.TabIndex = 21;
            this.groupBoxLogin.TabStop = false;
            // 
            // buttonAccountSettings
            // 
            this.buttonAccountSettings.Enabled = false;
            this.buttonAccountSettings.Image = global::MSWind.Properties.Resources.Gear16;
            this.buttonAccountSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAccountSettings.Location = new System.Drawing.Point(239, 13);
            this.buttonAccountSettings.Name = "buttonAccountSettings";
            this.buttonAccountSettings.Size = new System.Drawing.Size(24, 24);
            this.buttonAccountSettings.TabIndex = 14;
            this.buttonAccountSettings.UseVisualStyleBackColor = true;
            this.buttonAccountSettings.Click += new System.EventHandler(this.buttonAccountSettings_Click);
            // 
            // comboBoxCharacters
            // 
            this.comboBoxCharacters.Enabled = false;
            this.comboBoxCharacters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxCharacters.FormattingEnabled = true;
            this.comboBoxCharacters.Location = new System.Drawing.Point(7, 42);
            this.comboBoxCharacters.Name = "comboBoxCharacters";
            this.comboBoxCharacters.Size = new System.Drawing.Size(196, 23);
            this.comboBoxCharacters.TabIndex = 19;
            this.comboBoxCharacters.Text = "characters...";
            this.comboBoxCharacters.SelectedIndexChanged += new System.EventHandler(this.comboBoxCharacters_SelectedIndexChanged);
            // 
            // comboBoxAccounts
            // 
            this.comboBoxAccounts.Enabled = false;
            this.comboBoxAccounts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxAccounts.FormattingEnabled = true;
            this.comboBoxAccounts.Location = new System.Drawing.Point(7, 13);
            this.comboBoxAccounts.Name = "comboBoxAccounts";
            this.comboBoxAccounts.Size = new System.Drawing.Size(196, 23);
            this.comboBoxAccounts.TabIndex = 12;
            this.comboBoxAccounts.Text = "add an account...";
            this.comboBoxAccounts.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccounts_SelectedIndexChanged);
            // 
            // buttonLoginCharacter
            // 
            this.buttonLoginCharacter.Enabled = false;
            this.buttonLoginCharacter.Image = global::MSWind.Properties.Resources.Tick16;
            this.buttonLoginCharacter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonLoginCharacter.Location = new System.Drawing.Point(269, 41);
            this.buttonLoginCharacter.Name = "buttonLoginCharacter";
            this.buttonLoginCharacter.Size = new System.Drawing.Size(24, 24);
            this.buttonLoginCharacter.TabIndex = 18;
            this.buttonLoginCharacter.UseVisualStyleBackColor = true;
            this.buttonLoginCharacter.Click += new System.EventHandler(this.buttonLoginCharacter_Click);
            // 
            // buttonAddAccount
            // 
            this.buttonAddAccount.Image = global::MSWind.Properties.Resources.Plus16;
            this.buttonAddAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAddAccount.Location = new System.Drawing.Point(209, 13);
            this.buttonAddAccount.Name = "buttonAddAccount";
            this.buttonAddAccount.Size = new System.Drawing.Size(24, 24);
            this.buttonAddAccount.TabIndex = 13;
            this.buttonAddAccount.UseVisualStyleBackColor = true;
            this.buttonAddAccount.Click += new System.EventHandler(this.buttonAddAccount_Click);
            // 
            // buttonRemoveCharacter
            // 
            this.buttonRemoveCharacter.Enabled = false;
            this.buttonRemoveCharacter.Image = global::MSWind.Properties.Resources.Delete16;
            this.buttonRemoveCharacter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRemoveCharacter.Location = new System.Drawing.Point(239, 41);
            this.buttonRemoveCharacter.Name = "buttonRemoveCharacter";
            this.buttonRemoveCharacter.Size = new System.Drawing.Size(24, 24);
            this.buttonRemoveCharacter.TabIndex = 17;
            this.buttonRemoveCharacter.UseVisualStyleBackColor = true;
            // 
            // buttonLoginAccount
            // 
            this.buttonLoginAccount.Enabled = false;
            this.buttonLoginAccount.Image = global::MSWind.Properties.Resources.Tick16;
            this.buttonLoginAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonLoginAccount.Location = new System.Drawing.Point(269, 13);
            this.buttonLoginAccount.Name = "buttonLoginAccount";
            this.buttonLoginAccount.Size = new System.Drawing.Size(24, 24);
            this.buttonLoginAccount.TabIndex = 15;
            this.buttonLoginAccount.UseVisualStyleBackColor = true;
            this.buttonLoginAccount.Click += new System.EventHandler(this.buttonLoginAccount_Click);
            // 
            // buttonAddCharacter
            // 
            this.buttonAddCharacter.Enabled = false;
            this.buttonAddCharacter.Image = global::MSWind.Properties.Resources.Plus16;
            this.buttonAddCharacter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAddCharacter.Location = new System.Drawing.Point(209, 41);
            this.buttonAddCharacter.Name = "buttonAddCharacter";
            this.buttonAddCharacter.Size = new System.Drawing.Size(24, 24);
            this.buttonAddCharacter.TabIndex = 16;
            this.buttonAddCharacter.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 72);
            this.Controls.Add(this.groupBoxLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MSWind";
            this.groupBoxLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Dialog.AddAccount AccountDialog;
        private Dialog.ModifyAccount ModifyDialog;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button buttonAccountSettings;
        private System.Windows.Forms.ComboBox comboBoxCharacters;
        private System.Windows.Forms.ComboBox comboBoxAccounts;
        private System.Windows.Forms.Button buttonLoginCharacter;
        private System.Windows.Forms.Button buttonAddAccount;
        private System.Windows.Forms.Button buttonRemoveCharacter;
        private System.Windows.Forms.Button buttonLoginAccount;
        private System.Windows.Forms.Button buttonAddCharacter;
    }
}


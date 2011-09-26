using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSWind
{
    /// <summary>
    /// Main Form in MSWind
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Constructor for MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            AccountDialog = new Dialog.AddAccount(this);
            ModifyDialog = new Dialog.ModifyAccount(this);
        }
       
        /// <summary>
        /// Updates the GUI when the account selected changes
        /// </summary>
        public void ChangedAccount()
        {
            if (this.comboBoxAccounts.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.comboBoxAccounts.Invoke(new ChangeAccountDelegate(this.ChangedAccount));
            }
            else
            {
                AccountInfo Account = AccountInfo.Players[AccountInfo.SelectedAccountIndex].Account;
                if (Account.LoggedIn)
                {
                    buttonAccountSettings.Enabled = false;
                    buttonAddAccount.Enabled = true;
                    buttonLoginAccount.Enabled = true;
                    buttonLoginAccount.Image = global::MSWind.Properties.Resources.Stop16;

                    int CharacterLoggedIn = -1;
                    comboBoxCharacters.Items.Clear();
                    for (int i = 0; i < Account.CharacterCount; i++)
                    {
                        if (Account.Characters[i].LoggedIn)
                            CharacterLoggedIn = i;
                        this.comboBoxCharacters.Items.Add(Account.Characters[i].Name);
                    }
                    if (CharacterLoggedIn != -1)
                    {
                        this.comboBoxCharacters.Enabled = false;
                        buttonAddCharacter.Enabled = false;
                        buttonRemoveCharacter.Enabled = false;
                        buttonLoginCharacter.Enabled = false;
                        buttonLoginCharacter.Image = global::MSWind.Properties.Resources.Stop16;
                        this.comboBoxCharacters.SelectedIndex = CharacterLoggedIn;
                    }
                    else
                    {
                        this.comboBoxCharacters.Enabled = true;
                        buttonAddCharacter.Enabled = true;
                        buttonRemoveCharacter.Enabled = true;
                        buttonLoginCharacter.Enabled = true;
                        buttonLoginCharacter.Image = global::MSWind.Properties.Resources.Tick16;
                        this.comboBoxCharacters.SelectedIndex = 0;
                    }
                }
                else
                {
                    this.comboBoxAccounts.Enabled = true;
                    buttonAccountSettings.Enabled = true;
                    buttonAddAccount.Enabled = true;
                    buttonLoginAccount.Enabled = true;
                    buttonLoginAccount.Image = global::MSWind.Properties.Resources.Tick16;

                    this.comboBoxCharacters.Enabled = false;
                    buttonAddCharacter.Enabled = false;
                    buttonRemoveCharacter.Enabled = false;
                    buttonLoginCharacter.Enabled = false;
                    buttonLoginCharacter.Image = global::MSWind.Properties.Resources.Tick16;
                    this.comboBoxCharacters.Text = "characters...";
                }
            }
        }

        private delegate void ChangeAccountDelegate();

        /// <summary>
        /// Adds an account into comboBoxAccounts
        /// </summary>
        public void AddAccount()
        {
            comboBoxAccounts.Items.Add(AccountInfo.Players[AccountInfo.AccountCount].Account.Username);
            comboBoxAccounts.SelectedIndex = AccountInfo.AccountCount;
            AccountInfo.AccountCount++;
        }

        /// <summary>
        /// Modfies an account in comboBoxAccounts
        /// </summary>
        public void ModifyAccount()
        {
            comboBoxAccounts.Items.RemoveAt(AccountInfo.SelectedAccountIndex);
            comboBoxAccounts.Items.Insert(AccountInfo.SelectedAccountIndex, AccountInfo.Players[AccountInfo.SelectedAccountIndex].Account.Username);
            comboBoxAccounts.SelectedIndex = AccountInfo.SelectedAccountIndex;
        }

        /// <summary>
        /// EventHandler for buttonAddAccount.Click
        /// Shows AddAccount dialog
        /// </summary>
        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            AccountDialog.Show();
        }

        /// <summary>
        /// EventHandler for buttonAccountSettings.Click
        /// Shows ModifyAccount dialog
        /// </summary>
        private void buttonAccountSettings_Click(object sender, EventArgs e)
        {
            ModifyDialog.Show();
        }

        /// <summary>
        /// Event Handler for comboBoxAccounts.SelectedIndexChanged
        /// </summary>
        private void comboBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccountInfo.SelectedAccountIndex = this.comboBoxAccounts.SelectedIndex;
            ChangedAccount();
        }

        private void comboBoxCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account.Character.SelectedCharacterIndex = this.comboBoxCharacters.SelectedIndex;
        }

        /// <summary>
        /// Event Handler for buttonLoginAccount.Click
        /// Logs into selected account
        /// </summary>
        private void buttonLoginAccount_Click(object sender, EventArgs e)
        {
            Client Player = AccountInfo.Players[AccountInfo.SelectedAccountIndex];
            if (!Player.Account.LoggedIn)
            {
                if (!Player.Account.LoggingIn)
                {
                    Player.Login(this);
                    buttonLoginAccount.Image = global::MSWind.Properties.Resources.Loading16;
                }
                else
                    MessageBox.Show("Already logging into this account");
            }
            else
            {
                Player.MapleConnect.Close();
                Player.Account.LoggedIn = false;
                ChangedAccount();
            }
        }

        private void buttonLoginCharacter_Click(object sender, EventArgs e)
        {
            Client Player = AccountInfo.Players[AccountInfo.SelectedAccountIndex];
            Account.Character Character = Player.Account.Characters[Account.Character.SelectedCharacterIndex];
            if (!Character.LoggedIn)
            {
                if (!Character.LoggingIn)
                {
                    Player.Account.CharacterIndex = Account.Character.SelectedCharacterIndex;
                    Player.LoginCharacter();
                    buttonLoginCharacter.Image = global::MSWind.Properties.Resources.Loading16;
                }
                else
                    MessageBox.Show("Already logging into this character");
            }
        }
    }
}

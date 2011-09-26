using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MSWind.Dialog
{
    /// <summary>
    /// Add Account dialog box
    /// </summary>
    public partial class AddAccount : Form
    {
        private MainForm MForm;

        /// <summary>
        /// Constructor for AddAccount
        /// </summary>
        public AddAccount(MainForm form)
        {
            InitializeComponent();
            MForm = form;
        }

        /// <summary>
        /// EventHandler for buttonOk.Click
        /// Performs data validation on user submitted data.
        /// Adds account info to AccountInfo.Players[] and then
        /// clears and hides form.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            AccountInfo.Players[AccountInfo.AccountCount] = new Client();
            AccountInfo Account = AccountInfo.Players[AccountInfo.AccountCount].Account;

            // validate
            const string RegexUser = @"^[a-zA-Z0-9]{4,12}$";  // regular expression for checking against username (a-z A-Z 0-9, minimum 4 chars max 12, no whitespace)
            const string RegexPass = @"^.{6,12}$";            // min 6 chars, max 12, whitespace allowed, any char
            const string RegexPin = @"^[0-9]{4}$";            // numbers 0-9, 4 chars

            Match mUser = Regex.Match(textBoxUsername.Text, RegexUser);
            Match mPass = Regex.Match(textBoxPassword.Text, RegexPass);
            Match mPin = Regex.Match(textBoxPin.Text, RegexPin);
            bool userTaken = false;

            for (int i = 0; i < AccountInfo.AccountCount; i++)
            {
                if (String.Compare(textBoxUsername.Text, AccountInfo.Players[i].Account.Username, true) == 0)
                {
                    MessageBox.Show("Account of username " + textBoxUsername.Text + " already exists. Please choose a different username.");
                    userTaken = true;
                }
            }

            if (mUser.Success && mPass.Success && mPin.Success && comboBoxWorld.SelectedIndex != -1 && comboBoxChannel.SelectedIndex != -1 && !userTaken)
            {
                // add account and hide form
                Account.Username = textBoxUsername.Text;
                Account.Password = textBoxPassword.Text;
                Account.Pin = textBoxPin.Text;
                Account.World = comboBoxWorld.Text;
                Account.WorldIndex = comboBoxWorld.SelectedIndex;
                Account.ChannelIndex = comboBoxChannel.SelectedIndex;
                Account.AutoSelect = checkBoxLeastPopulatedChannel.Checked;

                MForm.AddAccount();
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
                textBoxPin.Text = "";
                comboBoxWorld.SelectedIndex = -1;
                comboBoxChannel.SelectedIndex = -1;
                this.Hide();
            }
            else if (textBoxUsername.Text == "" && textBoxPassword.Text == "" && textBoxPin.Text == "" && comboBoxWorld.SelectedIndex == -1 && comboBoxChannel.SelectedIndex == -1)
            {
                this.Hide(); // if empty hide form
            }
            else
            {
                // error messages
                if (!mUser.Success)
                    MessageBox.Show("Username must only contain the characters a-z, A-Z and 0-9 and must be a minimum of 4 characters and a maximum of 12");
                if (!mPass.Success)
                    MessageBox.Show("Password must be a minimum of 6 characters and a maximum of 12");
                if (!mPin.Success)
                    MessageBox.Show("Pin must be only 4 numbers");
                if (comboBoxWorld.SelectedIndex == -1)
                    MessageBox.Show("Please select a world");
                if (comboBoxChannel.Enabled && comboBoxChannel.SelectedIndex == -1)
                    MessageBox.Show("Please select a channel");
            }
        }     
    }
}

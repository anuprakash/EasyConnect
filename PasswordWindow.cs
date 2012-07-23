﻿using System;
using System.Security;
using System.Windows.Forms;

namespace EasyConnect
{
    public partial class PasswordWindow : Form
    {
        public PasswordWindow()
        {
            InitializeComponent();

            cancelButton.Visible = false;
        }

        public bool ShowCancelButton
        {
            get
            {
                return cancelButton.Visible;
            }

            set
            {
                if (value)
                    okButton.Left = cancelButton.Left - okButton.Width - 7;

                else
                    okButton.Left = cancelButton.Left;

                cancelButton.Visible = value;
            }
        }

        public SecureString Password
        {
            get
            {
                return passwordTextBox.SecureText;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            passwordTextBox.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                okButton_Click(null, null);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
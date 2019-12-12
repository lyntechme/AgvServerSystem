using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using BLL;

namespace AgvServerSystem
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void btnPwdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPwd = txtPwdOld.Text.Trim();
            string newPwd1 = txtPwdNew1.Text.Trim();
            string newPwd2 = txtPwdNew2.Text.Trim();
            byte[] reult = Encoding.Default.GetBytes(oldPwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(reult);

            bool isRight = true;
            char[] limitChar = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            string pwd = newPwd1 + newPwd2;
            foreach (char item in pwd.ToCharArray())
            {
                if (!limitChar.Contains(item))
                {
                    isRight = false;
                    break;
                }
            }

            if (BitConverter.ToString(output).Replace("_", "") == LoginRoler.U_Password)
            {
                if (newPwd1 == "")
                {
                    MessageBox.Show("Password cant be null", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (newPwd2 == "")
                {
                    MessageBox.Show("Second password cant be null", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (newPwd1.Length < 8 || newPwd2.Length < 8)
                {
                    MessageBox.Show("Password length 8 ~ 16", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (!isRight)
                {
                    MessageBox.Show("Passwords can only be numeric", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (newPwd1 != newPwd2)
                {
                    MessageBox.Show("Password not the same", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtPwdNew2.Text = "";
                }
                else if (newPwd1 == newPwd2)
                {
                    byte[] newReult = Encoding.Default.GetBytes(newPwd1);
                    byte[] newOutput = md5.ComputeHash(newReult);
                    BU_UserInfo Bui = new BU_UserInfo();
                    if (Bui.UpdatePassword(BitConverter.ToString(newOutput).Replace("_", ""), LoginRoler.U_Id))
                    {
                        MessageBox.Show("Modify successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Modify failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                { 
                
                }
            }
            else
            {
                MessageBox.Show("Old password error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPwdOld.Text = "";
            }
        }
    }
}

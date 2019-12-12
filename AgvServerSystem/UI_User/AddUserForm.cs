using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;
using System.Security.Cryptography;

namespace AgvServerSystem
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string userName = this.txtAddUser.Text.Trim();
            string pwd1 = this.txtAddUserPwd1.Text.Trim();
            string pwd2 = this.txtAddUserPwd2.Text.Trim();
            bool isRight = true;
            char[] limitChar = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            string pwd = pwd1 + pwd2;
            foreach (char item in pwd.ToCharArray())
            {
                if (!limitChar.Contains(item))
                {
                    isRight = false;
                    break;
                }
            }
            if (userName == "")
            {
                MessageBox.Show("The name cannot be null", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAddUser.Focus();
                return;
            }
            else if (pwd1 == "")
            {
                MessageBox.Show("The password cannot be null", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAddUserPwd1.Focus();
                return;
            }
            else if (pwd2 == "")
            {
                MessageBox.Show("The password cannot be null", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAddUserPwd2.Focus();
                return;
            }
            else if (pwd1.Length < 8 || pwd2.Length < 8)
            {
                MessageBox.Show("The passwrod length is 8 to 16", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!isRight)
            {
                MessageBox.Show("Passwords can only be Numbers or letters", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (pwd1 != pwd2)
            {
                MessageBox.Show("The passwords are different", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAddUserPwd2.Text = "";
            }
            else if (pwd1 == pwd2)
            {
                BU_UserInfo Bui = new BU_UserInfo();
                int a = Bui.ExistsName(userName);
                if (a != 0)
                {
                    MessageBox.Show("User already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MU_UserInfo Mui = new MU_UserInfo();
                    byte[] result = Encoding.Default.GetBytes(pwd1);
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] output = md5.ComputeHash(result);
                    Mui.U_Password = BitConverter.ToString(output).Replace("_", "");
                    Mui.U_Name = userName;
                    Mui.U_LoginTime = DateTime.Now;
                    if (cbLevel.Text == "Administrator")
                    {
                        Mui.U_Level = 2;
                    }
                    else
                    {
                        Mui.U_Level = 1;
                    }
                    int b = Bui.AddUser(Mui);
                    if (b == 0)
                    {
                        MessageBox.Show("Add failed, please add again", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Successfully added", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Unknown error,please add again", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtAddUser.Text = "";
                txtAddUserPwd1.Text = "";
                txtAddUserPwd2.Text = "";
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUserCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            if (cbLevel.Items.Count > 0)
            {
                cbLevel.SelectedIndex = 0;
            }
        }
    }
}

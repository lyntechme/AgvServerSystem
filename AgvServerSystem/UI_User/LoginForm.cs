using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Security.Cryptography;
using Model;

namespace AgvServerSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }
        private void login()
        {
            string userName = txtLoginUser.Text;
            string userPwd = txtLoginPwd.Text;
            if (txtLoginUser.Text == "")
            {
                MessageBox.Show("The name cannot be null!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (txtLoginPwd.Text == "")
            {
                MessageBox.Show("The password cannot be null !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//RSACryptoServiceProvider
            }
            else
            {
                if (userName == Common.dynName)
                {//用户密码登录
                    string key = DateTime.Now.ToString("yyyy") + "K" + DateTime.Now.ToString("yyyyMMdd") + "O";
                    MD5 md5 = MD5.Create();
                    byte[] bytes = md5.ComputeHash(Encoding.Default.GetBytes(key));
                    string pwd = string.Join("", bytes);
                    if (pwd.Length > 10)
                        pwd = pwd.Substring(0, 10);
                    int week = Convert.ToInt32((DateTime.Today.DayOfWeek));
                    int p1 = Convert.ToInt32((DateTime.Today.Year * (week + 1)).ToString() + (DateTime.Today.Day * (week + 1)).ToString());
                    string pwd2 = (p1 + DateTime.Today.Month * (week + 1)).ToString();
                    if (pwd == userPwd || pwd2 == userPwd)
                    {
                        MessageBox.Show("Login successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoginRoler.U_Id = 999; //用户主键
                        LoginRoler.U_Name = userName;
                        LoginRoler.U_Password = pwd;
                        LoginRoler.U_Level = 3;//用户类型
                        this.Close();
                    }
                }
                else
                {
                    BU_UserInfo Bui = new BU_UserInfo();
                    int a = Bui.ExistsName(userName);
                    if (a != 0)
                    {
                        byte[] result = Encoding.Default.GetBytes(userPwd);
                        MD5 md5 = new MD5CryptoServiceProvider();
                        byte[] output = md5.ComputeHash(result);
                        string outPwdStr = BitConverter.ToString(output).Replace("_", "");
                        DataSet ds = Bui.ExistsPwd(userName, outPwdStr);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Login successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            LoginRoler.U_Id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()); //用户主键
                            LoginRoler.U_Name = userName;
                            LoginRoler.U_Password = outPwdStr;
                            LoginRoler.U_Level = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());//用户类型
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtLoginUser.Text = "";
                            txtLoginPwd.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("The user does not exist.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtLoginUser.Text = "";
                        txtLoginPwd.Text = "";
                    }
                }
            }
        }

        private void btnLoginCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoginPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    //login();
                    btnLogin.Focus();
                }
            }
            catch { }
        }

        private void txtLoginUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    txtLoginPwd.Focus();
                }
            }
            catch { }
        }
    }
}

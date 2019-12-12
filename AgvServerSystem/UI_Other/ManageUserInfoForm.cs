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
    public partial class ManageUserInfoForm : Form
    {
        public ManageUserInfoForm()
        {
            InitializeComponent();
        }

        private void btnObainUserInfo_Click(object sender, EventArgs e)
        {
            BU_UserInfo bui = new BU_UserInfo();
            List<MU_UserInfo> allUser = new List<MU_UserInfo>();
            allUser = bui.QueryAllUser();
            dgvUserInfo.Rows.Clear();
            for (int i = 0; i < allUser.Count; i++)
            {
                if (allUser[i].U_Id != 1 && allUser[i].U_Name != "okAdmin")
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    dr.CreateCells(dgvUserInfo);
                    dr.Cells[0].Value = allUser[i].U_Id;
                    dr.Cells[1].Value = allUser[i].U_Name;
                    dr.Cells[2].Value = "";
                    dr.Cells[3].Value = allUser[i].U_Level;
                    dgvUserInfo.Rows.Add(dr);
                }
            }
        }

        private void dgvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rows = e.RowIndex;
                if (e.ColumnIndex == 4)
                {
                    if (MessageBox.Show("是否删除该用户的信息?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        BU_UserInfo bui = new BU_UserInfo();
                        int uid = Convert.ToInt32(dgvUserInfo[0, rows].Value.ToString());
                        if (dgvUserInfo[1, rows].Value.ToString() == "okAdmin")
                        {
                            MessageBox.Show("维护用户，不可删除!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        else if (bui.DeleteUser(uid))
                        {
                            MessageBox.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("删除失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                }
                if (e.ColumnIndex == 5)
                {
                    if (MessageBox.Show("是否修改该用户的信息?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (dgvUserInfo[1, rows].Value.ToString() == "okAdmin")
                        {
                            MessageBox.Show("维护用户，不可修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        else
                        {
                            string pwd = dgvUserInfo[2, rows].Value.ToString();
                            int level = 0;
                            int id = 0;
                            string name = dgvUserInfo[1, rows].Value.ToString();
                            try
                            {
                                try 
                                {
                                    level = Convert.ToInt32(dgvUserInfo[3, rows].Value.ToString());
                                }
                                catch 
                                {
                                    MessageBox.Show("用户等级输入格式错误，只能为一个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                bool isPwd = true;
                                char[] limitChar = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();                                
                                foreach (char item in pwd.ToCharArray())
                                {
                                    if (!limitChar.Contains(item))
                                    {
                                        isPwd = false;
                                        break;
                                    }
                                }
                                if (!isPwd)
                                {
                                    MessageBox.Show("密码格式错误!密码只能为数字或字母。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return;
                                }
                                if (pwd.Length < 8 || pwd.Length > 16)
                                {
                                    MessageBox.Show("密码格式错误!密码长度为8~16", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return;
                                }
                                try
                                {
                                    id = Convert.ToInt32(dgvUserInfo[0, rows].Value.ToString());
                                }
                                catch
                                {
                                    MessageBox.Show("用户ID出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return;
                                }

                                byte[] result = Encoding.Default.GetBytes(pwd);
                                MD5 md5 = new MD5CryptoServiceProvider();
                                byte[] output = md5.ComputeHash(result);
                                pwd = BitConverter.ToString(output).Replace("_", "");
                                BU_UserInfo bui = new BU_UserInfo();
                                MU_UserInfo _mui = new MU_UserInfo(id, name, pwd, level, DateTime.Now);
                                if (bui.UpdateUser(_mui))
                                {
                                    MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("更新失败，未知错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("更新失败，未知错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                        }
                    }
                }

            }
            catch
            { }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace AgvServerSystem
{
    public class DataToExcel
    {
        /// <summary>
        /// 将DataGridView数据导出
        /// </summary>
        /// <param name="titleName">标题</param>
        /// <param name="m_DataView"></param>
        public void DataToExcelDataGridView(DataGridView m_DataView,string titleName)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = titleName;
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show("保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                kk.Dispose();
            }
            catch { }
        }
        public void DataToExcelTable(DataTable m_DataTable, string titleName)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = titleName;
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName + ".xls";
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataTable.Columns.Count; i++)
                {
                    strLine = strLine + m_DataTable.Columns[i].Caption.ToString() + Convert.ToChar(9);
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < m_DataTable.Columns.Count; j++)
                    {
                        if (m_DataTable.Rows[i].ItemArray[j] == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                        {
                            string rowstr = "";
                            rowstr = m_DataTable.Rows[i].ItemArray[j].ToString();
                            if (rowstr.IndexOf("\r\n") > 0)
                                rowstr = rowstr.Replace("\r\n", " ");
                            if (rowstr.IndexOf("\t") > 0)
                                rowstr = rowstr.Replace("\t", " ");
                            strLine = strLine + rowstr + Convert.ToChar(9);
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show("保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                kk.Dispose();
            }
            catch { }
        }
        /// <summary>
        /// 从excel导出数据到Dataset
        /// </summary>
        /// <param name="titilName">标题名字</param>
        /// <returns></returns>
        public DataSet ExcelToDataset(string titleName)
        {
            DataSet ds = new DataSet();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = titleName;
            ofd.Filter = "EXECL文件(*.xls) |*.xls |EXECL文件(*.xlsx) |*.xlsx |所有文件(*.*) |*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string FileName = ofd.FileName;
                string strCon = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";
                //string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties='Excel 8.0;IMEX=1'";
                using (OleDbConnection conn = new OleDbConnection(strCon))
                {
                    string strCom = "SELECT * FROM [Sheet1$]";
                    conn.Open();
                    OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, conn);
                    myCommand.Fill(ds);
                }
            }
            try
            {
                ofd.Dispose();
            }
            catch { }
            return ds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Model;
using System.Data;
using System.IO;
using DAL;
using System.Security.Cryptography;

namespace BLL
{
    public class BS_CreateSqlLiteTables
    {
        public static bool CreateRfidPoint(string path)
        {
            try
            {

                if (!File.Exists(path))
                {
                    //File.Create(path);
                    SQLiteConnection.CreateFile(path);

                    SQLiteConnection connection = new SQLiteConnection("Data Source=" + path);
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        //长春大陆汽车 物料表
                        command.CommandText = "CREATE TABLE MaterialInfo(id integer NOT NULL PRIMARY KEY,lineNo integer,barCode string,materialName string,stationNo integer)";
                        int material = command.ExecuteNonQuery();
                        //长春大陆汽车  与Agv通讯寄存器绑定表
                        command.CommandText = "CREATE TABLE StationAddressInfo(id integer NOT NULL PRIMARY KEY,lineNo integer,stationNo integer,wordAddress integer,bitAddress integer,rfid integer,UpdateDate DATETIME)";
                        int station = command.ExecuteNonQuery();
                        command.CommandText = "CREATE TABLE InventoryLocationInfo(id INTEGER NOT NULL PRIMARY KEY,aisleNumber INTEGER,slotNumber INTEGERL,inventoryType TEXT,invLocState INT,WordAddress INTEGER,bitAddress INTEGER,rfid INTEGER)";
                        int InvLoc = command.ExecuteNonQuery();
                        //长春大陆汽车  一个任务需要的时间
                        command.CommandText = "CREATE TABLE AgvTaskInfo(T_Id integer NOT NULL PRIMARY KEY,T_AgvNo integer NOT NULL,T_LineNo varchar(50),T_WorkTime varchar(50),T_UpdateTime datetime)";
                        int task = command.ExecuteNonQuery();
                        //创建存储RfidXml数据的表
                        command.CommandText = "CREATE TABLE RfidPointInfo(id integer NOT NULL PRIMARY KEY,rfidXml Xml)";
                        int rfid = command.ExecuteNonQuery();
                        //创建AgvComInfo数据表
                        command.CommandText = "CREATE TABLE AgvComInfo(A_Id integer NOT NULL PRIMARY KEY,A_Description varchar(50) NOT NULL,A_IPAddress varchar(50) NOT NULL,A_NetNo integer NOT NULL,A_LocalPort integer NOT NULL,A_DesPort integer NOT NULL,A_AgvType varchar(50) NOT NULL,A_IsUsing BOOLEAN)";
                        int comInfo = command.ExecuteNonQuery();
                        //创建记录TabCheckInfo数据表
                        command.CommandText = "CREATE TABLE TabCheckInfo(T_Id integer NOT NULL PRIMARY KEY,T_Name varchar(50) NOT NULL,T_Checked integer NOT NULL)";
                        int tabCheck = command.ExecuteNonQuery();
                        for (int i = 0; i < Common.tabName.Length; i++)
                        {
                            command.CommandText = "insert into TabCheckInfo values(" + i.ToString() + ",'" + Common.tabName[i] + "',0)";
                            int a = command.ExecuteNonQuery();
                        }
                        //创建AgvErroe数据表
                        command.CommandText = "CREATE TABLE AgvError(E_Id integer NOT NULL PRIMARY KEY,E_AgvNo integer NOT NULL,E_Info varchar(50),E_InfoNo integer,E_LineNo varchar(50),E_AgvRfid integer,E_Task varchar(50),E_UpdateTime datetime)";
                        int erroe = command.ExecuteNonQuery();        
                        //创建UserInfo表，并添加管理员用户
                        command.CommandText = "CREATE TABLE UserInfo(U_Id integer NOT NULL PRIMARY KEY,U_Name varchar(50) NOT NULL,U_Password varchar(50) NOT NULL,U_Level integer NOT NULL,U_LoginTime datetime)";
                        int userInfo = command.ExecuteNonQuery();
                        byte[] result = Encoding.Default.GetBytes("okjiqiren");
                        MD5 md5 = new MD5CryptoServiceProvider();
                        byte[] output = md5.ComputeHash(result);
                        string pwd = BitConverter.ToString(output).Replace("_", "");
                        command.CommandText = "insert into UserInfo values(1,'okAdmin','" + pwd + "',3,datetime('Now','localtime'))";
                        int userAdd = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                File.Delete(path);
                return false;
            }
        }
        public static void AddRfidPoint(int id, string rfidXml)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Insert into RfidPointInfo(id,rfidXml)values(@id,@rfidXml)");
            SQLiteParameter[] param = { 
                                          new SQLiteParameter("@id",id), 
                                          new SQLiteParameter("@rfidXml",rfidXml) 
                                      };
            int a = SqlLiteHelper.ExecuteNonQuery(strSql.ToString(), param);
        }
        public static string Query()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from RfidPointInfo");
            DataSet ds = SqlLiteHelper.ExecuteDataset(strSql.ToString());
            int id = 0;
            string rfidxml = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                id = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                rfidxml = ds.Tables[0].Rows[i][1].ToString();
            }
            return rfidxml;
        }
    }
}

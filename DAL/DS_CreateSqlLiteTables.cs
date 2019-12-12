using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Model;
using System.Data;
using System.IO;
using DAL;

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
                }
                SQLiteConnection connection = new SQLiteConnection("Data Source=" + path);
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "CREATE TABLE RfidPointInfo(id integer NOT NULL PRIMARY KEY,rfidXml Xml)";
                    int rfid = command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE AgvComInfo(A_Id integer NOT NULL PRIMARY KEY,A_Description varchar(50) NOT NULL,A_IPAddress varchar(50) NOT NULL,A_NetNo integer NOT NULL,A_LocalPort integer NOT NULL,A_DesPort integer NOT NULL,A_AgvType varchar(50) NOT NULL,A_IsUsing BLOB)";
                    int comInfo = command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE AgvError E_Id integer NOT NULL PRIMARY KEY,E_AgvNo integer NOT NULL,E_Info varchar(50),E_InfoNo integer,E_AgvRfid integer,E_Task varchar(50),E_UpdateTime datetime";
                    int erroe = command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE UserInfo U_Id integer NOT NULL PRIMARY KEY,U_Name varchar(50) NOT NULL,U_Password varchar(50) NOT NULL,U_Level integer NOT NUL,U_LoginTime datetime";
                    int userInfo = command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
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

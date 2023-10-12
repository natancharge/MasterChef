using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace MasterChef
{
    public class DAL
    {

       public static string ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\chert\OneDrive\Рабочий стол\MasterChef\signing info project 30.accdb;Persist Security Info=True";
        /*
        public DAL()
        {
            string ApplicationBaseFolder = AppDomain.CurrentDomain.BaseDirectory;  // directory of EXE file, at bin/debug directory
            ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ApplicationBaseFolder + "../../DataBase/MyDatabase.accdb;Persist Security Info=True";

        }
        */
        public static OleDbConnection GetConnection() {
            if (ConnectionString == null)
            {
                string ApplicationBaseFolder = AppDomain.CurrentDomain.BaseDirectory;  // directory of EXE file, at bin/debug directory
                ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ApplicationBaseFolder + "../../DataBase/add_remove_change.accdb;Persist Security Info=True";

            }
            return new OleDbConnection(ConnectionString);
        }

        public static OleDbCommand GetCommand(OleDbConnection con, string sqlStr)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlStr;
            return cmd;
        }

        public static DataTable GetDataTable(string sqlStr)
        {
            OleDbConnection con = GetConnection();
            OleDbCommand cmd = GetCommand(con, sqlStr);

            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);

            return dt;
        }
        public static DataView GetDataView(string sqlStr)
        {
            return GetDataTable(sqlStr).DefaultView;
        }

        public static DataRow GetRandomRow(string sqlStr)
        {
            sqlStr = sqlStr.ToLower ().Replace("select", "select top 1 ");
            DataTable dt = GetDataTable(sqlStr+ " ORDER BY rnd(ID)");

            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }


        public static int ExecuteNonQuery( string sqlStr)
        {
            OleDbConnection con = GetConnection();
            con.Open();

            OleDbCommand cmd = GetCommand(con,sqlStr);

            int rowAfferted =cmd.ExecuteNonQuery();
            con.Close();

            return rowAfferted;
        }

        public static bool UpdateWord(bool success, int id)
        {
            string s = "Fail";
            if (success) s = "Succeed";

            string sqlStr = $"UPDATE WordTbl SET {s} = {s} + 1 WHERE(ID = {id})";
            int rowAfferted = ExecuteNonQuery(sqlStr);
            
            return rowAfferted > 0;
        }
    }
}

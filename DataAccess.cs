using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
  
using MySql.Data.MySqlClient;

namespace recommendation_system
{
    class DataAccess
    {
        public static string GetConnectionString()
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Student.mdb";
            //return "Provider=PostgreSQL OLE DB Provider;Data Source=127.0.0.1;Location=test;User ID=postgres;Password=zhangyi";
            //return "Data Source=127.0.0.1;Database=test;User ID=root;Password=zhangyi";
        }

        public static string GetConnectionString2()
        {
            //return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\\My Course\\数据库\\Student.mdb";
            //return "Provider=PostgreSQL OLE DB Provider;Data Source=127.0.0.1;Location=test;User ID=postgres;Password=zhangyi";
            return "Data Source=127.0.0.1;Database=new;User ID=root;Password=duhaode520;Charset=utf8";
        }

        //------------------------------------------------------------------------------------------
        //连接模式；通用OLE DB；查询数据
        //------------------------------------------------------------------------------------------
        public static OleDbDataReader ExecuteReader(string connectionStringStr, string sqlStr)
        {
            OleDbConnection cnn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;

            try
            {
                cnn = new OleDbConnection(connectionStringStr);
                cnn.Open();

                cmd = new OleDbCommand(sqlStr, cnn);
                dr = cmd.ExecuteReader();                

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }
           
            return dr;

        }

        //------------------------------------------------------------------------------------------
        //非连接模式；通用OLE DB；查询数据
        //------------------------------------------------------------------------------------------
        public static DataTable ExecuteQuery(string connectionString, string strSQL)
        {
            OleDbConnection cnn = new OleDbConnection(connectionString);
            DataTable dt = null;

            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(strSQL, cnn);
                DataSet ds = new DataSet();
                if (adapter.Fill(ds) > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception msg)
            {
                System.Console.WriteLine(msg.ToString());
                return dt;
            }

            cnn.Close();

            return dt;

        }

        //------------------------------------------------------------------------------------------
        //连接模式；通用OLE DB；非查询操作
        //------------------------------------------------------------------------------------------
        public static bool ExecuteNoQuery(string connectionStringStr, string sqlStr)
        {
            OleDbConnection cnn = null;
            OleDbCommand cmd = null; 
            
            try
            {
                cnn = new OleDbConnection(connectionStringStr);
                cnn.Open();

                cmd = new OleDbCommand(sqlStr, cnn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }

            return true;

        }

        //------------------------------------------------------------------------------------------
        //连接模式；MySQL OLE DB；查询操作
        //------------------------------------------------------------------------------------------
        public static MySqlDataReader ExecuteReader2(string connectionStringStr, string strSQL)
        {
            MySqlConnection cnn = null;
            MySqlCommand cmd = null;
            MySqlDataReader rst = null;

            try
            {
                cnn = new MySqlConnection(connectionStringStr);
                cnn.Open();

                cmd = new MySqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = strSQL;

                rst = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            //cnn.Close();
            return rst;

        }

        //------------------------------------------------------------------------------------------
        //连接模式；MySQL OLE DB；非查询操作
        //------------------------------------------------------------------------------------------
        public static bool ExecuteNoQuery2(string connectionStringStr, string sqlStr)
        {
            MySqlConnection cnn = null;
            MySqlCommand cmd = null;

            try
            {
                cnn = new MySqlConnection(connectionStringStr);
                cnn.Open();

                cmd = new MySqlCommand(sqlStr, cnn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }

            return true;

        }
    }

}

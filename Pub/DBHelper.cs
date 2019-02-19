using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;  //  注意引用 NEWTONSOFT
using System.Configuration;

namespace Pub
{
    public  class DBHelper
    {
        static string connection = ConfigurationManager.ConnectionStrings["Supervisory_SystemEntities"].ToString();
        //连接
        public static  SqlConnection GetConn (){
            
            return new SqlConnection(connection);
        }
        //执行添加删除修改
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            int i=cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        //查询首行首列
        public static object ExecuteScalar(string sql)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            object i = cmd.ExecuteScalar();
            conn.Close();
            return i;
        }
        //查询多行多列
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr=cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sdr; 
        }

        //查询多行多列
        public static DataTable GetDataTable(string sql)
        {
            SqlConnection conn = GetConn();
            SqlDataAdapter sda = new SqlDataAdapter(sql,conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        //引用 newtownsoft 后 去掉注释
        public static List<T> GetList<T>(string sql)
        {
            DataTable dt = GetDataTable(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }

    }
}

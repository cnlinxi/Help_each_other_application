using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rongYunWebApiSample.Common
{
    /// <summary>
    /// 数据库通用类
    /// </summary>
    public abstract class DBHelper
    {
        //数据库连接字符串
        private static readonly string conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        /// <summary>
        /// 获取初始化好的Command对象
        /// </summary>
        /// <param name="con">Connection对象</param>
        /// <param name="cmdText">执行的命令文本</param>
        /// <param name="type">命令类型</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>初始化好的Command对象</returns>
        private static SqlCommand PrepareCommand(SqlConnection con,string cmdText,CommandType type,SqlParameter[] parameters)
        {
            if(con.State!=ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = type;
            if(parameters!=null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parameters);
            }

            return cmd;
        }

        /// <summary>
        /// 执行SQL语句，并返回DataSet
        /// </summary>
        /// <param name="strSql">待执行的SQL语句</param>
        /// <returns></returns>
        public static DataSet ExcuteSqlDataSet(string strSql)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlDataAdapter sda = new SqlDataAdapter(strSql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// 执行带参数的SQL语句，并返回DataSet
        /// </summary>
        /// <param name="strSql">待执行的SQL语句</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static DataSet ExcuteSqlDataSet(string strSql,SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand sqlCmd = PrepareCommand(con, strSql, CommandType.Text, parameters);

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// 执行统计查询
        /// </summary>
        /// <param name="strSql">待执行的Sql语句</param>
        /// <returns>执行结果的第一行第一列的值</returns>
        public static object ExcuteSqlScalar(string strSql)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strSql, con);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 执行带参数统计查询
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>执行结果第一行第一列的值</returns>
        public static object ExcuteSqlScalar(string strSql,SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand sqlCmd = PrepareCommand(con, strSql, CommandType.Text, parameters);
                return sqlCmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 执行查询，并返回查询结果
        /// </summary>
        /// <param name="strSql">待查询语句</param>
        /// <returns>查询结果</returns>
        public static SqlDataReader ExecuteSqlReader(string strSql)
        {
            SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand(strSql, con);
                return cmd.ExecuteReader(CommandBehavior.Default);
        }

        /// <summary>
        /// 执行带参数查询，并返回查询结果
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteSqlReader(string strSql,SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(conString);
                SqlCommand sqlCmd = PrepareCommand(con, strSql, CommandType.Text, parameters);
                return sqlCmd.ExecuteReader(CommandBehavior.Default);
        }

        /// <summary>
        /// 执行非查询的Sql语句
        /// </summary>
        /// <param name="strSql">待执行的Sql语句</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string strSql)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strSql, con);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行非查询带参数的Sql语句
        /// </summary>
        /// <param name="strSql">待执行Sql语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string strSql,SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = PrepareCommand(con, strSql, CommandType.Text, parameters);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
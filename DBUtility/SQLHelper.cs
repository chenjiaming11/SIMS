using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBUtility
{
    public class SQLHelper
    {
        //从APP.Config文件中读取的连接字符串
        private static string connString = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();



        /// <summary>
        /// 执行一条SQL命令，返回受操作影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>受操作影响的行数</returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// 执行一条SQL命令，返回一个单一结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回一个Object类型的单一结果</returns>

        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行一条SQL命令，返回一个结果集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回一个SQLDataReader对象</returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }


        /// <summary>
        /// 执行一条SQL语句，返回受操作影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">SqlParameter数组</param>
        /// <returns>返回受操作影响的行数</returns>
        public static int Update(string sql,SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 执行一条SQL命令，返回一个单一结果（对象）
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <param name="param">SqlParameter数组</param>
        /// <returns>返回一个单一结果</returns>
        public static object GetSingleResult(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个结果集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">SqlParameter数组</param>
        /// <returns>返回一个SqlDataReader对象</returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

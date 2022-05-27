using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Common;

namespace DBUtility
{
    public class MsSqlHelper
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MSSQLCONN"].ToString();
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        public int DBUpdate(string sql, object obj)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Execute(sql, obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> DBGetAllData<T>(string sql)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Query<T>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> DBGetAllData<T>(string sql, T obj)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Query<T>(sql, obj).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(string tableName, string fields,string fieldsWithAt, object obj)
        {
            try
            {
                string sql = $"INSERT INTO {tableName} ({fields}) VALUES ({fieldsWithAt})";
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Execute(sql, obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(string tableName, string primaryKey, object obj)
        {
            try
            {
                string sql = $"DELETE FROM {tableName} WHERE {primaryKey}=@{primaryKey}";
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Execute(sql, obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(string tableName, string fieldsWithAtForUpdate, string primaryKey, object obj)
        {
            try
            {
                string sql = $"UPDATE {tableName} SET {fieldsWithAtForUpdate} WHERE {primaryKey}=@{primaryKey}";
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Execute(sql, obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> Select<T>(string tableName, string fields)
        {
            try
            {
                string sql = $"SELECT {fields} FROM {tableName}";
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Query<T>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> Select<T>(string tableName, string fields, string whereCondition, object obj)
        {
            try
            {
                string sql = $"SELECT {fields} FROM {tableName}";
                if (whereCondition != "")
                {
                    sql += " WHERE " + whereCondition;
                }
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Query<T>(sql, obj).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using Models;

namespace DAL
{
    /// <summary>
    /// BaseUser的数据访问类
    /// </summary>
    public class BaseUserService
    {
        public BaseUser UserLogin(BaseUser objBaseUser)
        {
            string sql = "SELECT BaseUserGUID,RealName,BaseUserName,BaseUserPwd,BaseUserStatus FROM BaseUser WHERE BaseUserName=@BaseUserName AND BaseUserPwd=@BaseUserPwd";
            SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@BaseUserName",objBaseUser.BaseUserName),
                    new SqlParameter("@BaseUserPwd",objBaseUser.BaseUserPwd)
                };
            SqlDataReader objReader = SQLHelper.GetReader(sql,param);
            if (objReader.Read())
            {
                BaseUser gotBaseUser = new BaseUser()
                {
                    BaseUserGUID = objReader["BaseUserGUID"].ToString(),
                    RealName = objReader["RealName"].ToString(),
                    BaseUserName = objReader["BaseUserName"].ToString(),
                    BaseUserPwd = objReader["BaseUserPwd"].ToString(),
                    BaseUserStatus = (int)objReader["BaseUserStatus"]
                };
                objReader.Close();
                return gotBaseUser;
            }
            else
            {
                return null;
            }
        }



        public int AddBaseUser(BaseUser objBaseUser)
        {
            string sql = "INSERT INTO BaseUser(BaseUserGUID,RealName,BaseUserName,BaseUserPwd,BaseUserStatus) VALUES (@BaseUserGUID,@RealName,@BaseUserName,@BaseUserPwd,@BaseUserStatus)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@BaseUserGUID",objBaseUser.BaseUserGUID),
                new SqlParameter("@RealName",objBaseUser.RealName),
                new SqlParameter("@BaseUserName",objBaseUser.BaseUserName),
                new SqlParameter("@BaseUserPwd",objBaseUser.BaseUserPwd),
                new SqlParameter("@BaseUserStatus",objBaseUser.BaseUserStatus)
            };
            return SQLHelper.Update(sql, param);
        }

        public int DeleteBaseUser(BaseUser objBaseUser)
        {
            string sql = "DELETE FROM BaseUser WHERE @BaseUserGUID=BaseUserGUID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@BaseUserGUID",objBaseUser.BaseUserGUID)
            };
            try
            {
                return SQLHelper.Update(sql, param);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new Exception("您要删除的数据主键值" + objBaseUser.BaseUserGUID + "已经被其他表引用");
                }
                else
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateBaseUser(BaseUser objBaseUser)
        {
            string sql = "UPDATE BaseUser SET RealName=@RealName,BaseUserName=@BaseUserName,BaseUserPwd=@BaseUserPwd,BaseUserStatus=@BaseUserStatus WHERE BaseUserGUID=BaseUserGUID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@BaseUserGUID",objBaseUser.BaseUserGUID),
                new SqlParameter("@RealName",objBaseUser.RealName),
                new SqlParameter("@BaseUserName",objBaseUser.BaseUserName),
                new SqlParameter("@BaseUserPwd",objBaseUser.BaseUserPwd),
                new SqlParameter("@BaseUserStatus",objBaseUser.BaseUserStatus)
            };
            return SQLHelper.Update(sql, param);
        }

        public List<BaseUser> GetAllBaseUser()
        {
            string sql = "SELECT BaseUserGUID,RealName,BaseUserName,BaseUserPwd,BaseUserStatus  FROM BaseUser";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<BaseUser> list = new List<BaseUser>();
            while (objReader.Read())
            {
                BaseUser objBaseUser = new BaseUser()
                {
                    BaseUserGUID = objReader["BaseUserGUID"].ToString(),
                    RealName = objReader["RealName"].ToString(),
                    BaseUserName = objReader["BaseUserName"].ToString(),
                    BaseUserPwd = objReader["BaseUserPwd"].ToString(),
                    BaseUserStatus = (int)objReader["BaseUserStatus"]
                };
                list.Add(objBaseUser);
            }
            objReader.Close();
            return list;
        }

        public int IsValueExist(string key, string value)
        {
            string sql = $"SELECT COUNT(*) FROM BaseUser WHERE {key}=@{key}";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter($"@{key}",value)
            };
            return (int)SQLHelper.GetSingleResult(sql, param);
        }

    }
}

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
    /// Subject的数据访问类
    /// </summary>
    public class SubjectService
    {
        public int AddSubject(Subject objSubject)
        {
            string sql="INSERT INTO Subject(SubjectGUID,SubjectName) VALUES (@SubjectGUID,@SubjectName)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SubjectGUID",objSubject.SubjectGUID),
                new SqlParameter("@SubjectName",objSubject.SubjectName)
            };
            return SQLHelper.Update(sql,param);
        }

        public int DeleteSubject(Subject objSubject)
        {
            string sql="DELETE FROM Subject WHERE @SubjectGUID=SubjectGUID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SubjectGUID",objSubject.SubjectGUID)
            };
            try
            {
                return SQLHelper.Update(sql,param);
            }
                catch (SqlException ex)
                {
                    if(ex.Number==547)
                    {
                        throw new Exception("您要删除的数据主键值" + objSubject.SubjectGUID + "已经被其他表引用");
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

        public int UpdateSubject(Subject objSubject)
        {
            string sql="UPDATE Subject SET SubjectName=@SubjectName WHERE SubjectGUID=SubjectGUID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SubjectGUID",objSubject.SubjectGUID),
                new SqlParameter("@SubjectName",objSubject.SubjectName)
            };
            return SQLHelper.Update(sql,param);
        }

        public List<Subject>GetAllSubject()
        {
            string sql="SELECT SubjectGUID,SubjectName  FROM Subject";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Subject>list = new List<Subject>();
            while(objReader.Read())
                {
                    Subject objSubject = new Subject()
                    {
                        SubjectGUID=objReader["SubjectGUID"].ToString(),
                        SubjectName=objReader["SubjectName"].ToString()
                    };
                list.Add(objSubject);
                }
            objReader.Close();
            return list;
        }

        public int IsValueExist(string key,string value)
        {
            string sql = $"SELECT COUNT(*) FROM Subject WHERE {key}=@{key}";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter($"@{key}",value)
            };
            return (int)SQLHelper.GetSingleResult(sql, param);
        }

    }
}

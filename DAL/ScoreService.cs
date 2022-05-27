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
    /// Score的数据访问类
    /// </summary>
    public class ScoreService
    {
        public int AddScore(Score objScore)
        {
            string sql="INSERT INTO Score(ScoreGUID,SubjectScore,ExamTime,StudentGUID,SubjectGUID) VALUES (@ScoreGUID,@SubjectScore,@ExamTime,@StudentGUID,@SubjectGUID)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ScoreGUID",objScore.ScoreGUID),
                new SqlParameter("@SubjectScore",objScore.SubjectScore),
                new SqlParameter("@ExamTime",objScore.ExamTime),
                new SqlParameter("@StudentGUID",objScore.StudentGUID),
                new SqlParameter("@SubjectGUID",objScore.SubjectGUID)
            };
            return SQLHelper.Update(sql,param);
        }

        public int DeleteScore(Score objScore)
        {
            string sql="DELETE FROM Score WHERE @ScoreGUID=ScoreGUID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ScoreGUID",objScore.ScoreGUID)
            };
            try
            {
                return SQLHelper.Update(sql,param);
            }
                catch (SqlException ex)
                {
                    if(ex.Number==547)
                    {
                        throw new Exception("您要删除的数据主键值" + objScore.ScoreGUID + "已经被其他表引用");
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

        public int UpdateScore(Score objScore)
        {
            string sql="UPDATE Score SET SubjectScore=@SubjectScore,ExamTime=@ExamTime,StudentGUID=@StudentGUID,SubjectGUID=@SubjectGUID WHERE ScoreGUID=ScoreGUID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ScoreGUID",objScore.ScoreGUID),
                new SqlParameter("@SubjectScore",objScore.SubjectScore),
                new SqlParameter("@ExamTime",objScore.ExamTime),
                new SqlParameter("@StudentGUID",objScore.StudentGUID),
                new SqlParameter("@SubjectGUID",objScore.SubjectGUID)
            };
            return SQLHelper.Update(sql,param);
        }

        public List<Score>GetAllScore()
        {
            string sql="SELECT ScoreGUID,SubjectScore,ExamTime,StudentGUID,SubjectGUID  FROM Score";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Score>list = new List<Score>();
            while(objReader.Read())
                {
                    Score objScore = new Score()
                    {
                        ScoreGUID=objReader["ScoreGUID"].ToString(),
                        SubjectScore=(decimal?)objReader["SubjectScore"],
                        ExamTime=(DateTime?)objReader["ExamTime"],
                        StudentGUID=objReader["StudentGUID"].ToString(),
                        SubjectGUID=objReader["SubjectGUID"].ToString()
                    };
                list.Add(objScore);
                }
            objReader.Close();
            return list;
        }

        public int IsValueExist(string key,string value)
        {
            string sql = $"SELECT COUNT(*) FROM Score WHERE {key}=@{key}";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter($"@{key}",value)
            };
            return (int)SQLHelper.GetSingleResult(sql, param);
        }

    }
}

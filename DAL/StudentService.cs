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
    /// Student的数据访问类
    /// </summary>
    public class StudentService
    {
        public int AddStudent(Student objStudent)
        {
            string sql="INSERT INTO Student(StudentGUID,StudentId,StudentPwd,StudentName,StudentGender,DateOfBirth,AdmissionDate,StudentIdCardNo) VALUES (@StudentGUID,@StudentId,@StudentPwd,@StudentName,@StudentGender,@DateOfBirth,@AdmissionDate,@StudentIdCardNo)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentGUID",objStudent.StudentGUID),
                new SqlParameter("@StudentId",objStudent.StudentId),
                new SqlParameter("@StudentPwd",objStudent.StudentPwd),
                new SqlParameter("@StudentName",objStudent.StudentName),
                new SqlParameter("@StudentGender",objStudent.StudentGender),
                new SqlParameter("@DateOfBirth",objStudent.DateOfBirth),
                new SqlParameter("@AdmissionDate",objStudent.AdmissionDate),
                new SqlParameter("@StudentIdCardNo",objStudent.StudentIdCardNo)
            };
            return SQLHelper.Update(sql,param);
        }

        public int DeleteStudent(Student objStudent)
        {
            string sql="DELETE FROM Student WHERE @StudentGUID=StudentGUID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentGUID",objStudent.StudentGUID)
            };
            try
            {
                return SQLHelper.Update(sql,param);
            }
                catch (SqlException ex)
                {
                    if(ex.Number==547)
                    {
                        throw new Exception("您要删除的数据主键值" + objStudent.StudentGUID + "已经被其他表引用");
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

        public int UpdateStudent(Student objStudent)
        {
            string sql="UPDATE Student SET StudentId=@StudentId,StudentPwd=@StudentPwd,StudentName=@StudentName,StudentGender=@StudentGender,DateOfBirth=@DateOfBirth,AdmissionDate=@AdmissionDate,StudentIdCardNo=@StudentIdCardNo WHERE StudentGUID=StudentGUID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentGUID",objStudent.StudentGUID),
                new SqlParameter("@StudentId",objStudent.StudentId),
                new SqlParameter("@StudentPwd",objStudent.StudentPwd),
                new SqlParameter("@StudentName",objStudent.StudentName),
                new SqlParameter("@StudentGender",objStudent.StudentGender),
                new SqlParameter("@DateOfBirth",objStudent.DateOfBirth),
                new SqlParameter("@AdmissionDate",objStudent.AdmissionDate),
                new SqlParameter("@StudentIdCardNo",objStudent.StudentIdCardNo)
            };
            return SQLHelper.Update(sql,param);
        }

        public List<Student>GetAllStudent()
        {
            string sql="SELECT StudentGUID,StudentId,StudentPwd,StudentName,StudentGender,DateOfBirth,AdmissionDate,StudentIdCardNo  FROM Student";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Student>list = new List<Student>();
            while(objReader.Read())
                {
                    Student objStudent = new Student()
                    {
                        StudentGUID=objReader["StudentGUID"].ToString(),
                        StudentId=objReader["StudentId"].ToString(),
                        StudentPwd=objReader["StudentPwd"].ToString(),
                        StudentName=objReader["StudentName"].ToString(),
                        StudentGender=objReader["StudentGender"].ToString(),
                        DateOfBirth=(DateTime?)objReader["DateOfBirth"],
                        AdmissionDate=(DateTime?)objReader["AdmissionDate"],
                        StudentIdCardNo=objReader["StudentIdCardNo"].ToString()
                    };
                list.Add(objStudent);
                }
            objReader.Close();
            return list;
        }

        public int IsValueExist(string key,string value)
        {
            string sql = $"SELECT COUNT(*) FROM Student WHERE {key}=@{key}";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter($"@{key}",value)
            };
            return (int)SQLHelper.GetSingleResult(sql, param);
        }

    }
}

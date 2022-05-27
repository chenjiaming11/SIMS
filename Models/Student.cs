using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Student的实体类
    /// </summary>
    [Serializable]
    public class Student
    {
        public string StudentGUID { get; set; }
        public string StudentId { get; set; }
        public string StudentPwd { get; set; }
        public string StudentName { get; set; }
        public string StudentGender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string StudentIdCardNo { get; set; }
    }
}

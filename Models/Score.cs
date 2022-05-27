using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Score的实体类
    /// </summary>
    [Serializable]
    public class Score
    {
        public string ScoreGUID { get; set; }
        public decimal? SubjectScore { get; set; }
        public DateTime? ExamTime { get; set; }
        public string StudentGUID { get; set; }
        public string SubjectGUID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Subject的实体类
    /// </summary>
    [Serializable]
    public class Subject
    {
        public string SubjectGUID { get; set; }
        public string SubjectName { get; set; }
    }
}

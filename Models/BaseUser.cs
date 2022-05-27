using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// BaseUser的实体类
    /// </summary>
    [Serializable]
    public class BaseUser
    {
        public string BaseUserGUID { get; set; }
        public string RealName { get; set; }
        public string BaseUserName { get; set; }
        public string BaseUserPwd { get; set; }
        public int BaseUserStatus { get; set; }
    }
}

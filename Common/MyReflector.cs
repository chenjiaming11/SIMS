using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace Common
{
    public class MyReflector
    {
        public static string GetPK(Type type)
        {
            PropertyInfo[] propertyInfo = type.GetProperties();
            string pk = "";
            foreach (PropertyInfo info in propertyInfo)
            {
                foreach (Attribute attribute in info.GetCustomAttributes())
                {
                    if (attribute.ToString().Contains("PKAttribute"))
                    {
                        pk = info.Name;
                    }
                }
            }
            return pk;
        }


        public static List<string> GetFields(Type type, string[] needToRemove)
        {
            List<string> listFields = (type.GetProperties()).Select(info => info.Name).ToList();
            if (needToRemove != null)
            {
                foreach (var item in needToRemove)
                {
                    listFields.Remove(item);
                }
            }
            return listFields;
        }

        public static List<string> GetFieldsArr(Type type, string[] needToRemove)
        {
            //创建集合
            List<string> listStr = new List<string>();
            //获取主键并添加进集合
            listStr.Add(GetPK(type));
            //获取类的所有属性
            List<string> listFields = (type.GetProperties()).Select(info => info.Name).ToList();
            //按需移除字段
            if (needToRemove != null)
            {
                foreach (var item in needToRemove)
                {
                    listFields.Remove(item);
                }
            }
            //拼接普通字段并添加进集合
            listStr.Add(string.Join(",", listFields));
            //让普通字段带上@符号并加进集合
            List<string> listFieldsWithAt = new List<string>();
            foreach (var item in listFields)
            {
                listFieldsWithAt.Add("@" + item);
            }
            listStr.Add(string.Join(",", listFieldsWithAt));
            //拼接 字段=@字段 格式的字符串并加入集合
            List<string>listFieldsWithAtForUpdate = new List<string>();
            foreach (var item in listFields)
            {
                listFieldsWithAtForUpdate.Add(item + "=@" + item);
            }
            listStr.Add(string.Join(",", listFieldsWithAtForUpdate));

            return listStr;
        }
    }
}

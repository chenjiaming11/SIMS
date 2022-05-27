using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//引入三个命名空间
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Common
{
    public class SerializeObject
    {
        //将Object类型对象(注：必须是可序列化的对象)转换为二进制序列字符串
        public string SerializeObj(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            string result = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                byte[] byt = new byte[stream.Length];
                byt = stream.ToArray();
                //result = Encoding.UTF8.GetString(byt, 0, byt.Length);
                result = Convert.ToBase64String(byt);
                stream.Flush();
            }
            return result;
        }
        //将二进制序列字符串转换为Object类型对象
        public T DeserializeObj<T>(string str)
        {
            IFormatter formatter = new BinaryFormatter();
            //byte[] byt = Encoding.UTF8.GetBytes(str);
            byte[] byt = Convert.FromBase64String(str);
            T obj;
            using (Stream stream = new MemoryStream(byt, 0, byt.Length))
            {
                obj = (T)formatter.Deserialize(stream);
            }
            return obj;
        }

        public void SerializeObjToLocal(object obj, string fileName)
        {
            //创建文件流
            FileStream fs = new FileStream(fileName,FileMode.Create);
            //创建二进制格式化器
            BinaryFormatter formatter = new BinaryFormatter();
            //调用序列化方法
            formatter.Serialize(fs,obj);
            //关闭文件流
            fs.Close();
        }

        public T DeSerializeObjFromLocal<T>(string fileName)
        {
            //创建文件流
            FileStream fs = new FileStream(fileName, FileMode.Open);
            //创建二进制格式化器
            BinaryFormatter formatter = new BinaryFormatter();
            //调用反序列化方法
            T obj = (T)formatter.Deserialize(fs);
            //关闭文件流
            fs.Close();
            return obj;
        }
    }
}

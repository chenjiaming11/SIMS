using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Encryptions
    {
        public string GetMd5x(string inputStr)
        {
            //创建MD5对象
            MD5 md5 = MD5.Create();
            //先将字符串转换成字节数组，再开始加密
            byte[] buffer = Encoding.Default.GetBytes(inputStr);
            byte[] Md5Buffer = md5.ComputeHash(buffer);
            //将字节数组转换成字符串
            string str = "";
            for (int i = 0; i < Md5Buffer.Length; i++)
            {
                str += Md5Buffer[i].ToString("x");
            }
            return str;
        }


        public string GetMd5x2(string inputStr)
        {
            //创建MD5对象
            MD5 md5 = MD5.Create();
            //先将字符串转换成字节数组，再开始加密
            byte[] buffer = Encoding.Default.GetBytes(inputStr);
            byte[] Md5Buffer = md5.ComputeHash(buffer);
            //将字节数组转换成字符串
            string str = "";
            for (int i = 0; i < Md5Buffer.Length; i++)
            {
                str += Md5Buffer[i].ToString("x2");
            }
            return str;
        }


        /// <summary>  
        /// C# DES加密方法  
        /// </summary>  
        /// <param name="encryptedValue">要加密的字符串</param>  
        /// <param name="key">密钥</param>  
        /// <param name="iv">向量</param>  
        /// <returns>加密后的字符串</returns>  
        public string DESEncrypt(string originalValue, string key, string iv)
        {
            using (DESCryptoServiceProvider sa
                = new DESCryptoServiceProvider { Key = Encoding.UTF8.GetBytes(key), IV = Encoding.UTF8.GetBytes(iv) })
            {
                using (ICryptoTransform ct = sa.CreateEncryptor())
                {
                    byte[] by = Encoding.UTF8.GetBytes(originalValue);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            cs.Write(by, 0, by.Length);
                            cs.FlushFinalBlock();
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }


        /// <summary>  
        /// C# DES解密方法  
        /// </summary>  
        /// <param name="encryptedValue">待解密的字符串</param>  
        /// <param name="key">密钥</param>  
        /// <param name="iv">向量</param>  
        /// <returns>解密后的字符串</returns>  
        public string DESDecrypt(string encryptedValue, string key, string iv)
        {
            using (DESCryptoServiceProvider sa =
                new DESCryptoServiceProvider
                { Key = Encoding.UTF8.GetBytes(key), IV = Encoding.UTF8.GetBytes(iv) })
            {
                using (ICryptoTransform ct = sa.CreateDecryptor())
                {
                    byte[] byt = Convert.FromBase64String(encryptedValue);

                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            cs.Write(byt, 0, byt.Length);
                            cs.FlushFinalBlock();
                        }
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }
    }
}

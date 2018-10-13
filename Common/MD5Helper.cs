using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Common
{
    /// <summary>
    /// MD5帮助类
    /// </summary>
    public static class MD5Helper
    {
        private static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        /// <summary>
        /// 获取文件的MD5值
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileMD5(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open);
            byte[] retval = md5.ComputeHash(file);
            
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retval.Length; i++)
            {
                sb.Append(retval[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static string GetBytesMD5(byte[] buffer) {
            byte[] retval = md5.ComputeHash(buffer);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retval.Length; i++)
            {
                sb.Append(retval[i].ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取字符串的md5值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStringMD5(string str) {
            byte[] bt = Encoding.UTF8.GetBytes(str);
            return GetBytesMD5(bt);
        }
    }
}

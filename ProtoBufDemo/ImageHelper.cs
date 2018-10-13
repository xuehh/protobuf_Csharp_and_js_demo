using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace ProtoBufDemo
{
    public static class ImageHelper
    {
        /// <summary>
        /// 将byte数组保存成图片：
        /// 方式一：
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static bool SaveFromBufferExistFile(byte[] buffer, string path)
        {
            if (File.Exists(path))
            {
                File.WriteAllBytes(path, buffer);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 将byte数组保存成图片：
        /// 方式二：
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SaveFromBufferOpenOrCreate(byte[] buffer, string path)
        {


            //MemoryStream ms=new MemoryStream(Byte[] b);  //把那个byte[]数组传进去,然后
            MemoryStream ms = new MemoryStream(buffer);  //把那个byte[]数组传进去,然后
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            ms.WriteTo(fs);
            
            ms.Close();
            fs.Close();
            

            return "";
        }
    }
}
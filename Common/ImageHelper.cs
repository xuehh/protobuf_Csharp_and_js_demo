using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
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
        ///// <summary>
        ///// 方法三：
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="path"></param>
        ///// <returns></returns>
        //public static string SaveFromBuffer(byte[] buffer, string path)
        //{
        //    //得到图片地址
        //    var stringFilePath = context.Server.MapPath(string.Format("~/Image/{0}{1}.jpg", imageName, id));
        //    //声明一个FileStream用来将图片暂时放入流中
        //    FileStream stream = new FileStream(stringFilePath, FileMode.Open);
        //    using (stream)
        //    {
        //        //透过GetImageFromStream方法将图片放入byte数组中
        //        byte[] imageBytes = this.GetImageFromStream(stream, context);
        //        //上下文确定写到客户短时的文件类型
        //        context.Response.ContentType = "image/jpeg";
        //        //上下文将imageBytes中的数据写到前段
        //        context.Response.BinaryWrite(imageBytes);
        //        stream.Close();
        //    }

        //}

    }
}

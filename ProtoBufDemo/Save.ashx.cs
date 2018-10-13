using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.ProtocolBuffers;
using System.IO;


namespace ProtoBufDemo
{
    /// <summary>
    /// Save 的摘要说明
    /// </summary>
    public class Save : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {


            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(context.Request.InputStream))
            {
                fileData = binaryReader.ReadBytes(Convert.ToInt32(context.Request.InputStream.Length));
            }
            PersonTest per = PersonTest.ParseFrom(fileData);//反序列化为对象
            string filename = per.Name;
            Google.ProtocolBuffers.ByteString str = per.Buf;
            string path = context.Server.MapPath(filename);
            if (per.Isimg)
            {
                ImageHelper.SaveFromBufferOpenOrCreate(str.ToByteArray(), path);//保存图片操作
            }
            else
            {
                FileHelper.SaveFile(str.ToByteArray(), path);//保存图片操作
            }
            var builder = per.ToBuilder();

            builder.SetName(per.Name);
            builder.SetEmail(per.Email);
            builder.SetId(1001);
            builder.SetIsimg(false);
            
            ByteString bs=ByteString.CopyFrom("ok",System.Text.Encoding.UTF8);
            builder.SetBuf(bs);


            per = builder.Build();

            context.Response.ContentType = "application/protobuf";
            context.Response.BinaryWrite(per.ToByteArray());


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ProtoBufDemo
{
    public static class FileHelper
    {
        public static void SaveFile(byte[] buffer, string path)
        {

            FileStream fs = File.Create(path);
            fs.Write(buffer, 0, buffer.Length);
            fs.Dispose();
            fs.Close();
        }
    }
}
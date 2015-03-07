using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;
using System.Text;

namespace NeemoAdmin.SupportClasses
{
    public class Common
    {        
        public static int MaximumPhotos {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["MaximumPhotos"].ToString() == "" ? "0" : ConfigurationManager.AppSettings["MaximumPhotos"].ToString());
            }             
        }
        public static double Maximumsize
        { 
            get
            {
                return Convert.ToDouble(ConfigurationManager.AppSettings["MaximumPhotos"].ToString() == "" ? "0" : ConfigurationManager.AppSettings["MaximumPhotos"].ToString());
            }
        }
        public static string FileLocation {
            get
            {
                return ConfigurationManager.AppSettings["FileLocation"].ToString();
            }            
        }

        public static string FileLocationMAP
        {
            get
            {
                return ConfigurationManager.AppSettings["FileLocationMAP"].ToString();
            }
        }

        public static string ThumbnailFileLocation {
            get
            {
                return ConfigurationManager.AppSettings["ThumbnailFileLocation"].ToString();
            }            
        }

        public static string ThumbnailFileLocationMAP
        {
            get
            {
                return ConfigurationManager.AppSettings["ThumbnailFileLocationMAP"].ToString();
            }
        }
        public static string ContentType
        {
            get
            {
                return ConfigurationManager.AppSettings["ContentType"].ToString();
            }
        }
        public static string GenerateRandomCode(int length)
        {
            string charPool = "ABCDEFGOPQRSTUVWXY1234567890ZabcdefghijklmHIJKLMNnopqrstuvwxyz1234567890";
            StringBuilder rs = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                rs.Append(charPool[(int)(random.NextDouble() * charPool.Length)]);
            }
            return rs.ToString();
        }
        public static string Validate(HttpFileCollection file)
        {
            for (int i = 0; i < file.Count; i++)
            {
                string error = "";
                if (!ContentType.Split(',').Contains(file[i].ContentType))
                {
                    error += "Wrong FileType! Upload only " + ContentType + " ";
                }
                if (file[i].InputStream.Length > ((Maximumsize * 1024) * 1024))
                {
                    error += "maxFileSize" + ((Maximumsize * 1024) * 1024) + " MB ";
                }
                if (error != "")
                {
                    return error;
                }
            }
            return "sucess";
        }
    }
}
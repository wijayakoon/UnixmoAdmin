using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using Neemo.Admin.SupportClasses;

namespace Neemo
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            string ControlsId = "";
            if (HttpContext.Current.Request.QueryString["id"] == null)
            {
                return;
            }
            else
            {
                ControlsId = HttpContext.Current.Request.QueryString["id"].ToString();
            }
            string msg = Common.Validate(context.Request.Files);
            if (msg == "sucess")
            {
                var r = new System.Collections.Generic.List<ViewDataUploadFilesResult>();
                var o = new System.Collections.Generic.List<ViewsessionUploadFilesResult>();
                context.Response.ContentType = "text/plain";//"application/json";
                if (context.Session[ControlsId + "uploadedfiles"] == null)
                {
                    o = new System.Collections.Generic.List<ViewsessionUploadFilesResult>();
                }
                else
                {
                    o = (System.Collections.Generic.List<ViewsessionUploadFilesResult>)context.Session[ControlsId + "uploadedfiles"];
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                int i = 0;
                foreach (string file in context.Request.Files)
                {
                    HttpPostedFile hpf = context.Request.Files[file] as HttpPostedFile;
                    string FileName = string.Empty;
                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                    {
                        string[] files = hpf.FileName.Split(new char[] { '\\' });
                        FileName = files[files.Length - 1];
                    }
                    else
                    {
                        FileName = hpf.FileName;
                    }
                    if (hpf.ContentLength == 0)
                        continue;

                    string randomno = Common.GenerateRandomCode(4);
                    GenerateThumbnails(0.5, hpf.InputStream, HttpContext.Current.Server.MapPath("~/" + Common.ThumbnailFileLocation + "/" + randomno + "_" + FileName));
                    string savedFileName = HttpContext.Current.Server.MapPath("~/" + Common.FileLocation + "/" + randomno + "_" + FileName);
                    hpf.SaveAs(savedFileName);

                    r.Add(new ViewDataUploadFilesResult()
                    {
                        Name = FileName,
                        Length = hpf.ContentLength,
                        Type = hpf.ContentType
                    });
                    o.Add(new ViewsessionUploadFilesResult()
                    {
                        Thumbnail_url = randomno + "_" + FileName,
                        Name = randomno + "_" + FileName,
                        Length = hpf.ContentLength,
                        Type = hpf.ContentType,
                        ImgListID = i,
                        IsDefault = false,
                        IsHaveImg = true
                    });
                    int count = 0;
                    foreach (ViewsessionUploadFilesResult objUploadFilesResult in o)
                    {
                        if (context.Session[ControlsId + "uploadedfiles"] == null)
                        {
                            if (count == 0)
                            {
                                objUploadFilesResult.IsDefault = true;
                            }
                        }
                        objUploadFilesResult.ImgListID = count;
                        count++;
                    }
                    var uploadedFiles = new
                    {
                        files = r.ToArray()
                    };
                    i++;
                    context.Session[ControlsId+"uploadedfiles"] = o;
                    var jsonObj = js.Serialize(uploadedFiles);
                    context.Response.Write(jsonObj.ToString());

                }
            }
            else
            {
                var r = new System.Collections.Generic.List<ViewDataUploadFilesResult>();
                r.Add(new ViewDataUploadFilesResult()
                {
                    Name = msg,
                    Length = 0,
                    Type = ""
                });
                var uploadedFiles = new
                {
                    files = r.ToArray()
                };
                JavaScriptSerializer js = new JavaScriptSerializer();
                var jsonObj = js.Serialize(uploadedFiles);
                context.Response.Write(jsonObj.ToString());
            }
        }
        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }
        public class ViewDataUploadFilesResult
        {
            public string Thumbnail_url { get; set; }
            public string Name { get; set; }
            public int Length { get; set; }
            public string Type { get; set; }            
        }
        public class ViewsessionUploadFilesResult
        {
            public string Thumbnail_url { get; set; }
            public string Name { get; set; }
            public int Length { get; set; }
            public string Type { get; set; }
            public int ImgListID { get; set; }
            public bool IsHaveImg { get; set; }
            public bool IsDefault { get; set; }
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
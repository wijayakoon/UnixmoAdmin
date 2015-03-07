using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.IO.Compression;
using System.IO;

namespace Neemo.Admin.SupportClasses
{
    public class PhotoUpload : System.Web.UI.Page
    {

        #region PhotoUpload
        // Processes click on our cmdSend button
        public Image UploadNewImages(FileUpload fup, Image img, string ImagePath, string productName)
        {
            string filename = ImagePath + ValidatefileName(productName) + "_";
            ImagePath = filename + ValidatefileName(fup.FileName);
            return UploadImage(fup, img, filename);          

        }

       
        //Add New Images
        public Image UploadImage(FileUpload filMyFile, Image imgFile, string FilePreFix)
        {
            // Check to see if file was uploaded
            if (filMyFile.PostedFile != null)
            {
                // Get a reference to PostedFile object
                HttpPostedFile myFile = filMyFile.PostedFile;

                // Get size of uploaded file
                int nFileLen = myFile.ContentLength;

                // make sure the size of the file is > 0
                if (nFileLen > 0)
                {
                    // Allocate a buffer for reading of the file
                    byte[] myData = new byte[nFileLen];

                    // Read uploaded file from the Stream
                    myFile.InputStream.Read(myData, 0, nFileLen);

                    // Create a name for the file to store
                    string strFilename = Path.GetFileName(myFile.FileName);

                    // Write data into a file
                    strFilename = FilePreFix + strFilename;
                    WriteToFile(Server.MapPath(strFilename), ref myData);

                    // Set URL of the the object to point to the file we've just saved
                    imgFile.ImageUrl = strFilename;
                    imgFile.Visible = true;
                   
                    imgFile.Visible = true;
                }
                
            }
            return imgFile;
        }

        public void UploadImage(FileUpload filMyFile, string FilePreFix)
        {
            // Check to see if file was uploaded
            if (filMyFile.PostedFile != null)
            {
                // Get a reference to PostedFile object
                HttpPostedFile myFile = filMyFile.PostedFile;

                // Get size of uploaded file
                int nFileLen = myFile.ContentLength;

                // make sure the size of the file is > 0
                if (nFileLen > 0)
                {
                    // Allocate a buffer for reading of the file
                    byte[] myData = new byte[nFileLen];

                    // Read uploaded file from the Stream
                    myFile.InputStream.Read(myData, 0, nFileLen);

                    // Create a name for the file to store
                    string strFilename = Path.GetFileName(myFile.FileName);

                    // Write data into a file
                    strFilename = FilePreFix + strFilename;
                    WriteToFile(Server.MapPath(strFilename), ref myData);

                }
            }
        }

        private string ValidatefileName(string fileName)
        {
            fileName.Replace(" ", "_");
            fileName.Replace("/", "_");
            fileName.Replace("~", "_");
            fileName.Replace("!", "_");
            fileName.Replace("@", "_");
            fileName.Replace("#", "_");
            fileName.Replace("$", "_");
            fileName.Replace("%", "_");
            fileName.Replace("^", "_");
            fileName.Replace("&", "_");
            fileName.Replace("*", "_");
            fileName.Replace("+", "_");
            fileName.Replace("=", "_");
            fileName.Replace("|", "_");
            fileName.Replace(@"\", "_");
            fileName.Replace("'", "_");
            fileName.Replace(">", "_");
            fileName.Replace("<", "_");
            fileName.Replace(":", "_");
            fileName.Replace(";", "_");
            fileName.Replace(",", "_");
            return fileName;
        }
        
       

        // Writes file to current folder
        private void WriteToFile(string strPath, ref byte[] Buffer)
        {
            // Create a file
            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Write data to the file
            newFile.Write(Buffer, 0, Buffer.Length);

            // Close file
            newFile.Close();
        }
        #endregion
    }
}
using Firebase1.Database;
using Firebase1.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static Firebase1.Database.ContentType;

namespace Firebase1.Storage
{
    public class Child
    {
        private string url, path;
        private static readonly string EXT = "o?uploadType=media&name=";
        public Child(string url, string path)
        {
            this.url = url;
            if (path != "" && !path.EndsWith("/"))
                path += "/";
            this.path = path.Replace("/", "%2F");
        }

        #region Image

        public void UploadImage(string imagePath, string name, ImageFormat format)
        {
            UploadImage(System.Drawing.Image.FromFile(imagePath), name, format);
        }

        public void UploadImage(System.Drawing.Image image, string name, ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            string contentType = Video.RAW;
            if (format == ImageFormat.Gif)
                contentType = ContentType.Image.GIF;
            else if (format == ImageFormat.Png)
                contentType = ContentType.Image.PNG;
            else if (format == ImageFormat.Jpeg)
                contentType = ContentType.Image.JPG;
            else if (format == ImageFormat.Tiff)
                contentType = ContentType.Image.TIFF;
            else if (format == ImageFormat.Bmp)
                contentType = ContentType.Image.BMP;

            Utils.PostRequest(GenerateUploadLink(name), RequestType.POST, contentType, ms.ToArray());
        }

        #endregion

        #region File

        public void UploadFile(byte[] bytes, string name)
        {
            Utils.PostRequest(GenerateUploadLink(name), RequestType.POST, Application.TEXT, bytes);
        }

        #endregion

        public byte[] GetFile(string name)
        {
            string s = Utils.PostRequest(GenerateGetLink(name), RequestType.GET, ContentType.Application.JSON, "");
            StorageFileData fileData = JsonConvert.DeserializeObject<StorageFileData>(s);
            return Utils.DownloadFile(GenerateDownloadLink(fileData));
        }


        public void Delete()
        {
            Utils.PostRequest(url, RequestType.DELETE, ContentType.Application.JSON, "");
        }

        private string GenerateUploadLink(string name)
        {
            if (path == "")
                return url + "o?uploadType=media&name=" + name;
            return url + "o/" + path + name;
        }

        private string GenerateGetLink(string name)
        {
            //Gets the json with the download token(needed!)
            if (path == "")
                return url + "o/" + name;
            return url + "o/" + path + name;
        }

        private string GenerateDownloadLink(StorageFileData data)
        {
            string path = data.Name.Substring(data.Name.LastIndexOf("/") + 1);
            return GenerateGetLink(path) + "?alt=media&token=" + data.DownloadTokens;
        }
    }
}

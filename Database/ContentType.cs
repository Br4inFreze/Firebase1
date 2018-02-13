using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Database
{
    public class ContentType
    {
        public static readonly string EMPTY = "";

        public static class Image
        {
            public static readonly string PNG = "image/png";
            public static readonly string GIF = "image/gif";
            public static readonly string BMP = "image/bmp";
            public static readonly string JPG = "image/jpeg";
            public static readonly string TIFF = "images/tiff";
        }

        public static class Audio
        {
            public static readonly string _3GPP = "audio/3gpp";
            public static readonly string ogg = "audio/ogg";
            public static readonly string MP3 = "audio/mpeg";
            public static readonly string WAV = "audio/wav";
        }

        public static class Video
        {
            public static readonly string MP4 = "video/mp4";
            public static readonly string AVI = "video/avi";
            public static readonly string RAW = "video/raw";
        }


        public static class Application
        {
            public static readonly string JSON = "application/json";
            public static readonly string TEXT = "text/plain";
            public static readonly string OCTET_STREAM = "application/octet-stream";
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Storage
{
    public class StorageFileData
    {
        public string Name { get; set; }
        public string Bucket { get; set; }
        public string Generation { get; set; }
        public string Metageneration { get; set; }
        public string ContentType { get; set; }
        public string TimeCreated { get; set; }
        public string Updated { get; set; }
        public string StorageClass { get; set; }
        public string Size { get; set; }
        public string Md5Hash { get; set; }
        public string ContentEncoding { get; set; }
        public string Crc32c { get; set; }
        public string Etag { get; set; }
        public string DownloadTokens { get; set; }
    }
}

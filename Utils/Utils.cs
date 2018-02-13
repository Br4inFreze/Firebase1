using Firebase1.Database;
using Firebase1.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Utilities
{
    internal static class Utils
    {
        #region PostRequest
        public static string PostRequest(string url, RequestType type, string contentType, string data = "")
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = type.ToString();

                if (data != "")
                {
                    httpWebRequest.ContentLength = data.Length;
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(data);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return result;
            }
            catch (WebException ex)
            {
                using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    //Handle invalid path
                    string result = streamReader.ReadToEnd();
                    Debug.WriteLine(result);
                    if (result.Contains("Permission denied"))
                        throw new PermissionDeniedException("Permission denied");
                    ErrorDetails error = JsonConvert.DeserializeObject<ErrorDetails>(result);
                    if (error.error.message.Equals("EMAIL_NOT_FOUND"))
                        throw new EmailNotExistException("Email not existing");
                    else if (error.error.message.Equals("INVALID_PASSWORD") || error.error.message.Equals("MISSING_PASSWORD"))
                        throw new IncorrentPasswordException("Wrong password");
                    else if (error.error.message.Equals("INVALID_EMAIL"))
                        throw new InvalidEmailException("Bad Email");
                    else
                        throw ex;
                }
            }

        }

        public static string PostRequest(string url, RequestType type, string contentType, byte[] data = null)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = type.ToString();

                if (data != null && data.Length != 0)
                {
                    httpWebRequest.ContentLength = data.Length;
                    using (var streamWriter = new BinaryWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(data);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                //if(httpWebRequest.Status)
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return result;
            }
            catch (WebException ex)
            {
                using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (result.Contains("Permission denied"))
                        throw new PermissionDeniedException("Permission denied");
                    ErrorDetails error = JsonConvert.DeserializeObject<ErrorDetails>(result);
                    if (error.error.message.Equals("EMAIL_NOT_FOUND"))
                        throw new EmailNotExistException("Email not existing");
                    else if (error.error.message.Equals("INVALID_PASSWORD") || error.error.message.Equals("MISSING_PASSWORD"))
                        throw new IncorrentPasswordException("Wrong password");
                    else if (error.error.message.Equals("INVALID_EMAIL"))
                        throw new InvalidEmailException("Bad Email");
                    else
                        throw ex;
                }
            }

        }
        #endregion

        public static byte[] DownloadFile(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }
}

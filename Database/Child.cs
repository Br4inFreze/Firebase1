using Firebase1.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Firebase1.Utilities;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Database
{
    public class Child
    {
        private string url;
        private static readonly string JSON_AUTH_EXT = ".json?auth=";
        private static readonly string JSON_EXT = ".json";
        private bool isUsingAuth = false;
        private string authKey = "";

        public Child(Firebase firebase, string path)
        {
            this.url = firebase.URL + path;
        }

        public Child WithAuth(string authKey)
        {
            isUsingAuth = true;
            this.authKey = authKey;
            return this;
        }

        public Child IChild(string url)
        {
            url += "/" + url;
            return this;
        }

        public JObject Get()
        {
            return Get<JObject>();
        }

        public T Get<T>()
        {
            string result = isUsingAuth ? Utils.PostRequest(url + JSON_AUTH_EXT + authKey, RequestType.GET, ContentType.Application.JSON, "") : Utils.PostRequest(url + JSON_EXT, RequestType.GET, ContentType.Application.JSON, "");
            T obj = JsonConvert.DeserializeObject<T>(result);
            isUsingAuth = false;
            return obj;
        }

        public void Push(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            //The correct method for posting data is to use the RequestType.POST but RequestType.PATCH isnt posting a generated id,but posting the data directly into the child
            string result = (isUsingAuth) ? Utils.PostRequest(url + JSON_AUTH_EXT + authKey, RequestType.PATCH, ContentType.Application.JSON, json) : Utils.PostRequest(url + JSON_EXT, RequestType.PATCH, ContentType.Application.JSON, json);
            isUsingAuth = false;
        }

        public UniqueID PushUniqueID(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            string result = (isUsingAuth) ? Utils.PostRequest(url + JSON_AUTH_EXT + authKey, RequestType.POST, ContentType.Application.JSON, json) : Utils.PostRequest(url + JSON_EXT, RequestType.POST, ContentType.Application.JSON, json);
            isUsingAuth = false;
            return JsonConvert.DeserializeObject<UniqueID>(result);
        }

        public void Update(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            if (isUsingAuth) Utils.PostRequest(url + JSON_AUTH_EXT + authKey, RequestType.PATCH, ContentType.Application.JSON, json); else Utils.PostRequest(url + JSON_EXT, RequestType.PATCH, ContentType.Application.JSON, json);
            isUsingAuth = false;
        }

        public void Delete()
        {
            if (isUsingAuth) Utils.PostRequest(url + JSON_AUTH_EXT + authKey, RequestType.DELETE, ContentType.Application.JSON, ""); else Utils.PostRequest(url + JSON_EXT, RequestType.DELETE, ContentType.Application.JSON, "");
            isUsingAuth = false;
        }
    }
}

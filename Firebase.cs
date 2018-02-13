using Firebase1.Auth;
using Firebase1.Database;
using Newtonsoft.Json;
using Firebase1.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;
using Firebase1.GoogleServiceFile;

namespace Firebase1
{
    public class Firebase
    {

        #region Properties

        private string url;
        private string apiKey;
        private Storage.Storage storage;
        private AuthManager auth;

        #endregion

        #region Constructor

        public static Firebase GetInstance(string file)
        {
            return new Firebase(file);
        }

        public static Firebase GetInstance(string id, string api)
        {
            return new Firebase(id, api);
        }

        public Firebase(string file)
        {
            GSFile gsFile = JsonConvert.DeserializeObject<GSFile>(File.ReadAllText(file));
            string apiKey = gsFile.client[0].api_key[0].current_key;
            string id = gsFile.project_info.project_id;
            Init(id, apiKey);
        }

        public Firebase(string id, string apiKey)
        {
            Init(id, apiKey);
        }

        public void Init(string id, string apiKey)
        {
            this.url = "https://" + id + ".firebaseio.com/";
            this.apiKey = apiKey;
            storage = new Storage.Storage(id);

            auth = new AuthManager(apiKey);

        }

        #endregion

        #region Accessors

        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        public Storage.Storage Storage
        {
            get { return storage; }
        }

        public AuthManager Auth
        {
            get { return auth; }
        }

        #endregion

        #region Methods

        public Child Child(string path)
        {
            return new Child(this, path);
        }


        #endregion


    }
}

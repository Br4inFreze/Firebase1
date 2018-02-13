using Firebase1.Database;
using Firebase1.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Auth
{
    public class AuthManager
    {
        private static readonly string LOGIN_URL = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=";
        private static readonly string REGISTER_URL = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=";
        private User user;
        private string apiKey;

        public AuthManager(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public User LoginWithPassword(string email, string password)
        {
            string result = Utils.PostRequest(LOGIN_URL + apiKey, RequestType.POST, ContentType.Application.JSON, "{email: \"" + email + "\",password: \"" + password + "\",returnSecureToken: true}");
            return user = JsonConvert.DeserializeObject<User>(result);
        }

        public User Register(string email, string password)
        {
            string result = Utils.PostRequest(REGISTER_URL + apiKey, RequestType.POST, ContentType.Application.JSON, "{email: \"" + email + "\",password: \"" + password + "\",returnSecureToken: true}");
            return user = JsonConvert.DeserializeObject<User>(result);
        }


        public enum LoginProviders
        {
            Password,
            Facebook,
            Github,
            Anonymous,
            Google,
            Twitter
        }

    }
}

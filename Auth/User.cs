using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.Auth
{
    public class User
    {
        private string kind;
        private string localId;
        private string email;
        private string displayName;
        private string idToken;
        private bool registered;
        private string refreshToken;
        private int expiresIn;
        private string accessToken = "";
        private static string secret = "";

        public string AcessToken
        {
            get
            {
                if (accessToken == "" && localId != null && secret != null)
                {
                    var tokenGenerator = new TokenGenerator(secret);
                    var authPayload = new Dictionary<string, object>()
                    {
                        { "uid", localId },
                        { "provider", "password" }
                    };
                    string token = tokenGenerator.CreateToken(authPayload);
                }
                return accessToken;
            }
        }

        public string Kind
        {
            get { return kind; }
            set { kind = value; }
        }
        public string LocalId
        {
            get { return localId; }
            set { localId = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        public string IdToken
        {
            get { return idToken; }
            set { idToken = value; }
        }
        public bool Registered
        {
            get { return registered; }
            set { registered = value; }
        }
        public string RefreshToken
        {
            get { return refreshToken; }
            set { refreshToken = value; }
        }
        public int ExpiresIn
        {
            get { return expiresIn; }
            set { expiresIn = value; }
        }

        public static string Secret
        {
            get { return secret; }
            set { secret = value; }
        }

    }



    /*
     * {
    "kind": "identitytoolkit#VerifyPasswordResponse",
    "localId": "<firebase-user-id>", // Use this to uniquely identify users
    "email": "<email>",
    "displayName": "",
    "idToken": "<provider-id-token>", // Use this as the auth token in database requests
    "registered": true,
    "refreshToken": "<refresh-token>",
    "expiresIn": "3600"  */


}

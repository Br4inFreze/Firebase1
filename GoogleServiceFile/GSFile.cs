using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase1.GoogleServiceFile
{
    public class GSFile
    {
        public GSFileProjectInfo project_info { get; set; }
        public List<GSFileClient> client { get; set; }
        public string configuration_version { get; set; }

        public class GSFileProjectInfo
        {
            public string project_number { get; set; }
            public string project_id { get; set; }
        }

        public class GSFileAndroidClientInfo
        {
            public string package_name { get; set; }
        }

        public class GSFileClientInfo
        {
            public string mobilesdk_app_id { get; set; }
            public GSFileAndroidClientInfo android_client_info { get; set; }
        }

        public class GSFileAndroidInfo
        {
            public string package_name { get; set; }
            public string certificate_hash { get; set; }
        }

        public class GSFileOauthClient
        {
            public string client_id { get; set; }
            public int client_type { get; set; }
            public GSFileAndroidInfo android_info { get; set; }
        }

        public class GSFileApiKey
        {
            public string current_key { get; set; }
        }

        public class GSFileAnalyticsService
        {
            public int status { get; set; }
        }

        public class GSFileAppinviteService
        {
            public int status { get; set; }
            public List<object> other_platform_oauth_client { get; set; }
        }

        public class GSFileAdsService
        {
            public int status { get; set; }
        }

        public class GSFileServices
        {
            public GSFileAnalyticsService analytics_service { get; set; }
            public GSFileAppinviteService appinvite_service { get; set; }
            public GSFileAdsService ads_service { get; set; }
        }

        public class GSFileClient
        {
            public GSFileClientInfo client_info { get; set; }
            public List<GSFileOauthClient> oauth_client { get; set; }
            public List<GSFileApiKey> api_key { get; set; }
            public GSFileServices services { get; set; }
        }


    }
}
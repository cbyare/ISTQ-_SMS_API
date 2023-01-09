using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMSAPIModule
{
    public static  class sharedResources
    {

        public static string Baseurl = "https://smsapi.hormuud.com/";

        public static HttpClient client = null;



        public static  HttpClient getSMSbaseUrl()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(Baseurl)

            };

            return client;
        }
    }
}

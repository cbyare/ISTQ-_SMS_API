using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SMSAPIModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static SMSAPIModule.Entities.Reponses;
using static SMSAPIModule.Entities.SMS;

namespace SMSAPIModule.Http
{
    public  class API
    {
       
        public static string AccessToken { get; set; }
        public static HttpClient client = null;

        public async Task<HttpResponseMessage> sendBulk(List<SMS> sms, string username,string password)
        {
            
            TokenResponse responseToken = new TokenResponse();
            responseToken = await getToken(username,password);
            string json = JsonConvert.SerializeObject(sms);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            client = sharedResources.getSMSbaseUrl();
            client.DefaultRequestHeaders.Clear();
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", responseToken.AccessToken);
            HttpResponseMessage  Res = await client.PostAsync("api/Outbound/SendBulkSMS", byteContent);
            return Res;
            }



        public async Task<HttpResponseMessage> sendSingleSMS(SMS sms, string Username, string Password)
        {

            TokenResponse responseToken = new TokenResponse();
            responseToken = await getToken(Username, Password);
            string json = JsonConvert.SerializeObject(sms);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            client = sharedResources.getSMSbaseUrl();
            client.DefaultRequestHeaders.Clear();
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", responseToken.AccessToken);
            HttpResponseMessage Res = await client.PostAsync("api/SendSMS", byteContent);
            return Res;
        }

        private  async Task <TokenResponse> getToken(string Username,string Password)
        {
            
                try
                {
                 client = sharedResources.getSMSbaseUrl();
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


                string username = Username;
                     string password = Password;
                     HttpResponseMessage response  = 
                      client.PostAsync("Token",
                      new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                          HttpUtility.UrlEncode(username),
                          HttpUtility.UrlEncode(password)), Encoding.UTF8,
                          "application/x-www-form-urlencoded")).Result;

                    string tokenresponse = response.Content.ReadAsStringAsync().Result;
                    TokenResponse result = JsonConvert.DeserializeObject<TokenResponse>(tokenresponse);

                   
                    return result;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        
      
    }
}

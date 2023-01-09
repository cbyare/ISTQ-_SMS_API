using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SMSAPIModule.Entities;
using SMSAPIModule.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static SMSAPIModule.Entities.Reponses;

namespace SMSAPIModule.Services
{
    public static class SMSService
    {
        static API api = new API();

        public static async Task<SMSReponse> SendBulkMessage(List<SMS> entities, string username, string password)
        {
            
            try
            {
                SMSReponse response = new SMSReponse();

                HttpResponseMessage Res = await api.sendBulk(entities, username, password);

                if (Res.IsSuccessStatusCode)
                {

                    var Response = Res.Content.ReadAsStringAsync().Result;
                    var ReplyMessage = (JObject.Parse(Response).SelectToken("Data").SelectToken("Description")).ToString();
                    var ResponseCode = (JObject.Parse(Response).SelectToken("ResponseCode")).ToString();
                    response = JsonConvert.DeserializeObject<SMSReponse>(Response);
                }


                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

        public static async Task<SMSReponse> SendSingleSMS(SMS entity, string username, string password)
        {

            try
            {
                
                SMSReponse response = new SMSReponse();

                HttpResponseMessage Res = await api.sendSingleSMS(entity, username, password);

                if (Res.IsSuccessStatusCode)
                {

                    var Response = Res.Content.ReadAsStringAsync().Result;
                    var ReplyMessage = (JObject.Parse(Response).SelectToken("Data").SelectToken("Description")).ToString();
                    var ResponseCode = (JObject.Parse(Response).SelectToken("ResponseCode")).ToString();
                    response = JsonConvert.DeserializeObject<SMSReponse>(Response);

                }


                return response;
            

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSAPIModule.Entities
{
    public class Reponses
    {

        public class SMSReponse
        {
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public RData Data { get; set; }

            public SMSReponse() { }
            public SMSReponse(string pResCode, string pResMsg, RData pData)
            {
                this.ResponseCode = pResCode;
                this.ResponseMessage = pResMsg;
                this.Data = pData;
            }

        }




        public class RData
        {
            public string MessageID { get; set; }
            public string Description { get; set; }
            public string DeliveryCallBack { get; set; }
            public MessageDetails Details { get; set; }

            public RData() { }
            public RData(string pMessageID, string pDescription, MessageDetails details)
            {
                this.MessageID = pMessageID;
                this.Description = pDescription;
                this.Details = details;
            }
            public RData(string pMessageID, string pDescription, string DeliveryCallBack, MessageDetails details)
            {
                this.MessageID = pMessageID;
                this.Description = pDescription;
                this.DeliveryCallBack = DeliveryCallBack;
                this.Details = details;
            }
        }


        public class MessageDetails
        {
            public int TextLength { get; set; }
            public int TotalCharacters { get; set; }
            public int TotalSMS { get; set; }
            public bool IsGMS7Bit { get; set; }
            public bool ContainsUnicode { get; set; }
            public bool IsMultipart { get; set; }
            public List<char> ExtensionSet { get; set; }
            public List<char> UnicodeSet { get; set; }
            public List<string> MessageParts { get; set; }

            public MessageDetails() { }
            public MessageDetails(int TextLength, int TotalCharacters, int TotalSMS,
                bool IsGMS7Bit, bool ContainsUnicode, bool IsMultipart, List<char> ExtensionSet, List<char> UnicodeSet, List<string> MessageParts)
            {
                this.TextLength = TextLength;
                this.TotalCharacters = TotalCharacters;
                this.TotalSMS = TotalSMS;
                this.IsGMS7Bit = IsGMS7Bit;
                this.ContainsUnicode = ContainsUnicode;
                this.IsMultipart = IsMultipart;
                this.ExtensionSet = ExtensionSet;
                this.UnicodeSet = UnicodeSet;
                this.MessageParts = MessageParts;
            }
        }

    }
}

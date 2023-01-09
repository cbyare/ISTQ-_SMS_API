using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSAPIModule.Entities;
using SMSAPIModule.Services;



namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {



            Console.WriteLine("Application started");

            // Create a list of SMSs.
            List<SMS> SMSs = new List<SMS>();

            // Add SMSs to the list.
            SMSs.Add(new SMS() { mobile = "617968003", message = "Test sms" });
            SMSs.Add(new SMS() { mobile = "615555211", message = "Waa fariin test ah By Istaqaana,MTech" });
            SMSs.Add(new SMS() { mobile = "615831044", message = "Waa fariin test ah By Istaqaana,Banadir Zone" });
            SMSs.Add(new SMS() { mobile = "615509047", message = "TWaa fariin test ah By Istaqaana" });
            SMSs.Add(new SMS() { mobile = "615929305", message = "Waa fariin test ah By Istaqaana" });
           

            SMS sms = new SMS
            { 
              mobile = "615555211",
              message = "test sms"
            
            };


           //Reponses.SMSReponse RES = await SMSService.SendSingleSMS(sms,"Istaqaana", "R1SaLt+PO1g2S9yk90jMJg==");

           var result = await SMSService.SendBulkMessage(SMSs, "Istaqaana", "R1SaLt+PO1g2S9yk90jMJg==");

            

            Console.ReadKey();
            
        }
    }
}

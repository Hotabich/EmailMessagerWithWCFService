using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Mail.Models;
using Web_Mail.ServiceReference1;
using Web_Mail.Models;

namespace Web_Mail.Controllers
{
    
    public class SenderController : ApiController
    {
        #region Fields
        private ServiceReference1.MainServiceClient _client;
        
        #endregion

        public SenderController()
        {
            _client = new MainServiceClient("BasicHttpBinding_IMainService", "http://localhost:8080/MainService");
            
        }

        [Route("api/sender/send"), HttpPost]
        public string Send([FromBody]dynamic message)
        {


            Message mess = new Message();
            mess.OwnerLogin = Sender.Email;
            mess.OwnerPassword = Sender.Password;

            if (Sender.Recipient.Count > 0)
            {
                mess.Receivers = new string[Sender.Recipient.Count];
                int _idRecipient = 0;
                foreach (string item in Sender.Recipient)
                {
                    mess.Receivers[_idRecipient] = item;
                }
            }
            else
            {
                return "No recipients";
            }

            mess.SubjectMessage = message[0];
            mess.TextMessage = message[1];

            string[] result = _client.Send(mess);
            return result[0];
        }



    }
}

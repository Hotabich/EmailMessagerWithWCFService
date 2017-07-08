using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Mail.Models;
using Web_Mail.ServiceReference1;

namespace Web_Mail.Controllers
{
    
    public class SenderController : ApiController
    {
        #region Fields
        private ServiceReference1.MainServiceClient _client;
        #endregion

        public SenderController(string from, string password, List<string> to, string subject, string message)
        {
            _client = new MainServiceClient("BasicHttpBinding_IMainService", "http://localhost:8080/MainService");
            ServiceReference1.Message mess = new Message();
            mess.OwnerLogin = from;
            mess.OwnerPassword = password;

            mess.Receivers = new string[to.Count-1];
            int _idReceivers = 0;
            foreach(string receiver in to)
            {
                mess.Receivers[_idReceivers] = receiver;
            }
            
            mess.SubjectMessage = subject;
            mess.TextMessage = message;

            string[] result = _client.Send(mess);
        }



    }
}

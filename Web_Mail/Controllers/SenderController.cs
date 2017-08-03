using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Mail.Models;
using System.Net.Mail;
using Web_Mail.ServiceReference1;
using Newtonsoft.Json;
using Wpf_Mail.Converters;


namespace Web_Mail.Controllers
{
    
    public class SenderController : ApiController
    {
        #region Fields
        private MainServiceClient _client;
        
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
                foreach (var item in Sender.Recipient)
                {
                    mess.Receivers[_idRecipient] = item.ToString();
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

        [Route("api/sender/addRecipiant"), HttpPost]
        public string AddRecipiant([FromBody]dynamic recipiantName)
        {
            Sender.Recipient.Insert(0, new MailAddress(recipiantName));                     
            return JsonConvert.SerializeObject(Sender.Recipient); ;
                
        }

        [Route("api/sender/addRecipiantForList"), HttpPost]
        public string AddRecipiantForList([FromBody]dynamic id, dynamic name)
        {
            _client.AddRecipiant(id, name.ToString());            
            return JsonConvert.SerializeObject(_client.GetRecipientsList(1).ToList()); 

        }

        [Route("api/sender/deleteRecipiant"), HttpPost]
        public string DeleteRecipiant([FromBody]dynamic selectRecipiant)
        {
            Sender.Recipient.Remove(new MailAddress(selectRecipiant));
            return JsonConvert.SerializeObject(Sender.Recipient); ;

        }

        [Route("api/sender/deleteRecipiantFromList"), HttpPost]
        public string DeleteRecipiantFromList([FromBody]dynamic idRecipiant)
        {
            _client.DeleteRecipiant(Convert.ToInt32(idRecipiant));
            return JsonConvert.SerializeObject(_client.GetRecipientsList(1).ToList());

        }

        [Route("api/sender/deleteRecipiantList"), HttpPost]
        public void DeleteRecipiantList([FromBody]dynamic selectRecipiantList)
        {
            _client.DeleteRecipiantsList(Convert.ToInt32(selectRecipiantList));           

        }

        [Route("api/sender/getalllist"), HttpGet]
        public string GetAllList()
        {
           return JsonConvert.SerializeObject(_client.GetAllRecipiantsList());

        }

        [Route("api/sender/getRecipiantList"), HttpPost]
        public string GetRecipiantList([FromBody]dynamic recipiantlistId)
        {
            int id = Convert.ToInt32(recipiantlistId);
            Sender.Recipient = Converter.ConvertToReceiversMailList(_client.GetRecipientsList(id).ToList());
            return JsonConvert.SerializeObject(Sender.Recipient); 

        }

        [Route("api/sender/addList"), HttpPost]
        public string AddList([FromBody]dynamic listName)
        {
            _client.AddRecipiantList(listName.ToString());
            List<RecipiantList> recipiantList =Converter.ConvertToRecipiantList(_client.GetAllRecipiantsList());
            return JsonConvert.SerializeObject(recipiantList);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Mail;
using System.Net;
using MainService.Model;
using System.IO;
using System.Collections.ObjectModel;
using MainService.Model.DBRepository;

namespace MainService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in both code and config file together.
    public class MainService : IMainService
    {
        private DbRepository _dbrepository;
        public MainService()
        {
            _dbrepository = new DbRepository();
        }
        
        public List<string> Send(Message _message)
        {
            List<string> _errors = new List<string>();

            MailAddress _from = new MailAddress(_message.OwnerLogin);
            foreach (string receiver in _message.Receivers)
            {
                MailAddress _to = new MailAddress(receiver);
                MailMessage _mail = new MailMessage(_from, _to);
                _mail.Subject = _message.SubjectMessage;
                _mail.Body = _message.TextMessage;



                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(_message.OwnerLogin, _message.OwnerPassword);
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(_mail);
                    _errors.Add("Message for "+ receiver + " is sended");
                }
                catch (Exception ex)
                {

                    _errors.Add("Message for " + receiver + " not senden!! " + ex.Message + ". " + ex.InnerException);                   
                }

            }
            return _errors;
            
        }

        //Work with DATABASE                                              

        public List<string> GetAllRecipiantsList()
        {
            List<string> allRecipientList = _dbrepository.GetAllRecipiantsList();
            return allRecipientList;
        }

        public List<string> GetRecipientsList(int id)
        {
            List<string> recipiantList = _dbrepository.GetRecipientsList(id);
            return recipiantList;
        }

        public void AddRecipiantList(string listName)
        {
            _dbrepository.AddRecipiantList(listName);
        }

        public void AddRecipiant(int idList, string email)
        {
            _dbrepository.AddRecipiant(idList, email);
        }

        public void UpdateRecipiant(int id, int idList, string email)
        {
            _dbrepository.UpdateRecipiant(id, idList, email);
        }

        public void DeleteRecipiantsList(int id)
        {
            _dbrepository.DeleteRecipiantsList(id);
        }

        public void DeleteRecipiant(int id)
        {            
           _dbrepository.DeleteRecipiant(id);
            
        }
    }
}


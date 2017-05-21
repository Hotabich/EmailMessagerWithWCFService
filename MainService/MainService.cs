﻿using System;
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

namespace MainService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in both code and config file together.
    public class MainService : IMainService
    {
        
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



                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential(_message.OwnerLogin, _message.OwnerPassword);
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(_mail);
                    _errors.Add("Message for "+ receiver + " is sended");
                }
                catch (Exception ex)
                {

                    _errors.Add("Message for " + receiver +" not senden!! "+ ex.Message);                   
                }

            }
            return _errors;
            
        }

    }
}

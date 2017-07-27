using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Web_Mail.ServiceReference1;

namespace Web_Mail.Models
{
    public class Sender
    {
        private static Sender instance;

        private static string email;
        private static string password;
        private static List<MailAddress> recipient = new List<MailAddress>();
        
        public static string Email
        {
            get { return email; }
            set { email = value; }
        }

        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        public static List<MailAddress> Recipient
        {
            get { return recipient; }
            set { recipient = value; }
        }
        private Sender() { }

        private static Sender getSender()
        {
            if (instance == null)
            {
                instance = new Sender();
            }
            return instance;
        }
    }
}
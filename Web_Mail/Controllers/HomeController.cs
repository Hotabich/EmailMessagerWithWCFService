using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Mail.Models;
using Web_Mail.ServiceReference1;

namespace Web_Mail.Controllers
{
    public class HomeController : Controller
    {
        #region Fields        
        #endregion

        #region Propertys       

        
        #endregion

        #region Сonstructor
        public HomeController()
        {
            //for debug
               
        }

#endregion
        public ActionResult Credential(string Email, string Password)
        {
            if (!(String.IsNullOrEmpty(Email)) && !(String.IsNullOrEmpty(Password)))
            {
                Sender.Email = Email;
                Sender.Password = Password;
                ViewBag.Recipients = Sender.Recipient;
                return View("Index");
            }
            else
            {
                ViewData["Error"] = "Email or Password is not correct or empty!!!";
                return View("~/Views/Credential/Credential.cshtml");
            }
        }

        public ActionResult Index()
        {
            ViewBag.Recipients = Sender.Recipient;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteRecipient(string recipientname)
        {
            
                Sender.Recipient.Remove(recipientname);
                ViewBag.Recipients = Sender.Recipient;            
                return View("Index");
            
        }

        public ActionResult AddRecipient(string recipient)
        {           

            if (!String.IsNullOrEmpty(recipient))
            {
                Sender.Recipient.Insert(0, recipient);                
            }
            else
            {
                ViewData["EmptyRecipient"] = "Recipient's name can not be empty";
            }
            ViewBag.Recipients = Sender.Recipient;
            return View("Index");
        }
    }
}
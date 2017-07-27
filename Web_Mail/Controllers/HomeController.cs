using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using Web_Mail.Models;
using Wpf_Mail.Converters;
using Web_Mail.ServiceReference1;

namespace Web_Mail.Controllers
{
    public class HomeController : Controller
    {
        #region Fields 
        private MainServiceClient _client;
        private ObservableCollection<RecipiantList> _recipiantsLists;        
        #endregion

        #region Propertys       


        #endregion

        #region Сonstructor
        public HomeController()
        {
            if((String.IsNullOrEmpty(Sender.Email))||(String.IsNullOrEmpty(Sender.Email)))
            {
                 Redirect("/Credential/Credential");
            }
            _client = new MainServiceClient("BasicHttpBinding_IMainService", "http://localhost:8080/MainService");

            _recipiantsLists = new ObservableCollection<RecipiantList>(Converter.ConvertToRecipiantList(_client.GetAllRecipiantsList()));

        }
        #endregion

        public ActionResult Credential(string Email, string Password)
        {
            if (!(String.IsNullOrEmpty(Email)) && !(String.IsNullOrEmpty(Password)))
            {
                Sender.Email = Email;
                Sender.Password = Password;
                ViewBag.Recipients = Sender.Recipient;
                ViewBag.RecipiantsList = _recipiantsLists;
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
            ViewBag.RecipiantsList = _recipiantsLists;
            return View();
        }

        //[HttpGet]
        //public ActionResult DeleteRecipient(string recipientname)
        //{
            
        //        Sender.Recipient.Remove(recipientname);
        //        ViewBag.Recipients = Sender.Recipient;            
        //        return View("Index");
            
        //}

        //public ActionResult AddRecipient(string recipient)
        //{           

        //    if (!String.IsNullOrEmpty(recipient))
        //    {
        //        Sender.Recipient.Insert(0, recipient);                
        //    }
        //    else
        //    {
        //        ViewData["EmptyRecipient"] = "Recipient's name can not be empty";
        //    }
        //    ViewBag.Recipients = Sender.Recipient;
        //    return View("Index");
        //}

        public ActionResult AddRecipiantList(string recipiantList)
        {
            _client.AddRecipiantList(recipiantList);
            ViewBag.RecipiantsList = new ObservableCollection<RecipiantList>(Converter.ConvertToRecipiantList(_client.GetAllRecipiantsList()));
            return View("Index");
        }

        public ActionResult DeleteRecipiantList(int idList)
        {
            _client.DeleteRecipiantsList(idList);
            ViewBag.RecipiantsList = new ObservableCollection<RecipiantList>(Converter.ConvertToRecipiantList(_client.GetAllRecipiantsList()));
            return View("Index");
        }
    }
}
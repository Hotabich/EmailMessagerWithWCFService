using System;
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



        public ActionResult EditList(int id, string name)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            return View("EditRecipiantList");
        }

       
    }
}
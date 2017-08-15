using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin_Mail.View;

namespace Xamarin_Mail.ViewModel
{
    public class AuthorizationViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _login;
        private string _password;        
        #endregion

        #region Propertys
        public string Login
        {
            get { return _login; }
            set
            {
                if(_login != value)
                {
                    _login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string Title { get; set; }

        public INavigation Navigation { get; set; }


        //command
        public ICommand GoToChoiseRecipiantCommand { protected set; get; }
        #endregion

        #region Сonstructor
        public AuthorizationViewModel()
        {
            this.Title = "Authorization";
            this.GoToChoiseRecipiantCommand = new Command(GoToChoiseRecipiant);
        }

       
        #endregion


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods

        private async void GoToChoiseRecipiant()
        {
           await Navigation.PushAsync(new ChoiseRecipiantView(), true);
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion





    }
}

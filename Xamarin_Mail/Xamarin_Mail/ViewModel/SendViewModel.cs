using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin_Mail.Model;
using Xamarin_Mail.View;
using Xamarin_Mail.Model.Service;
using Xamarin_Mail.Model.Util;

namespace Xamarin_Mail.ViewModel
{
    
    public class SendViewModel : INotifyPropertyChanged
    {
        #region fields
        private bool _isHide;
        private string _labelText;
        private MailService _service;
        private ObservableCollection<Recipiant> _recipiantsList;
        #endregion

        #region Propertys
        public bool IsHide
        {
            get { return _isHide; }
            set
            {
                if (_isHide!= value)
                {
                    _isHide = value;
                    OnPropertyChanged("IsHide");
                }
            }
        }
        public string LabelText
        {
            get { return _labelText; }
            set
            {
                if (_labelText!=value)
                {
                    _labelText = value;
                    OnPropertyChanged("LabelText");
                }
            }
        }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public ObservableCollection<Recipiant> RecipiantsList
        {
            get { return _recipiantsList; }
            set
            {
                if (_recipiantsList!=value)
                {
                    _recipiantsList = value;
                    OnPropertyChanged("RecipiantsList");
                }
            }
        }
        public INavigation Navigation { get; set; }
        public ICommand GoToShoworHideCommand { protected set; get; }
        public ICommand GoToSendCommand { protected set; get; }
        #endregion

        #region Constructor
        public SendViewModel(ObservableCollection<Recipiant> recipiants)
        {
            _service = new MailService();
            RecipiantsList = recipiants;
            Title = "Send Mail";
            LabelText = "Show Recipiant";            
            GoToShoworHideCommand = new Command(GoToHideShow);
            GoToSendCommand = new Command(GoToSend);
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods

        private void GoToSend()
        {
            //Send mail
        }
        private void GoToHideShow()
        {
            IsHide = !IsHide;
            if (IsHide)
            {
                LabelText= "Hide Recipiant";
                return;
            }
            LabelText = "Show Recipiant";
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }

}

using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin_Mail.Model.Util;
using Xamarin_Mail.Model.Service;


namespace Xamarin_Mail.ViewModel
{

    public class SendViewModel : INotifyPropertyChanged
    {
        #region fields
        private bool _isHide;
        private string _labelText;
        private MailService _service;
        private ObservableCollection<string> _recipiantsList;
        #endregion

        #region Propertys
        public bool IsHide
        {
            get { return _isHide; }
            set
            {
                if (_isHide != value)
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
                if (_labelText != value)
                {
                    _labelText = value;
                    OnPropertyChanged("LabelText");
                }
            }
        }
        public string Title { get; set; }
       
        public Message Message { get; set; }
        public string Subject { get; set; }
        public string TextMessage { get; set; }
        public ObservableCollection<string> RecipiantsList
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
        public SendViewModel()
        {
            _service = new MailService();            
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

        private async void GoToSend()
        {
            if (Message.Receivers.Count>0)
            {              
               
               Message.SubjectMessage = Subject;
               Message.TextMessage = TextMessage;               
                try
                {
                  string result= await _service.Send(Message);
                }
                catch (Exception)
                {

                    throw;
                }
            }
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

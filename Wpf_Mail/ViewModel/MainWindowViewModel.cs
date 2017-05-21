﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Prism.Events;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Net.Mail;
using System.Security.AccessControl;
using Wpf_Mail.MailService;
using Wpf_Mail.View;
using Wpf_Mail.Model;


namespace Wpf_Mail.ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {

        #region Fields   
        private string _receiver;
        private MessageInformation _info;    
        private MainServiceClient _client;
        private string _message;
        private ObservableCollection<string> _fileName;
        private ObservableCollection<MailAddress> _receivers;
        private MailAddress _currentReceiver;
        private string _currentFile;
        private DelegateCommand _sendMessage;
        private DelegateCommand _addFile;
        private DelegateCommand _deleteFile;
        private DelegateCommand _addReceiver;
        private DelegateCommand _deleteReceiver;

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propertys
        public ObservableCollection<MailAddress> Receivers
        {
            get { return _receivers; }
            set
            {
                _receivers = value;
                OnPropertyChanged("Receivers");
            }
        }
        public MailAddress OwnerLogin { get; set; }
        public string OwnerPassword { get; set; }
        public MailAddress CurrentReceiver
        {
            get { return _currentReceiver; }
            set
            {
                _currentReceiver = value;
                OnPropertyChanged("CurrentReceiver");
            }
        }
        public string CurrentFile
        {
            get { return _currentFile; }
            set
            {
                _currentFile = value;
                OnPropertyChanged("CurrentFile");
            }
        }
        public string Receiver
        {
            get { return _receiver; }
            set
            {
                _receiver = value;
                OnPropertyChanged("Receiver");
            }
        }
        public string Subject { get; set; }
        public ObservableCollection<string> FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        //Command
        public DelegateCommand SendMessage
        {
            get
            {
                return _sendMessage ?? (_sendMessage = new DelegateCommand(SendEmail));
            }
        }

        public DelegateCommand AddReceiver
        {
            get
            {
                return _addReceiver ?? (_addReceiver = new DelegateCommand(AddEmailReceiver));
            }
        }

        public DelegateCommand DeleteReceiver
        {
            get
            {
                return _deleteReceiver ?? (_deleteReceiver = new DelegateCommand(DeleteEmailReceiver));
            }
        }

        public DelegateCommand AddFile
        {
            get
            {
                return _addFile ?? (_addFile = new DelegateCommand(AddMessageFile));
            }
        }
        public DelegateCommand DeleteFile
        {
            get
            {
                return _deleteFile ?? (_deleteFile = new DelegateCommand(DeleteMessageFile));
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            _receivers = new ObservableCollection<MailAddress>();
            _fileName = new ObservableCollection<string>();

            _info = new Model.MessageInformation();

            _client = new MailService.MainServiceClient("NetTcpBinding_IMainService");

            //#if DEBUG
            //            Receivers.Add("hotabich91@mail.ru");
            //#endif
        }

        #region Methods
        private void SendEmail()
        {
            if (Receivers.Count > 0)
            {
                Message _message = new Message();

                _message.OwnerLogin = OwnerLogin.ToString();
                _message.OwnerPassword = OwnerPassword;
                _message.SubjectMessage = Subject;
                _message.TextMessage = Message;




                _message.Receivers = new string[Receivers.Count];
                int idReceiver = 0;
                foreach (MailAddress receiver in Receivers)
                {
                    _message.Receivers[idReceiver] = receiver.ToString();
                    idReceiver++;
                }

                if (FileName.Count > 0)
                {
                    _message.Attachments = new Stream[FileName.Count];
                    int idFile = 0;

                    foreach (string filePath in FileName)
                    {
                        _message.Attachments[idFile] = File.OpenRead(filePath);
                        idFile++;
                    }

                }

                try
                {
                    string[] result = _client.Send(_message);
                    _info.Show("Information", result);                   

                }
                catch (Exception ex)
                {

                    _info.Show("Error", ex.Message);
                }
            }
            else
            {                             
                _info.Show("Information", "First you need to add a recipient.");
            }                                      

        }
        private void AddEmailReceiver()
        {
            if (String.IsNullOrEmpty(Receiver))
            {                             
                _info.Show("Error", "First you must specify the recipient!!!");
                return;
            }
            try
            {
                _receivers.Add(new MailAddress(Receiver));
                Receiver = null;
            }
            catch (Exception ex)
            {

                _info.Show("Error", ex.Message);
            }          
        }
        private void DeleteEmailReceiver()
        {
            if (_currentReceiver != null)
            {
                _receivers.Remove(_currentReceiver);
            }
        }
        private void AddMessageFile()
        {

            OpenFileDialog dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {

                _fileName.Add(dialog.FileName);
            }

        }
        private void DeleteMessageFile()
        {
            _fileName.Remove(_currentFile);
        }
        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
        #endregion
    }
}
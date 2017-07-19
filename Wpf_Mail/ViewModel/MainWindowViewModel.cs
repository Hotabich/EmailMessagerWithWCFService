using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Net.Mail;
using Wpf_Mail.MailService;
using Wpf_Mail.Model;
using Wpf_Mail.Converters;
using Wpf_Mail.View;


namespace Wpf_Mail.ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {

        #region Fields         
        private string _receiver;
        private string _listName;        
        private MessageInformation _info;    
        private MainServiceClient _client;
        private EditRecipiantList _editRecipiantList;
        private string _message;
        private ObservableCollection<string> _fileName;
        private ObservableCollection<MailAddress> _receivers;
        private ObservableCollection<RecipiantList> _recipiantsLists;
        private MailAddress _currentReceiver;
        private RecipiantList _currentRecipiantList;       
        private DelegateCommand _sendMessage;                
        private DelegateCommand _addReceiver;
        private DelegateCommand _deleteReceiver;
        private DelegateCommand _addNewList;
        private DelegateCommand _deleteList;
        private DelegateCommand _editList;

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
        public ObservableCollection<RecipiantList> RecipiantsLists
        {
            get { return _recipiantsLists; }
            set
            {
                _recipiantsLists = value;
                OnPropertyChanged("RecipiantsLists");
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
        public RecipiantList CurrentRecipiantList
        {
            get { return _currentRecipiantList; }
            set
            {
                _currentRecipiantList = value;
                if (_currentRecipiantList !=null)
                {
                    GetRecipiantList(_currentRecipiantList.Id);
                }
                else
                {
                    Receivers = null;
                }
                OnPropertyChanged("CurrentRecipiantList");
                OnPropertyChanged("Receivers");
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
        public string ListName
        {
            get { return _listName; }
            set
            {
                _listName = value;
                OnPropertyChanged("ListName");
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
        public DelegateCommand AddNewList
        {
            get
            {
                return _addNewList ?? (_addNewList = new DelegateCommand(AddList));
            }
        }       
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
        public DelegateCommand DeleteList
        {
            get
            {
                return _deleteList ?? (_deleteList = new DelegateCommand(DeleteRecipiantList));
            }
        }
        public DelegateCommand EditList
        {
            get
            {
                return _editList ?? (_editList = new DelegateCommand(EditRecipiantList));
            }
        }
        #endregion

        public MainWindowViewModel()
        {            
            _receivers = new ObservableCollection<MailAddress>();
            _fileName = new ObservableCollection<string>();

            _info = new Model.MessageInformation();            

            _client = new MailService.MainServiceClient("NetTcpBinding_IMainService");

            _recipiantsLists = new ObservableCollection<RecipiantList>(Converter.ConvertToRecipiantList(_client.GetAllRecipiantsList()));
            
        }

        #region Methods            
        private void AddList()
        {
            if (!string.IsNullOrEmpty(ListName))
            {
                _client.AddRecipiantList(ListName);
                _recipiantsLists.Add(new RecipiantList() { Name = ListName });

            }
            else
            {
                _info.Show("Error", "First you must specify the name of List");
                return;
            }
        }
        private void EditRecipiantList()
        {
            if (CurrentRecipiantList != null)
            {               
                _editRecipiantList = new View.EditRecipiantList(CurrentRecipiantList);
                _editRecipiantList.ShowDialog();
                GetRecipiantList(_currentRecipiantList.Id);

            }
            else
            {
                _info.Show("Warning", "First we must select a RecipiantList!!!");
            }
        }
        private void DeleteRecipiantList()
        {
            _client.DeleteRecipiantsList(CurrentRecipiantList.Id);
            _recipiantsLists.Remove(CurrentRecipiantList);                
        }
        private void GetRecipiantList(int id)
        {
            _receivers = new ObservableCollection<MailAddress>(Converter.ConvertToReceiversMailList(_client.GetRecipientsList(id).ToList()));            
        }
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
        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
        #endregion
    }
}

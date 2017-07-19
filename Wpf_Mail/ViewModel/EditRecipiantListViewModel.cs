using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Wpf_Mail.MailService;
using Wpf_Mail.Model;
using System.Net.Mail;
using Wpf_Mail.Converters;

namespace Wpf_Mail.ViewModel
{
    public class EditRecipiantListViewModel:INotifyPropertyChanged
    {
        #region 
        private MessageInformation _info;
        private Recipiant _currentRecipiant;
        private string _nameRecipiant;
        private MainServiceClient _client;
        private string _listName;
        private int _idList;
        private ObservableCollection<Recipiant> _recipiantList;
        private DelegateCommand _addRecipiant;
        private DelegateCommand _deleteRecipiant;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propertys
        public string ListName
        {
            get { return _listName; }
            set
            {
                _listName = value;
                OnPropertyChanged("ListName");
            }
        }

        public string NameRecipiant
        {
            get { return _nameRecipiant; }
            set
            {
                _nameRecipiant = value;
                OnPropertyChanged("NameRecipiant");
            }
        }

        public int IdList
        {
            get { return _idList; }
            private set
            {
                _idList = value;
            }
        }

        public Recipiant CurrentRecipiant
        {
            get { return _currentRecipiant; }
            set
            {
                _currentRecipiant = value;
                OnPropertyChanged("CurrentRecipiant");
            }
        }

        public ObservableCollection<Recipiant> RecipiantList
        {
            get { return _recipiantList; }
            set
            {
                _recipiantList = value;
                OnPropertyChanged("RecipiantList");
            }
        }

        //Commands
        public DelegateCommand AddRecipiant
        {
            get
            {
                return _addRecipiant ?? (_addRecipiant = new DelegateCommand(AddNewRecipiant));
            }
        }

        public DelegateCommand DeleteRecipiant
        {
            get
            {
                return _deleteRecipiant ?? (_deleteRecipiant = new DelegateCommand(DeleteOldRecipiant));
            }
        }
        
        #endregion

        public EditRecipiantListViewModel(RecipiantList list)
        {
            this.ListName = list.Name;
            this.IdList = list.Id;

            _info = new Model.MessageInformation();
            _client = new MailService.MainServiceClient("NetTcpBinding_IMainService");

            _recipiantList = new ObservableCollection<Recipiant>(_client.GetRecipientsList(list.Id));
        }

        #region Method
        private void AddNewRecipiant()
        {
            if (!String.IsNullOrEmpty(NameRecipiant))
            {
                try
                {
                    MailAddress newMail = new MailAddress(NameRecipiant);
                    _client.AddRecipiant(IdList, NameRecipiant);
                    NameRecipiant = null;
                    RecipiantList = new ObservableCollection<Recipiant>(_client.GetRecipientsList(IdList));

                }
                catch (Exception ex)
                {

                    _info.Show("Error", ex.Message);
                    return;
                }

            }
            else
            {
                _info.Show("Error", "First you must specify the recipient!!!");
                return;
            }
            
        }

        private void DeleteOldRecipiant()
        {
            _client.DeleteRecipiant(CurrentRecipiant.Id);
            RecipiantList = new ObservableCollection<Recipiant>(_client.GetRecipientsList(IdList));
        }

        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
        #endregion
    }
}

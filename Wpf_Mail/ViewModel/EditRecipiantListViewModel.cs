using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Wpf_Mail.MailService;
using Wpf_Mail.Converters;

namespace Wpf_Mail.ViewModel
{
    public class EditRecipiantListViewModel:INotifyPropertyChanged
    {
        #region 
        private MainServiceClient _client;
        private string _listName;
        private int _idList;
        private ObservableCollection<Recipiant> _recipiantList;
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

        public int IdList
        {
            get { return _idList; }
            private set
            {
                _idList = value;
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
        #endregion

        public EditRecipiantListViewModel(RecipiantList list)
        {
            this.ListName = list.Name;
            this.IdList = list.Id;

            _client = new MailService.MainServiceClient("NetTcpBinding_IMainService");

            _recipiantList = new ObservableCollection<Recipiant>(_client.GetRecipientsList(list.Id));
        }

        #region Method

        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
        #endregion
    }
}

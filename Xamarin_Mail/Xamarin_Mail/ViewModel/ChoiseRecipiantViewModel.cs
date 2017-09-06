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
using Xamarin_Mail.Model.Service;
using Xamarin_Mail.View;

namespace Xamarin_Mail.ViewModel
{
   public class ChoiseRecipiantViewModel: INotifyPropertyChanged
    {
        #region Fields        
        MailService _service;
        bool _isBusy;
        bool _isReady;
        bool _canAdd;
        string _listName;
        ObservableCollection<RecipiantList> _recipiantLists;
        RecipiantList _currentList;
        ObservableCollection<Recipiant> _curentListItems;
        #endregion

        #region Propertys
        
        public bool IsBusy
        {
            get { return _isBusy; }
            private set
            {
                if (_isBusy!=value)
                {
                    _isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }

        public bool CanAdd
        {
            get { return _canAdd; }
            set
            {
                if (_canAdd!=value)
                {
                    _canAdd = value;
                    OnPropertyChanged("CanAdd");
                }
            }
        }
        
        public string ListName
        {
            get { return _listName; }
            set
            {
                if (_listName != value)
                {
                    _listName = value;
                    OnPropertyChanged("ListName");
                }
            }
        }

        public bool IsReady
        {
            get { return _isReady; } 
            private set
            {
                if (_isReady!=value)
                {
                    _isReady = value;
                    OnPropertyChanged("IsReady");
                }
            }
            
        }
        public string Title { get; set; }

        public RecipiantList CurrentList
        {
            get { return _currentList; }
            set
            {
                if (_currentList!=value)
                {
                    _currentList = value;
                    OnPropertyChanged("CurrentList");
                }
            }
        }

        public ObservableCollection<Recipiant> CurrentListItems
        {
            get { return _curentListItems; }
            set
            {
                if (_curentListItems != value)
                {
                    _curentListItems = value;
                    OnPropertyChanged("CurrentListItems");
                }
            }
        }

        public ObservableCollection<RecipiantList> RecipiantLists
        {
            get { return _recipiantLists; }
            set
            {
                if (_recipiantLists !=value)
                {
                    _recipiantLists = value;
                    OnPropertyChanged("RecipiantLists");
                }
            }
        }

        public ICommand GoToSelectedListCommand { protected set; get; }
        public ICommand GoTODeleteListCommand { protected set; get; }
        public ICommand GoToEditListCommand { protected set; get; }
        public ICommand GoToAddRecipiantCommand { protected set; get; }
        public ICommand GoToAddListCommand { protected set; get; }

        public INavigation Navigation { get; set; }
        #endregion

        #region Сonstructor      
        public ChoiseRecipiantViewModel()
        {
            _service = new MailService();                       
            this.Title = "Choise Recipiant";
            _recipiantLists = new ObservableCollection<RecipiantList>();
            _curentListItems = new ObservableCollection<Recipiant>();
            
            this.GoToSelectedListCommand = new Command(GoToSelectedList);
            this.GoToEditListCommand = new Command(GoToEditList);
            this.GoToAddRecipiantCommand = new Command(GoToAddRecipiant);
            this.GoTODeleteListCommand = new Command (GoToDeleteList);
            this.GoToAddListCommand = new Command(GoTOAddList);
            
            //for Debug
            
        }
        #endregion


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods

        public  async Task GetAllList()
        {
            try
            {
                IsBusy = true;
                RecipiantLists = new ObservableCollection<RecipiantList>(await _service.GetAllList());

                IsBusy = false;
                IsReady = true;
            }
            catch (Exception ex)
            {

                var error = ex.Message;
            }
            
        }

        private void GoToDeleteList()
        {
            if (_currentList != null)
            {
                IsBusy = true;
                IsReady = !IsBusy;
                _service.DeleteList(CurrentList.Id);
                _recipiantLists.Remove(_currentList);
                IsBusy = IsReady;
                IsReady = !IsBusy;
            }
        }

        private async void GoTOAddList()
        {
            if (!String.IsNullOrEmpty(ListName))
            {
                CanAdd = false;
                RecipiantLists= new ObservableCollection<RecipiantList>(await _service.AddList(ListName));
                ListName = null;
               
            }
            else
            {
                CanAdd = true;
            }
        }

        private async void GoToSelectedList()
        {
            await Navigation.PushAsync(new EditListView(_currentList, false));
        }

        private async void GoToEditList()
        {
            if (_currentList != null)
            {
                await Navigation.PushAsync(new EditListView(_currentList, true));
            }
        }

        private async void GoToAddRecipiant()
        {
            await Navigation.PushAsync(new EditListView(new RecipiantList(1000000, "Add Recipiants") , false));
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

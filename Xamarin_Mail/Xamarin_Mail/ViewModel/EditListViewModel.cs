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

namespace Xamarin_Mail.ViewModel
{
    public class EditListViewModel: INotifyPropertyChanged
    {
        #region Fields
        private bool _isBusy;
        private bool _isReady;
        private MailService _service;
        private Recipiant _currentRecipiant;
        private ObservableCollection<Recipiant> _recipiantsList;
        private RecipiantList _list;
        #endregion

        #region Propertys
        public bool IsBusy
        {
            get { return _isBusy; }
            private set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }

        public bool IsReady
        {
            get { return _isReady; }
            private set
            {
                if (_isReady != value)
                {
                    _isReady = value;
                    OnPropertyChanged("IsReady");
                }
            }

        }
        public INavigation Navigation { get; set; }
        public RecipiantList List
        {
            get { return _list; }
            set
            {
                if (_list != value)
                {
                    _list = value;
                    OnPropertyChanged("List");
                }
            }
        }

        public Recipiant CurrentRecipiant
        {
            get { return _currentRecipiant; }
            set
            {
                if (_currentRecipiant != value)
                {
                    _currentRecipiant = value;
                    OnPropertyChanged("CurrentRecipiant");
                }
            }
        }
        public string Title { get; set; }
        public string ListName
        {
            get { return List.Name; }
            set
            {
                if (List.Name != value)
                {
                    List.Name = value;
                    OnPropertyChanged("ListName");
                }
            }
        }

        public ObservableCollection<Recipiant> RecipiantsList
        {
            get { return _recipiantsList; }
            set
            {
                if (_recipiantsList != value)
                {
                    _recipiantsList = value;
                    OnPropertyChanged("RecipiantsList");
                }
            }
        }

        public ICommand GoToBackCommand { protected set; get; }
        #endregion

        #region Сonstructor      
        public EditListViewModel(RecipiantList list)
        {
            _service = new MailService();
            this.List = list;
            this.Title = "Edit "+ list.Name+" List";
            _recipiantsList = new ObservableCollection<Recipiant>();
            GoToBackCommand = new Command(GoToBack);
        }
        #endregion


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods 

        private async void GoToBack()
        {
            await Navigation.PopAsync();
        }
        public async Task GetList()
        {
            try
            {
                IsBusy = true;
                RecipiantsList = new ObservableCollection<Recipiant>(await _service.GetList(_list.Id));
                IsBusy = false;
                IsReady = true;

            }
            catch (Exception ex)
            {

                var error = ex.Message;
            }

        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

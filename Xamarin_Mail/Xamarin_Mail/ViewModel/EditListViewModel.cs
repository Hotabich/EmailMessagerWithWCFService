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
    public class EditListViewModel: INotifyPropertyChanged
    {
        #region Fields
        private string _labelText;
        private bool _isBusy;
        private string _recipiantName;
        private bool _isReady;
        private bool _canDo;
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

        public bool CanDo
        {
            get { return _canDo; }
            set
            {
                if (_canDo!=value)
                {
                    _canDo = value;
                    OnPropertyChanged("CanDo");
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

        public string RecipiantName {
        get { return _recipiantName; }
            set
            {
                if (_recipiantName!=value)
                {
                    _recipiantName = value;
                    OnPropertyChanged("RecipiantName");
                    CanDo = false;
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

        public Message Message { get; set; }

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

        public ICommand GoToUniversalCommand { protected set; get; }
        public ICommand GoToAddRecipiantCommand { protected set; get; }
        public ICommand GoToDeleteRecipiantCommand { protected set; get; }
        #endregion

        #region Сonstructor      
        public EditListViewModel(RecipiantList list, bool isEditView)
        {
            _service = new MailService();
            _recipiantsList = new ObservableCollection<Recipiant>();
            GoToDeleteRecipiantCommand = new Command(GoToDeleteRecipiant);
            GoToAddRecipiantCommand = new Command(GoToAddRecipiant);
            this.List = list;            
            if (isEditView)
            {
                LabelText = "Back";
                this.Title = "Edit " + list.Name + " List";
                GoToUniversalCommand = new Command(GoToBack);
            }
            else
            {
                LabelText = "Next";
                this.Title = list.Name + " List";
                GoToUniversalCommand = new Command(GoToNext);
            }                                                              

        }        
        #endregion


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods 
        private async void GoToAddRecipiant()
        {
            if (Validator.MailIsValid(RecipiantName))
            {
                if (_list.Id!= 1000000)
                {
                    IsBusy = true;
                    IsReady = !IsBusy;
                    RecipiantsList = new ObservableCollection<Recipiant>(await _service.AddRecipiant(new Recipiant(0, List.Id, RecipiantName)));
                    RecipiantName = null;
                    IsBusy = IsReady;
                    IsReady = !IsBusy;
                    CanDo = false;
                }
                else
                {
                    RecipiantsList.Add(new Recipiant(0, List.Id, RecipiantName));
                    RecipiantName = null;
                    CanDo = false;
                }
               
            }
            else
            {
                RecipiantName = null;
                CanDo = !CanDo;                
            }
        }
        private  void GoToDeleteRecipiant()
        {
            if (_currentRecipiant != null)
            {
                IsBusy = true;
                IsReady = !IsBusy;
                _service.DeleteRecipiant(_currentRecipiant);
                _recipiantsList.Remove(_currentRecipiant);
                IsBusy = IsReady;
                IsReady = !IsBusy;
            }
        }

        private async void GoToNext()
        {
            Message.Receivers = Converter.RecipiantToString(RecipiantsList);
            await Navigation.PushAsync(new SendView(Message));
        }

        private async void GoToBack()
        {
            await Navigation.PopAsync();
        }
        public async Task GetList()
        {
            if (_list.Id != 1000000)
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
            else
            {
                RecipiantsList = new ObservableCollection<Recipiant>();
                IsBusy = false;
                IsReady = true;
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

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

namespace Xamarin_Mail.ViewModel
{
   public class ChoiseRecipiantViewModel: INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<RecipiantList> _recipiantLists;
        private RecipiantList _currentList;
        private ObservableCollection<Recipiant> _curentListItems;
        #endregion

        #region Propertys
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
        #endregion

        #region Сonstructor      
        public ChoiseRecipiantViewModel()
        {
            this.Title = "Choise Recipiant";
            _recipiantLists = new ObservableCollection<RecipiantList>();
            _curentListItems = new ObservableCollection<Recipiant>();

            //for Debug
            _recipiantLists.Add(new RecipiantList(0, "zero"));
            _recipiantLists.Add(new RecipiantList(1, "one"));
            _recipiantLists.Add(new RecipiantList(2, "two"));
            _recipiantLists.Add(new RecipiantList(3, "three"));
            _recipiantLists.Add(new RecipiantList(0, "zero"));
            _recipiantLists.Add(new RecipiantList(1, "one"));
            _recipiantLists.Add(new RecipiantList(2, "two"));
            _recipiantLists.Add(new RecipiantList(3, "three"));
            _recipiantLists.Add(new RecipiantList(0, "zero"));
            _recipiantLists.Add(new RecipiantList(1, "one"));
            _recipiantLists.Add(new RecipiantList(2, "two"));
            _recipiantLists.Add(new RecipiantList(3, "three"));
            _recipiantLists.Add(new RecipiantList(0, "zero"));
            _recipiantLists.Add(new RecipiantList(1, "one"));
            _recipiantLists.Add(new RecipiantList(2, "two"));
            _recipiantLists.Add(new RecipiantList(3, "three"));
        }
        #endregion


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
       

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

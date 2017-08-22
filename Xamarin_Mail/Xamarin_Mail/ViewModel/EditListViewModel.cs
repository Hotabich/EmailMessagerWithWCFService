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

namespace Xamarin_Mail.ViewModel
{
    public class EditListViewModel: INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<Recipiant> _recipiantsList;
        private RecipiantList _list;
        #endregion

        #region Propertys
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
        #endregion

        #region Сonstructor      
       public EditListViewModel(RecipiantList list)
        {
            this.List = list;
            this.Title = "Edit "+ list.Name+" List";
            _recipiantsList = new ObservableCollection<Recipiant>();
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

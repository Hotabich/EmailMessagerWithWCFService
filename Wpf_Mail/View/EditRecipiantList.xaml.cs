using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_Mail.MailService;
using Wpf_Mail.ViewModel;

namespace Wpf_Mail.View
{
    /// <summary>
    /// Interaction logic for EditRecipiantList.xaml
    /// </summary>
    public partial class EditRecipiantList : Window
    {
       
        public EditRecipiantList(RecipiantList list)
        {            
            InitializeComponent();
            DataContext = new EditRecipiantListViewModel(list);            
        }        
    }
}

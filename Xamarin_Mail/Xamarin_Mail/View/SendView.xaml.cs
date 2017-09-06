using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Mail.ViewModel;
using Xamarin_Mail.Model;

namespace Xamarin_Mail.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendView : ContentPage
    {
        SendViewModel viewModel;
        public SendView(ObservableCollection<Recipiant> recipiants)
        {
            viewModel = new SendViewModel(recipiants) { Navigation = this.Navigation };
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
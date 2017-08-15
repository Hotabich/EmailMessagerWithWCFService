using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Mail.ViewModel;

namespace Xamarin_Mail.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoiseRecipiantView : ContentPage
    {
        public ChoiseRecipiantView()
        {
            InitializeComponent();
            this.BindingContext = new ChoiseRecipiantViewModel();
        }
    }
}
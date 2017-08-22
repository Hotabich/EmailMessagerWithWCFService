using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_Mail.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_Mail.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authorization : ContentPage
    {
        public Authorization()
        {
            InitializeComponent();
                this.BindingContext = new AuthorizationViewModel() { Navigation=this.Navigation};
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
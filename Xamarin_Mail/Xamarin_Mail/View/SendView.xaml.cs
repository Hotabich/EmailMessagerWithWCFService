using Xamarin_Mail.Model.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Mail.ViewModel;

namespace Xamarin_Mail.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendView : ContentPage
    {
        SendViewModel viewModel;
        public SendView(Message message)
        {
            viewModel = new SendViewModel() { Navigation = this.Navigation, Message= message };
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
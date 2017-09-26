using Xamarin_Mail.Model.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Mail.ViewModel;

namespace Xamarin_Mail.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoiseRecipiantView : ContentPage
    {
        ChoiseRecipiantViewModel viewModel;
        public ChoiseRecipiantView( Message message)
        {
            InitializeComponent();
            viewModel = new ChoiseRecipiantViewModel() { Navigation = this.Navigation, Message = message };
            this.BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetAllList();
            base.OnAppearing();
        }

    }
}
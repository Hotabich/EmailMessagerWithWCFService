using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Mail.ViewModel;
using Xamarin_Mail.Model;
using Xamarin_Mail.Model.Util;

namespace Xamarin_Mail.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditListView : ContentPage
	{
        EditListViewModel viewModel;
		public EditListView ( RecipiantList list, bool isEdit, Message message)
		{
            viewModel = new EditListViewModel(list, isEdit) { Navigation = this.Navigation, Message = message };
            InitializeComponent ();
            this.BindingContext = viewModel;
		}

        protected async override void OnAppearing()
        {
            await viewModel.GetList();
            base.OnAppearing();
        }
    }
}
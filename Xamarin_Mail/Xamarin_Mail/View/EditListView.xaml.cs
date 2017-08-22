using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Mail.ViewModel;
using Xamarin_Mail.Model;

namespace Xamarin_Mail.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditListView : ContentPage
	{
		public EditListView ( RecipiantList list)
		{
			InitializeComponent ();
            this.BindingContext = new EditListViewModel(list) {Navigation=this.Navigation };
		}
	}
}
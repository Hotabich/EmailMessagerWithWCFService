﻿using System;
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
        ChoiseRecipiantViewModel viewModel;
        public ChoiseRecipiantView()
        {
            InitializeComponent();
            viewModel = new ChoiseRecipiantViewModel() { Navigation = this.Navigation };
            this.BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetAllList();
            base.OnAppearing();
        }

    }
}
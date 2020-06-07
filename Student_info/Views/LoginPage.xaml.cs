using Student_info.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_info.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private ItemsViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();

        }
        async void Btn_Reg_CLicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        async void Btn_Login_CLicked(object sender, System.EventArgs e)
        {
            if (password.Text == "123")
            {
                login.Text = "Zalogowano";
            }
            await Navigation.PushAsync(new ItemsPage());
            Navigation.RemovePage(Navigation.NavigationStack.First());
        }
        

    }

}

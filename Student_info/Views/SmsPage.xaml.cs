using Student_info.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_info.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmsPage : ContentPage
    {
        public SmsPage()
        {
            InitializeComponent();

            BindingContext = new SmsViewModel();
        }
    }
}
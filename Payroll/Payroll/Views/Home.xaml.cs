using Payroll.Model;
using Payroll.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public readonly HomeViewModel ViewModel = App.Locator.HomeViewModel;
        public Home()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        public Home(Contact contact)
        {
            InitializeComponent();
            BindingContext = ViewModel;
            NavigationPage.SetHasNavigationBar(this, false);
            ViewModel.Initilize(contact);
        }
    }
}
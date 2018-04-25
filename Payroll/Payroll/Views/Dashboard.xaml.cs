using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void PaySlips_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaySlipsList());
        }

        private void Profile_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Profile());

        }

        private void LeavesTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Leavespage());
        }

        private void RecordKeeping(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecordKeeping());
        }

        private void AttendanceTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AttendancePage());
        }

        private void Expenses(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ExpensesPage());
        }

        private void Loans(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoansPage());
        }
    }
}
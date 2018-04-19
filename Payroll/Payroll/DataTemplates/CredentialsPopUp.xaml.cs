using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CredentialsPopUp : DataTemplate
	{
		public CredentialsPopUp (Contact contact)
		{
			InitializeComponent ();
		    NameLabel.Text = contact.Name;
		    EmailLabel.Text = contact.Email;
		    ContactLabel.Text = contact.PhoneNumber;

        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoPAv2.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class verCalendarioColor : ContentPage
	{
		public verCalendarioColor ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false); 
        }
	}
}
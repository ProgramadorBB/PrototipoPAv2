using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoPAv2.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class menuAdmin : ContentPage
	{
		public menuAdmin ()
		{
			InitializeComponent ();
		}

        private void BtnGetAllUsers_Clicked(object sender, EventArgs e)
        {

        }

        private void OnUpdateUser(object sender, ItemTappedEventArgs e)
        {
            //ListView.ite
        }
    }
}
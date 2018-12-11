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
	public partial class menuEmpaque : ContentPage
	{
		public menuEmpaque ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnPerfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new editarPerfil());
        }

        private async void BtnCalendario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new verCalendarioColor());
        }

        private void BtnReglamento_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnCerrarSession_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
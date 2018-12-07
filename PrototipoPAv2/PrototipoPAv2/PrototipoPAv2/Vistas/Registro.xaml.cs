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
	public partial class Registro : ContentPage
	{
		public Registro ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            pkColor.Items.Add("Naranjo");
            pkColor.Items.Add("Verde");
            pkColor.Items.Add("Amarillo");
            pkColor.Items.Add("Azul");
            pkColor.Items.Add("Celeste");

            pkTipo.Items.Add("Empaque");
            pkTipo.Items.Add("Coordinador");
            pkTipo.SelectedIndex = 0;
        }

        private void PkColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string color = pkColor.SelectedItem.ToString();
            if(color == "Naranjo")
            {
                pkColor.BackgroundColor = Color.Orange;
                pkColor.TextColor = Color.Orange;
            }
            else if (color == "Verde")
            {
                pkColor.BackgroundColor = Color.Green;
                pkColor.TextColor = Color.Green;
            }
            else if (color == "Amarillo")
            {
                pkColor.BackgroundColor = Color.Yellow;
                pkColor.TextColor = Color.Yellow;
            }
            else if (color == "Azul")
            {
                pkColor.BackgroundColor = Color.Blue;
                pkColor.TextColor = Color.Blue;
            }
            else if (color == "Celeste")
            {
                pkColor.BackgroundColor = Color.LightBlue;
                pkColor.TextColor = Color.LightBlue;
            }

        }
    }
}
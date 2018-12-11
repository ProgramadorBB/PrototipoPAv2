using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrototipoPAv2.Modelo;
using PrototipoPAv2.Conexiones;

namespace PrototipoPAv2.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class editarPerfil : ContentPage
	{
		public editarPerfil ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnActualizarPerfil_Clicked(object sender, EventArgs e)
        {
            
        }

        private void BtnCargarDatos_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["sesion"] as Usuario;
            txtEmail.Text = u.Email;
            txtContraseña.Text = u.Contraseña;
            txtNombre.Text = u.Nombre;
            txtApellido.Text = u.Apellido;

            //Button cargar = (Button)sender;
            btnCargarDatos.IsEnabled = false;
        }

        private void BtnMostrarOcultar_Clicked(object sender, EventArgs e)
        {
            string btn = btnMostrarOcultar.Text;

            if(btn == "Mostrar")
            {
                txtContraseña.IsPassword = false;
                btnMostrarOcultar.Text = "Ocultar";
            }
            else
            {
                txtContraseña.IsPassword = true;
                btnMostrarOcultar.Text = "Mostrar";
            }
        }
    }
}
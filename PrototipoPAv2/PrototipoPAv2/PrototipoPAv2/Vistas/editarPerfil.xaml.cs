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

        private async void BtnActualizarPerfil_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text)
                || string.IsNullOrWhiteSpace(txtContraseña.Text)
                || string.IsNullOrWhiteSpace(txtNombre.Text)
                || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                await this.DisplayAlert("Faltan datos",
                        "Datos incorrectos y/o inválidos.",
                        "Cancelar");
            }
            else
            {
                Usuario u = Application.Current.Properties["sesion"] as Usuario;
                u.Email = txtEmail.Text;
                u.Contraseña = txtContraseña.Text;
                u.Nombre = txtNombre.Text;
                u.Apellido = txtApellido.Text;

                UsuarioRepository.Instancia.UpdateUser(u);
                Application.Current.Properties["sesion"] = u;
                
                await this.DisplayAlert("Usuario [id:"+u.Id+ "]",
                        "Actualizado correctamente.",
                        "Ok");

                await Navigation.PushAsync(new menuEmpaque());
            }

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
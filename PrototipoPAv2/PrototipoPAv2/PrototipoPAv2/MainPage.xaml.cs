using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PrototipoPAv2.Vistas;
using PrototipoPAv2.Conexiones;

namespace PrototipoPAv2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Registro());

            lblMensaje.Text = string.Empty;
            Boolean isUserExist = UsuarioRepository.Instancia.AttempLogin(txtEmail.Text,txtContraseña.Text);            

            if (isUserExist.Equals(true))
            {
                lblMensaje.Text = "Usuario correcto";
            }
            else
            {
                lblMensaje.Text = UsuarioRepository.Instancia.EstadoMensaje; ;
            }

        }
    }
}

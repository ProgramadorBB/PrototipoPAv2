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

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {

            lblMensaje.Text = string.Empty;

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblMensaje.Text = "Debe ingresar un Email";
            }
            else
            {
                if (string.IsNullOrEmpty(txtContraseña.Text))
                {
                    lblMensaje.Text = "Debe ingresar una contraseña";
                }
                else
                {
                    if (txtEmail.Text.Equals("Admin") && txtContraseña.Text.Equals("123456"))
                    {
                        await Navigation.PushAsync(new menuAdmin());
                    }
                    else
                    {
                        Boolean isUserExist = UsuarioRepository.Instancia.AttempLogin(txtEmail.Text, txtContraseña.Text);

                        if (isUserExist.Equals(true))
                        {
                            await Navigation.PushAsync(new menuEmpaque());
                        }
                        else
                        {
                            lblMensaje.Text = UsuarioRepository.Instancia.EstadoMensaje; ;
                        }
                    }
                }
            }
        }
    }
}

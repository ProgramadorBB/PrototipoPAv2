using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PrototipoPAv2.Vistas;
using PrototipoPAv2.Conexiones;
using PrototipoPAv2.Modelo;

namespace PrototipoPAv2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Application.Current.Properties.Clear();

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
                    if (txtEmail.Text.Equals("Admin") && txtContraseña.Text.Equals("123"))
                    {
                        //Application.Current.Properties["privilegio"] = "Administrador@";
                        txtEmail.Text = string.Empty;
                        txtContraseña.Text = string.Empty;
                        await Navigation.PushAsync(new menuAdmin());
                    }
                    else
                    {
                        Boolean isUserExist = UsuarioRepository.Instancia.AttempLogin(txtEmail.Text, txtContraseña.Text);

                        if (isUserExist.Equals(true))
                        {
                            Usuario userSesion = UsuarioRepository.Instancia.userType(txtEmail.Text,txtContraseña.Text);

                            if (userSesion.Tipo.Equals("Empaque"))
                            {

                                await this.DisplayAlert("Bienvenido", userSesion.Tipo+": "+userSesion.Nombre+" "+userSesion.Apellido, "Acceder");
                                Application.Current.Properties["sesion"] = userSesion;

                                txtEmail.Text = string.Empty;
                                txtContraseña.Text = string.Empty;
                                await Navigation.PushAsync(new menuEmpaque());
                            }
                            else
                            {
                                
                                await this.DisplayAlert("Bienvenido", userSesion.Tipo + ": " + userSesion.Nombre + " " + userSesion.Apellido, "Acceder");
                                Application.Current.Properties["sesion"] = userSesion;
                            }                         
                           
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

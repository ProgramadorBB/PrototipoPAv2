using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PrototipoPAv2.Conexiones;
using PrototipoPAv2.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoPAv2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
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
            if (color == "Naranjo")
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

        private void BtnRegistrarUsuario_Clicked(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            lblMensaje.TextColor = Color.DarkRed;

            if (pkColor.SelectedIndex >= 0)
            {
                if(pkTipo.SelectedIndex >= 0)
                {
                    string _email = txtEmail.Text;
                    string _contraseña = txtContraseña.Text;
                    string _nombre = txtNombre.Text;
                    string _apellido = txtApellido.Text;
                    string _color = pkColor.SelectedItem.ToString();
                    string _tipo = pkTipo.SelectedItem.ToString();
                    string _estado = txtEstado.Text;

                    UsuarioRepository.Instancia.AddNuevoUsuario(_email,_contraseña,_nombre,_apellido,_color,_tipo,_estado);
                    lblMensaje.Text = UsuarioRepository.Instancia.EstadoMensaje;
                }
                else
                {
                    lblMensaje.Text = "Error: Seleccione el tipo de usuario";
                }
            }
            else
            {
                lblMensaje.Text = "Error: Seleccione el color del usuario";
            }
            
                            
        }
    }
}
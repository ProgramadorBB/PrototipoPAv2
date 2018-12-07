﻿using System;
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
            //pkColor.Items.Add(" ");
            //pkColor.SelectedIndex = 5;

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
            /* 
               UsuarioRepository.Instancia.AddNuevoUsuario(
                 txtEmail.Text, txtContraseña.Text, txtNombre.Text,
                 txtApellido.Text, pkColor.SelectedItem.ToString(),
                 pkTipo.SelectedItem.ToString(), txtEstado.Text);
                 */
            if (pkColor.SelectedIndex >= 0)
            {
                lblMensaje.TextColor = Color.DarkRed;
                lblMensaje.Text = "color: " + pkColor.SelectedItem.ToString() +
                " Tipo:" + pkTipo.SelectedItem.ToString() +
                " estado:" + txtEstado.Text;                
            }
            else
            {
                lblMensaje.TextColor = Color.Red;
                lblMensaje.Text = "*AVISO: Debe elegir un color";
            }
                 
            
        }
    }
}
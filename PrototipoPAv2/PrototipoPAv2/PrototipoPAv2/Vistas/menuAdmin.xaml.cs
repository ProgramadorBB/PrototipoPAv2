using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrototipoPAv2.Modelo;
using PrototipoPAv2.Conexiones;
using System.Collections.ObjectModel;

namespace PrototipoPAv2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menuAdmin : ContentPage
    {
        IList<Usuario> users = new ObservableCollection<Usuario>();

		public menuAdmin ()
		{
            BindingContext = users;
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        private void BtnGetAllUsers_Clicked(object sender, EventArgs e)
        {            
            var allUsers = UsuarioRepository.Instancia.GetAllUsuarios();


            foreach (Usuario user in allUsers)
                if (users.All(u => u.Id != user.Id))
                    users.Add(user);
        }


        private async void OnUpdateUser(object sender, ItemTappedEventArgs e)
        {
            Usuario u = (Usuario)e.Item;
            await Navigation.PushAsync(new EditUserPage(users,u));
        }

        private async void OnDeleteUser(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Usuario user = (Usuario)item.CommandParameter;
            
            if(user != null)
            {
                if(await this.DisplayAlert("¿Borrar usuario [id: " + user.Id+ "]?",
                    "El usuario [" + user.Nombre + " " + user.Apellido + "] Se eliminara de forma permanente",
                    "Eliminar usuario",
                    "Cancelar") == true)
                {
                    UsuarioRepository.Instancia.DeleteUser(user.Id);
                    users.Remove(user);
                }
            }

        }
        
        private async void BtnRegistrarUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
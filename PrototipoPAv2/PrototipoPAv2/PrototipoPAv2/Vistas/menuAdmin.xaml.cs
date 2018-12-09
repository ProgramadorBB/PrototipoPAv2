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

        private void OnUpdateUser(object sender, ItemTappedEventArgs e)
        {
            //ListView.ite
        }

        private void OnDeleteUser(object sender, EventArgs e)
        {

        }

        private void OnSelectUser(object sender, EventArgs e)
        {

        }

        private async void BtnRegistrarUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }
}
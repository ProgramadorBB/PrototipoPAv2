using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using PrototipoPAv2.Modelo;
using PrototipoPAv2.Conexiones;

namespace PrototipoPAv2.Vistas
{
    public class EditUserPage : ContentPage
    {
        IList<Usuario> users;
        Usuario user;
        EntryCell emailCell, contraseñaCell, nombreCell, apellidoCell, tipoCell, estadoCell;

        public EditUserPage(IList<Usuario> users, Usuario user)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.users = users;
            this.user = user;

            var tableView = new TableView
            {
                BackgroundColor = Color.LightGoldenrodYellow,
                Intent = TableIntent.Form,
                Root = new TableRoot("Editar usuario")
                {
                    new TableSection("Usuario Id:["+user.Id+"] Detalles: ")
                    {
                        
                        (emailCell = new EntryCell
                        {
                            Label = "Email", LabelColor = Color.Black,
                            Placeholder = "add Email",
                            Text = user.Email
                        }),
                        (contraseñaCell = new EntryCell
                        {
                            Label = "Contraseña", LabelColor = Color.Black,
                            Placeholder = "add Contraseña",
                            Text = user.Contraseña                            
                        }),
                        (nombreCell = new EntryCell
                        {
                            Label = "Nombre", LabelColor = Color.Black,
                            Placeholder = "add Nombre",
                            Text = user.Nombre
                        }),
                        (apellidoCell = new EntryCell
                        {
                            Label = "Apellido", LabelColor = Color.Black,
                            Placeholder = "add Apellido",
                            Text = user.Apellido
                        }),                        
                        (tipoCell = new EntryCell
                        {
                            Label = "Tipo de usaurio:", LabelColor = Color.Black,
                            Placeholder = "add Tipo",
                            Text = user.Tipo
                        }),
                        (estadoCell = new EntryCell
                        {
                            Label = "Estado", LabelColor = Color.Black,
                            Placeholder = "add Estado",
                            Text = user.Estado
                        }),
                    }
                }
            };

            Button button = new Button()
            {
                BackgroundColor = Color.FromHex("#545454"),
                TextColor = Color.LightGoldenrodYellow,
                BorderWidth = 2,
                BorderColor = Color.FromHex("#353535"),
                FontAttributes = FontAttributes.Bold,
                Text = "Actualizar"
            };

            button.Clicked += OnUpdateUser;

            Content = new StackLayout()
            {
                Spacing = 0,
                Children = {tableView, button}
            };
        }

        private async void OnUpdateUser(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;

            try
            {
                string _email = emailCell.Text;
                string _contraseña = contraseñaCell.Text;
                string _nombre = nombreCell.Text;
                string _apellido = apellidoCell.Text;
                string _tipo = tipoCell.Text;
                string _estado = estadoCell.Text;

                if (string.IsNullOrWhiteSpace(_email)
                    || string.IsNullOrWhiteSpace(_contraseña)
                    || string.IsNullOrWhiteSpace(_nombre)
                    || string.IsNullOrWhiteSpace(_apellido)
                    || string.IsNullOrWhiteSpace(_tipo)
                    || string.IsNullOrWhiteSpace(_estado))
                {
                    await this.DisplayAlert("Faltan datos",
                        "Datos incorrectos y/o inválidos.",
                        "Cancelar");
                }
                else
                {
                    if (_tipo.Equals("Empaque") || _tipo.Equals("Coordinador@"))
                    {
                        user.Email = _email;
                        user.Contraseña = _contraseña;
                        user.Nombre = _nombre;
                        user.Apellido = _apellido;
                        user.Tipo = _tipo;
                        user.Estado = _estado;

                        UsuarioRepository.Instancia.UpdateUser(user);
                        string mensaje = UsuarioRepository
                            .Instancia
                            .EstadoMensaje;

                        await this.DisplayAlert("Estado de usuario",
                            mensaje + ", Usuario actualizado correctamente"
                            , "OK");

                        int pos = users.IndexOf(user);
                        users.RemoveAt(pos);
                        users.Insert(pos, user);
                    }
                    else
                    {
                        await this.DisplayAlert("Aviso:",
                        "Se cancelo la actualización, El tipo de usuario debe ser escrito exactamente como: Empaque o Coordinador@",
                        "Salir");
                    }
                }

                await Navigation.PushAsync(new menuAdmin());

            } catch(Exception e1)
            {
                await this.DisplayAlert("Error", e1.Message, "OK");
            } finally
            {
                button.IsEnabled = true;
            }

        }
    }
}

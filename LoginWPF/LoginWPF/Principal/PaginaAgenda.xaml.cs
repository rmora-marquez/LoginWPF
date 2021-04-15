using LoginWPF.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginWPF.Principal
{
    /// <summary>
    /// Lógica de interacción para PaginaAgenda.xaml
    /// </summary>
    public partial class PaginaAgenda : Page
    {
        ObservableCollection<Persona> personas = new ObservableCollection<Persona>();
        private Persona EditPersona; // == null nueva persona|| !=null actualizar
        private int IndiceEditado;
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public PaginaAgenda()
        {
            InitializeComponent();
            CbGenero.SelectedIndex = 0;
            //personas.Add(new Persona() { Nombre = "Pablo", Email = "pablo@mail.com", Genero = "Hombre" });
            //personas.Add(new Persona() { Nombre = "Marta", Email = "marta@mail.com", Genero = "Mujer" });
            personas = new ObservableCollection<Persona>(usuarioDAO.listar());
            
            ListViewAgenda.ItemsSource = personas;
        }
        //Guardar 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem) CbGenero.SelectedItem;
            string genero = item.Content.ToString();
            
            if(EditPersona == null) //nuevo 
            {
                Persona nuevo = new Persona()
                {
                    Nombre = TxbNombre.Text,
                    Email = TxbEmail.Text,
                    Genero = item.Content.ToString(),            
                };
                
                int insertados = usuarioDAO.alta(nuevo);
                MessageBox.Show("Se insertaron " + insertados + " registros");
                //personas.Add(nuevo);
                //-------------------------------
                //recuperamos los nuevos valores
                personas =  usuarioDAO.listar() ;
                //refrescamos el objeto visual
                ListViewAgenda.ItemsSource = personas;
            }
            else //actualizar existente
            {
                EditPersona.Nombre = TxbNombre.Text;
                EditPersona.Email = TxbEmail.Text;
                EditPersona.Genero = genero;
                //EditPersona.ImagenGenero = cadenaImagen;
                //personas[IndiceEditado] = EditPersona;
                //actualizamos contra la base de datos
                int actualizados = usuarioDAO.actualizar(EditPersona);
                Console.WriteLine("se actualizaron " + actualizados + " registros");
                MessageBox.Show("se actualizaron " + actualizados + " registros");
                //recuperamos los datos actualizados
                personas = usuarioDAO.listar();
                ListViewAgenda.ItemsSource = personas;
                EditPersona = null;
                IndiceEditado = 0;
            }
            
            TxbEmail.Text = "";
            TxbNombre.Text = "";
            CbGenero.SelectedIndex = 0;
            EditPersona = null;
            IndiceEditado = 0;
        }
        //BORRAR
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             Persona p = (Persona) ListViewAgenda.SelectedItem;
             MessageBoxResult result = MessageBox
               .Show("¿Esta seguro de borrar la persona?", "Borrar",
               MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                //personas.Remove(p);
                int borrados = usuarioDAO.borrar(p.Id);
                MessageBox.Show(borrados + " usuarios borrados");

                personas = usuarioDAO.listar();
                ListViewAgenda.ItemsSource = personas;
            }
        }
        //Editar
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EditPersona =(Persona) ListViewAgenda.SelectedItem;
            IndiceEditado = personas.IndexOf(EditPersona);

            TxbNombre.Text = EditPersona.Nombre;
            TxbEmail.Text = EditPersona.Email;
            CbGenero.SelectedIndex = (EditPersona.Genero == "Hombre") ? 0 : 1;
            //if (EditPersona.Genero == "Hombre") CbGenero.SelectedIndex = 0;
            //else CbGenero.SelectedIndex = 1;
        }
    }

    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string ImagenGenero { get; set; }
        public bool Activo { get; set; }
    }
}

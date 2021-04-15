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
using System.Windows.Shapes;

namespace LoginWPF
{
    /// <summary>
    /// Lógica de interacción para VentanaAgenda.xaml
    /// </summary>
    public partial class VentanaAgenda : Window
    {
        private ObservableCollection<Persona2> personas 
            = new ObservableCollection<Persona2>();
        private Persona2 editPersona;
        private int selected;
        public VentanaAgenda()
        {
            InitializeComponent();
            listview1.ItemsSource = personas;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cadena;
            ComboBoxItem item = (ComboBoxItem) genero.SelectedItem;
            if (item.Content.ToString() == "varon")
            {
                cadena = "/LoginWPF;component/Imagenes/man.png";
            }
            else
            {
                cadena = "/LoginWPF;component/Imagenes/woman.png";
            }
            
            if (editPersona == null || editPersona.Nombre == null)
            {
                Persona2 persona = new Persona2 { Nombre = nombre.Text, EMail = mail.Text, Genero = cadena };
                personas.Add(persona);
            }
            else            
            {
                editPersona.EMail = mail.Text;
                editPersona.Nombre = nombre.Text;
                editPersona.Genero = cadena;                
                personas[selected] = editPersona;                
                
                personas = new ObservableCollection<Persona2>(personas);
                listview1.ItemsSource = personas;
                editPersona = null;
                              
            }
            
            
            nombre.Text = "";
            mail.Text = "";
            genero.SelectedIndex = 0;
            nombre.Focus();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {            
            editPersona = (Persona2)listview1.SelectedItem;
            selected = personas.IndexOf(editPersona);
            nombre.Text = editPersona.Nombre;
            mail.Text = editPersona.EMail;
            genero.SelectedIndex = editPersona.Genero.EndsWith("man.png") ? 0 : 1;            
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {
            Persona2 persona = (Persona2)listview1.SelectedItem;
            MessageBoxResult Result = MessageBox.Show("¿Esta seguro de borrar esta persona?", "Cuidado borrado", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(Result == MessageBoxResult.Yes)
            {
                personas.Remove(persona);
            }
            if (Result == MessageBoxResult.No) {
                Console.WriteLine("no se borro");
            }
        }
    }

    public class Persona2
    {
        public string Nombre { get; set; }
        public string EMail { get; set; }
        public string Genero { get; set; }
    }
}

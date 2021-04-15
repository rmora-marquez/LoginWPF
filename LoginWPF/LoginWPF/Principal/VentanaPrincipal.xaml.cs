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

namespace LoginWPF.Principal
{
    /// <summary>
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        private readonly PaginaPrincipal pagPrincipal = new PaginaPrincipal();
        private readonly PaginaAcercaDe pagAcercade = new PaginaAcercaDe();
        private readonly PaginaAgenda pagAgenda = new PaginaAgenda();

        private ObservableCollection<Pais> paises = new ObservableCollection<Pais>();
        public VentanaPrincipal()
        {
            InitializeComponent();
            // FramePrincipal.NavigationService.Navigate( pagPrincipal );
            FramePrincipal.Content = pagPrincipal;
            cargarListViewv2();
        }

        private void BotonPrincipal_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(pagPrincipal);
        }

        private void BotonAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate( pagAcercade );

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BotonAcercaDe_Click(sender, e);
            //FramePrincipal.NavigationService.Navigate(pagAcercade);
        }

        private void cargarListViewv1()
        {
            paises.Add(new Pais { Nombre = "Argentina", CantidadHabitantes = 40000000 });
            paises.Add(new Pais { Nombre = "Chile", CantidadHabitantes = 17000000 });
            paises.Add(new Pais { Nombre = "Bolivia", CantidadHabitantes = 10000000 });
            paises.Add(new Pais { Nombre = "Perú", CantidadHabitantes = 30000000 });
            paises.Add(new Pais { Nombre = "Ecuador", CantidadHabitantes = 16000000 });
            paises.Add(new Pais { Nombre = "Paraguay", CantidadHabitantes = 7000000 });
            paises.Add(new Pais { Nombre = "Uruguay", CantidadHabitantes = 3000000 });
            paises.Add(new Pais { Nombre = "Brasil", CantidadHabitantes = 200000000 });
            paises.Add(new Pais { Nombre = "Venezuela", CantidadHabitantes = 30000000 });
            paises.Add(new Pais { Nombre = "Colombia", CantidadHabitantes = 48000000 });
            paises.Add(new Pais { Nombre = "Surinam", CantidadHabitantes = 500000 });
            paises.Add(new Pais { Nombre = "Guyana", CantidadHabitantes = 800000 });
            paises.Add(new Pais { Nombre = "Guyana Francesa", CantidadHabitantes = 250000 });
            listView1.ItemsSource = paises;
        }

        private void cargarListViewv2()
        {
            paises.Add(new Pais { Nombre = "Argentina", CantidadHabitantes = 40000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Chile", CantidadHabitantes = 17000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Bolivia", CantidadHabitantes = 10000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Perú", CantidadHabitantes = 30000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Ecuador", CantidadHabitantes = 16000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Paraguay", CantidadHabitantes = 7000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Uruguay", CantidadHabitantes = 3000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Brasil", CantidadHabitantes = 200000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Venezuela", CantidadHabitantes = 30000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Colombia", CantidadHabitantes = 48000000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Surinam", CantidadHabitantes = 500000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            paises.Add(new Pais { Nombre = "Guyana", CantidadHabitantes = 800000, Archivo = "/LoginWPF;component/imagenes/Estadisticas.PNG" });
            paises.Add(new Pais { Nombre = "Guyana Francesa", CantidadHabitantes = 250000, Archivo = "/LoginWPF;component/imagenes/Agregar.PNG" });
            listView1.ItemsSource = paises;
        }

        private void listView1_Selected(object sender, RoutedEventArgs e)
        {
            Pais pais = (Pais)(e.Source);
            textBox1.Text = pais.Nombre + "(" + pais.CantidadHabitantes + ")";
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pais pais = (Pais) listView1.SelectedItem;
            textBox1.Text = pais.Nombre + "(" + pais.CantidadHabitantes + ")";
        }

        private void BotonAgenda_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(pagAgenda);
        }
    }


    public class Pais
    {
        public string Nombre { get; set; }
        public int CantidadHabitantes { get; set; }
        public string Archivo { get; set; }
    }
}

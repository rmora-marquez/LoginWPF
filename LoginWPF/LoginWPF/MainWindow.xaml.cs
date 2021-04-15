using LoginWPF.LogicaNegocio;
using LoginWPF.Principal;
using System;
using System.Collections.Generic;
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

namespace LoginWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServicioLogin servicio = new ServicioLogin();
            string usuario = TbxUsername.Text;
            string password = TbxPassword.Password;

            if(servicio.CheckBD(usuario, password))
            {
                //MessageBox.Show("Felicidades entraste");                
                new VentanaPrincipal().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Intente de nuevo");
            }
        }
    }
}

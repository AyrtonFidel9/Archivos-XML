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
using MahApps.Metro.Controls;


namespace WpfAppDataSet
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        DataSetBiblioteca objB;
        public MainWindow()
        {
            InitializeComponent();
            objB = new DataSetBiblioteca();
           // objB.WriteXml("../../Archivos/Autores.xml");
            //objB.WriteXml("../../Archivos/Libros.xml");
            //objB.WriteXml("../../Archivos/Prestamos.xml");

        }


        private void Navegacion_Navigated(object sender, NavigationEventArgs e)
        {
            //Navegacion.Source = (new Uri("/WpfAppDataSet;component/Pages/Usuarios.xaml", UriKind.Relative));
        }

        public void navegar(string pagina)
        {
            if(pagina == "usuarios")
            {
                UsuariosPanel.Visibility = Visibility.Hidden;
            }
            
        }

        private void Navegacion_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if ((e.NavigationMode == NavigationMode.Refresh) &&
            (e.Uri.OriginalString == "/Pages/Usuarios.xaml"))
                {
                    e.Cancel = true;
                MessageBox.Show("me ejecute navigatting");
                }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {

            navegar("usuarios");
            //Navegacion.Source = (new Uri("/WpfAppDataSet;component/Pages/Usuarios.xaml", UriKind.Relative));
        }
    }
}

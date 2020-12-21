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
using WpfAppDataSet.Ventanas;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace WpfAppDataSet.Controles
{
    /// <summary>
    /// Lógica de interacción para ucAutores.xaml
    /// </summary>
    public partial class ucAutores : UserControl
    {
        public ucAutores()
        {
            InitializeComponent();
        }

        private void btnAgregarAutor_Click(object sender, RoutedEventArgs e)
        {
            AgregarAutor autor = new AgregarAutor("ingresar");
            autor.ShowDialog();
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            busquedaUsuario autor = new busquedaUsuario("modificarAutor");
            MetroWindow window = Window.GetWindow(this) as MetroWindow;
            if (window != null)
            {
                await window.ShowMetroDialogAsync(autor);
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            busquedaUsuario autor = new busquedaUsuario("eliminarAutor");
            MetroWindow window = Window.GetWindow(this) as MetroWindow;
            if (window != null)
            {
                await window.ShowMetroDialogAsync(autor);
            }
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            MostrarAutores autor = new MostrarAutores();
            autor.ShowDialog();
        }
    }
}

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
    /// Lógica de interacción para ucLibros.xaml
    /// </summary>
    public partial class ucLibros : UserControl
    {
        public ucLibros()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarLibro libro = new AgregarLibro("ingreso");
            libro.ShowDialog();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            MostrarLibros libros = new MostrarLibros();
            libros.ShowDialog();
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            busquedaUsuario libro = new busquedaUsuario("modificarLibro");
            MetroWindow window = Window.GetWindow(this) as MetroWindow;
            if (window != null)
            {
                await window.ShowMetroDialogAsync(libro);
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            busquedaUsuario libro = new busquedaUsuario("eliminarLibro");
            MetroWindow window = Window.GetWindow(this) as MetroWindow;
            if (window != null)
            {
                await window.ShowMetroDialogAsync(libro);
            }
        }
    }
}

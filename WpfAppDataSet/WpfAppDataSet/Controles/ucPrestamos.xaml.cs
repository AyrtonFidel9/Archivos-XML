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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfAppDataSet.Controles
{
    /// <summary>
    /// Lógica de interacción para ucPrestamos.xaml
    /// </summary>
    public partial class ucPrestamos : UserControl
    {
        public ucPrestamos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPrestamo prestamo = new AgregarPrestamo("ingreso");
            prestamo.ShowDialog();
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            busquedaUsuario prestamo = new busquedaUsuario("modificarPrestamo");
            MetroWindow window = Window.GetWindow(this) as MetroWindow;
            if (window != null)
            {
                await window.ShowMetroDialogAsync(prestamo);
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            busquedaUsuario prestamo = new busquedaUsuario("eliminarPrestamo");
            MetroWindow window = Window.GetWindow(this) as MetroWindow;
            if (window != null)
            {
                await window.ShowMetroDialogAsync(prestamo);
            }
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            MostrarPrestamo prestamo = new MostrarPrestamo();
            prestamo.ShowDialog();
        }
    }
}

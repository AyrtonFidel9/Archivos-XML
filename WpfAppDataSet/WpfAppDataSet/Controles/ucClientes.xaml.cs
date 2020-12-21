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
using MahApps.Metro.Controls.Dialogs;
using WpfAppDataSet.Ventanas;


namespace WpfAppDataSet.Controles
{
    /// <summary>
    /// Lógica de interacción para ucClientes.xaml
    /// </summary>
    public partial class ucClientes : UserControl
    {
        public ucClientes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            IngresarCliente objIngresar = new IngresarCliente("ingreso");
            objIngresar.ShowDialog();
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            busquedaUsuario objB = new busquedaUsuario("modificar");
            MetroWindow window = Window.GetWindow(this) as MetroWindow;
            if (window != null)
            {
                await window.ShowMetroDialogAsync(objB);
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            busquedaUsuario objB = new busquedaUsuario("eliminar");
            MetroWindow window = Window.GetWindow(this) as MetroWindow;
            if (window != null)
            {
                await window.ShowMetroDialogAsync(objB);
            }
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            mostrarUsuarios objUs = new mostrarUsuarios();
            objUs.ShowDialog();
        }
    }
}

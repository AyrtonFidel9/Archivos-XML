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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para mostrarUsuarios.xaml
    /// </summary>
    public partial class mostrarUsuarios: Window
    {
        DataSetBiblioteca biblioteca;
        public mostrarUsuarios()
        {
            InitializeComponent();
            biblioteca = new DataSetBiblioteca();
            biblioteca.ReadXml("../../Archivos/Usuarios.xml");

            dgUsuarios.ItemsSource = (biblioteca.Usuario.DefaultView);
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataGridCellTarget = (DataGridCell)sender;
           // MessageBox.Show(dataGridCellTarget.Content.ToString());
        }

        private void btnReporte_Click(object sender, RoutedEventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.Show();
        }
    }
}

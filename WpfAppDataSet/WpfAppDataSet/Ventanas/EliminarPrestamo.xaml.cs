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
using System.Threading;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para EliminarPrestamo.xaml
    /// </summary>
    public partial class EliminarPrestamo : MetroWindow
    {
        string id;
        DataSetBiblioteca biblioteca;
        System.Data.DataRow[] buscar;
        public EliminarPrestamo()
        {
            InitializeComponent();
            biblioteca = new DataSetBiblioteca();
            biblioteca.ReadXml("../../Archivos/Prestamos.xml");
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminarDatos();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        public string Id { get => id; set => id = value; }

        private async void eliminarDatos()
        {
            try
            {
                buscar = biblioteca.Prestamos.Select("idPrestamos='" + id + "'");
                await this.ShowMessageAsync("Operación completada",
                    $"Se ha eliminado el prestamo con identficador {buscar[0]["idPrestamos"]}");
                buscar[0].Delete();
                biblioteca.WriteXml("../../Archivos/Prestamos.xml");
                Thread.Sleep(10);
                this.DialogResult = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

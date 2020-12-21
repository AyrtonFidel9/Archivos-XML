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
using System.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para EliminarAutor.xaml
    /// </summary>
    public partial class EliminarAutor : MetroWindow
    {
        string id;
        DataSetBiblioteca biblioteca;
        System.Data.DataRow[] buscar;
        public EliminarAutor()
        {
            InitializeComponent();
            biblioteca = new DataSetBiblioteca();
            biblioteca.ReadXml("../../Archivos/Autores.xml");
        }

        public string Id { get => id; set => id = value; }

        private async void eliminarDatos()
        {
            try
            {
                buscar = biblioteca.Autor.Select("idAutor='" + id + "'");
                await this.ShowMessageAsync("Operación completada",
                    $"Se ha eliminado al autor {buscar[0]["Nombre"]}");
                buscar[0].Delete();
                biblioteca.WriteXml("../../Archivos/Autores.xml");
                Thread.Sleep(10);
                this.DialogResult = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminarDatos();
        }
    }
}

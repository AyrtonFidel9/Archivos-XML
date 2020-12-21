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
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading;
using System.ComponentModel;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para EliminarUsuario.xaml
    /// </summary>
    public partial class EliminarUsuario : MetroWindow
    {
        #region Atributos
        string id;
        DataSetBiblioteca biblioteca;
        System.Data.DataRow[] buscar;
        #endregion
        public EliminarUsuario()
        {
            InitializeComponent();
            biblioteca = new DataSetBiblioteca();
            biblioteca.ReadXml("../../Archivos/Usuarios.xml");
        }

        public string Id { get => id; set => id = value; }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminarDatos();
        }
        #region Funciones
        private async void eliminarDatos()
        {
            try
            {
                buscar = biblioteca.Usuario.Select("idUsuario='" + id + "'");
                await this.ShowMessageAsync("Operación completada",
                    $"Se ha eliminado al usuario {buscar[0]["Nombre"]} {buscar[0]["Apellido"]}");
                buscar[0].Delete();
                biblioteca.WriteXml("../../Archivos/Usuarios.xml");
                Thread.Sleep(10);
                this.DialogResult = false;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message,"Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}

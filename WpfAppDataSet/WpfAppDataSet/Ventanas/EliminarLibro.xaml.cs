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
using System.Collections.ObjectModel;
using WpfAppDataSet.Ventanas;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para EliminarLibro.xaml
    /// </summary>
    public partial class EliminarLibro : MetroWindow
    {
        DataSetBiblioteca biblioteca;
        DataSetBiblioteca autores;
        System.Data.DataRow[] buscar;
        
        private ObservableCollection<User> Autores = new ObservableCollection<User>();
        string id;
        string idAutor;

        public string Id { get => id; set => id = value; }
        public string IdAutor { get => idAutor; set => idAutor = value; }

        public EliminarLibro(string id)
        {
            InitializeComponent();
            biblioteca = new DataSetBiblioteca();
            autores = new DataSetBiblioteca();
            this.DataContext = new User();
            dgAutores.Items.Clear();
            biblioteca.ReadXml("../../Archivos/Libros.xml");
            autores.ReadXml("../../Archivos/Autores.xml");

            
            System.Data.DataRow[] buscar2;
            buscar = biblioteca.Libros.Select("idLibro='" + id + "'");
            for (int i = 0; i < buscar.Length; i++)
            {
                buscar2 = autores.Autor.Select("idAutor='" + buscar[i]["idAutor"] + "'");
                if (buscar2.Length > 0)
                {
                    Autores.Add(new User() { Nombre = buscar2[0]["Nombre"].ToString() });
                }
                
            }
            dgAutores.ItemsSource = Autores;

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private async void eliminarDatos()
        {
            try
            {
                buscar = biblioteca.Libros.Select("idLibro='" + id + "'");
                string titulo = buscar[0]["Titulo"].ToString();
                for (int i = 0; i < buscar.Length; i++)
                {
                    buscar[i].Delete();
                }
                biblioteca.WriteXml("../../Archivos/Libros.xml");
                await this.ShowMessageAsync("Operación completada", $"Se ha eliminado el Libro {titulo}");
                Thread.Sleep(10);
                this.DialogResult = false;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminarDatos();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
           
        }
    }

    public class User
    {
        public string Nombre { get; set; }
    }
}

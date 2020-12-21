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

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para MostrarLibros.xaml
    /// </summary>
    public partial class MostrarLibros : Window
    {
        DataSetBiblioteca biblioteca;
        public MostrarLibros()
        {
            InitializeComponent();
            biblioteca = new DataSetBiblioteca();
            biblioteca.ReadXml("../../Archivos/Libros.xml");
            dgLibros.ItemsSource = biblioteca.Libros.DefaultView;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

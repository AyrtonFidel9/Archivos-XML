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
    /// Lógica de interacción para MostrarAutores.xaml
    /// </summary>
    public partial class MostrarAutores : Window
    {
        DataSetBiblioteca biblioteca;
        public MostrarAutores()
        {
            InitializeComponent();
            biblioteca = new DataSetBiblioteca();
            biblioteca.ReadXml("../../Archivos/Autores.xml");
            dgAutores.ItemsSource = biblioteca.Autor.DefaultView;
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
    }
}

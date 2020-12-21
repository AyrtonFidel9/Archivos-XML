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
    /// Lógica de interacción para MostrarPrestamo.xaml
    /// </summary>
    public partial class MostrarPrestamo : Window
    {
        DataSetBiblioteca biblioteca;
        public MostrarPrestamo()
        {
            InitializeComponent();
            biblioteca = new DataSetBiblioteca();
            biblioteca.ReadXml("../../Archivos/Prestamos.xml");
            dgPrestamos.ItemsSource = biblioteca.Prestamos.DefaultView;
        }

        private void btnReporte_Click(object sender, RoutedEventArgs e)
        {
            ReportePrestamos prestamos = new ReportePrestamos();
            prestamos.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

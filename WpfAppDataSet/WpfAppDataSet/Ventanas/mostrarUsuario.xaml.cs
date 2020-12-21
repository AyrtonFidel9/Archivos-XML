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
    /// Lógica de interacción para mostrarUsuario.xaml
    /// </summary>
    public partial class mostrarUsuario : MetroWindow
    {
        public mostrarUsuario()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

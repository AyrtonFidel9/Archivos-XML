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
using WpfAppDataSet.Clases;
using WpfAppDataSet.Controles;
using System.Threading;
using System.ComponentModel;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para AgregarAutor.xaml
    /// </summary>
    public partial class AgregarAutor : MetroWindow
    {
        DataSetBiblioteca objBibli;
        string modo;
        string id;

        public string Id { get => id; set => id = value; }

        public AgregarAutor(string modo)
        {
            InitializeComponent();
            objBibli = new DataSetBiblioteca();
            this.modo = modo;
            if (modo == "ingreso")
            {
                txtIdAutor.Focus();
                txtIdAutor.IsEnabled = true;
                VentanaIngreso.Title = "Ingresar Usuario";
                btnIngresarAutor.Content = "Ingresar";
                btnRegresar.Content = "Regresar";
            }
            else if (modo == "modificar")
            {
                txtIdAutor.IsEnabled = false;
                VentanaIngreso.Title = "Modificar Usuario";
                btnIngresarAutor.Content = "Modificar";
                btnRegresar.Content = "Cancelar";
            }
            objBibli.ReadXml("../../Archivos/Autores.xml");
            
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnIngresarAutor_Click(object sender, RoutedEventArgs e)
        {
            if(modo == "ingresar")
            {
                IngresoDatos();
            }
            else if(modo == "modificar")
            {
                ModificarDatos();
            }
            
        }

        private async void IngresoDatos()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            Validaciones objVal = new Validaciones();
            try
            {

                try
                {

                    if (objVal.idValidacion(txtIdAutor.Text) &&
                    objVal.cadenas(txtNombreCompleto.Text) && 
                    cmdNacionalidad.SelectedItem != null)
                    {
                        btnRegresar.IsEnabled = false;
                        btnIngresarAutor.IsEnabled = false;

                        System.Data.DataRow[] buscar;
                        buscar = objBibli.Autor.Select("idAutor='" + txtIdAutor.Text + "'");
                        if (buscar.Length <= 0)
                        {
                            object[] autor = new object[3];
                            autor[0] = txtIdAutor.Text;
                            autor[1] = txtNombreCompleto.Text;
                            ComboBoxItem cbi = (ComboBoxItem)cmdNacionalidad.SelectedItem;
                            string str1 = cbi.Content.ToString();
                            autor[2] = str1;
                            objBibli.Autor.Rows.Add(autor);
                            objBibli.WriteXml("../../Archivos/Autores.xml");
                            worker.RunWorkerAsync();
                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "El ID ingresado ya se encuentra registrado");

                            txtIdAutor.Clear();
                            txtIdAutor.Focus();
                            btnRegresar.IsEnabled = true;
                            btnIngresarAutor.IsEnabled = true;
                        }

                    }
                }
                catch (Exception error)
                {

                    await this.ShowMessageAsync("Error", error.Message);

                    btnRegresar.IsEnabled = true;
                    btnIngresarAutor.IsEnabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void ModificarDatos()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            try
            {
                Validaciones objVal = new Validaciones();
                if (objVal.idValidacion(txtIdAutor.Text) &&
                    objVal.cadenas(txtNombreCompleto.Text) &&
                    cmdNacionalidad.SelectedItem != null)
                {
                    try
                    {
                        btnRegresar.IsEnabled = false;
                        btnIngresarAutor.IsEnabled = false;

                        System.Data.DataRow[] modificar;
                        modificar = objBibli.Autor.Select("idAutor='" + id + "'");
                        modificar[0]["idAutor"] = txtIdAutor.Text;
                        modificar[0]["Nombre"] = txtNombreCompleto.Text;
                        ComboBoxItem cbi = (ComboBoxItem)cmdNacionalidad.SelectedItem;
                        string str1 = cbi.Content.ToString();
                        modificar[0]["Nacionalidad"] = str1;
                        modificar[0].AcceptChanges();
                        objBibli.WriteXml("../../Archivos/Autores.xml");
                        worker.RunWorkerAsync();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
  
                        btnRegresar.IsEnabled = true;
                        btnIngresarAutor.IsEnabled = true;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(10);

            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            status.Value = e.ProgressPercentage;
            if (status.Value == 100)
            {
                
                Thread.Sleep(20);

                if(modo == "modificar")
                {
                    this.DialogResult = false;
                }
                else if(modo == "ingresar")
                {
                    btnRegresar.IsEnabled = true;
                    btnIngresarAutor.IsEnabled = true;
                    limpiar();
                }

            }
        }
        private void limpiar()
        {
            txtNombreCompleto.Clear();
            txtIdAutor.Clear();
            status.Value = 0;
        }

        private void txtIdUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtNombreCompleto.Focus();
            }
        }

        private void txtNombreCompleto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                cmdNacionalidad.Focus();
            }
        }

        private void cmdNacionalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnIngresarAutor.Focus();
            }

        }

        private void btnIngresarAutor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (modo == "ingresar")
                {
                    IngresoDatos();
                }
                else if (modo == "modificar")
                {
                    txtIdAutor.IsEnabled = false;
                    ModificarDatos();
                }
            }
        }
    }
}

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
using System.ComponentModel;
using WpfAppDataSet.Clases;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para AgregarPrestamo.xaml
    /// </summary>
    public partial class AgregarPrestamo : MetroWindow
    {
        DataSetBiblioteca prestamo;
        DataSetBiblioteca libros;
        DataSetBiblioteca usuarios;
        System.Data.DataRow[] modificar;
        string modo;
        string id;

        public string Id { get => id; set => id = value; }

        public AgregarPrestamo(string modo)
        {
            InitializeComponent();
            this.modo = modo;
            prestamo = new DataSetBiblioteca();
            libros = new DataSetBiblioteca();
            usuarios = new DataSetBiblioteca();
            prestamo.ReadXml("../../Archivos/Prestamos.xml");
            libros.ReadXml("../../Archivos/Libros.xml");
            usuarios.ReadXml("../../Archivos/Usuarios.xml");
            dgLibros.ItemsSource = libros.Libros.DefaultView;
            dgUsuarios.ItemsSource = usuarios.Usuario.DefaultView;
            if (modo == "ingreso")
            {
                txtidPrestamo.Focus();
                txtidPrestamo.IsEnabled = true;
                VentanaIngreso.Title = "Agregar Préstamo";
                btnIngresar.Content = "Ingresar";
                btnRegresar.Content = "Regresar";
            }
            else if( modo == "modificar")
            {
                txtidPrestamo.IsEnabled = false;
                VentanaIngreso.Title = "Modificar Préstamo";
                btnIngresar.Content = "Modificar";
                btnRegresar.Content = "Cancelar";

            }
            
        }

        private void btnRegrear_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
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
                    if (objVal.idValidacion(txtidPrestamo.Text) &&
                    tbxidLibro.Text != "" && tbxidUsuario.Text != "" &&
                    fecDEV.SelectedDateTime != null && fecPres.SelectedDateTime != null)
                    {
                        if(fecDEV.SelectedDateTime > fecPres.SelectedDateTime)
                        {
                            btnRegresar.IsEnabled = false;
                            btnIngresar.IsEnabled = false;

                            object[] pres = new object[5];
                            pres[0] = txtidPrestamo.Text;
                            pres[1] = tbxidLibro.Text;
                            pres[2] = tbxidUsuario.Text;
                            pres[3] = fecPres.SelectedDateTime.Value;
                            pres[4] = fecDEV.SelectedDateTime.Value;
                            prestamo.Prestamos.Rows.Add(pres);
                            prestamo.WriteXml("../../Archivos/Prestamos.xml");

                            worker.RunWorkerAsync();
                        }
                        else
                        {
                            await this.ShowMessageAsync("¡Atención!","La fecha de devolucion no debe ser inferior a la fecha de inicio del préstamo");
                        }
                       
                    }
                }
                catch (System.Data.ConstraintException error)
                {

                    await this.ShowMessageAsync("Error", error.Message);
                    txtidPrestamo.Clear();
                    txtidPrestamo.Focus();
                    btnRegresar.IsEnabled = true;
                    btnIngresar.IsEnabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btnRegresar.IsEnabled = true;
                btnIngresar.IsEnabled = true;
            }
        }

        private async void modificarDatos()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            try
            {
                Validaciones objVal = new Validaciones();
                if(objVal.idValidacion(txtidPrestamo.Text) &&
                    tbxidLibro.Text != "" && tbxidUsuario.Text != "" &&
                    fecDEV.SelectedDateTime != null && fecPres.SelectedDateTime != null)
                {
                    try
                    {
                        if (fecDEV.SelectedDateTime > fecPres.SelectedDateTime)
                        {
                            btnRegresar.IsEnabled = false;
                            btnIngresar.IsEnabled = false;
                            modificar = prestamo.Prestamos.Select("idPrestamos='" + Id + "'");
                            modificar[0]["idPrestamos"] = txtidPrestamo.Text;
                            modificar[0]["idLibro"] = tbxidLibro.Text;
                            modificar[0]["idUsuario"] = tbxidUsuario.Text;
                            modificar[0]["FecPrestamo"] = fecPres.SelectedDateTime.Value;
                            modificar[0]["FecDevolucion"] = fecDEV.SelectedDateTime.Value;
                            modificar[0].AcceptChanges();
                            prestamo.WriteXml("../../Archivos/Prestamos.xml");
                            worker.RunWorkerAsync();
                        }
                        else
                        {
                            await this.ShowMessageAsync("¡Atención!", "La fecha de devolucion no debe ser inferior a la fecha de inicio del préstamo");
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        btnRegresar.IsEnabled = true;
                        btnIngresar.IsEnabled = true;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void limpiar()
        {
            txtidPrestamo.Clear();
            tbxidUsuario.Text = "";
            tbxidLibro.Text = "";
            status.Value = 0;
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
                btnRegresar.IsEnabled = true;
                btnIngresar.IsEnabled = true;
                Thread.Sleep(20);
                limpiar();
                if (modo == "modificar")
                {
                    this.DialogResult = false;
                }

            }
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if(modo == "ingreso")
            {
                IngresoDatos();
            }
            else if(modo == "modificar")
            {
                modificarDatos();
            }
        }

        private void dgUsuarios_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgUsuarios.SelectedItems.Count == 1)
            {
                try
                {
                    System.Data.DataRowView view = (System.Data.DataRowView)dgUsuarios.SelectedItem;
                    string cellvalue = view.Row.ItemArray[0].ToString();
                    tbxidUsuario.Text = cellvalue;
                }
                catch
                {

                }
            }
        }

        private void dgLibros_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgLibros.SelectedItems.Count == 1)
            {
                try
                {
                    System.Data.DataRowView view = (System.Data.DataRowView)dgLibros.SelectedItem;
                    string cellvalue = view.Row.ItemArray[0].ToString();
                    tbxidLibro.Text = cellvalue;
                }
                catch
                {

                }


            }
        }
    }
}

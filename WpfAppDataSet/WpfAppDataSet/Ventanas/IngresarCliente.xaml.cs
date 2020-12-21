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
using System.ComponentModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading;
using WpfAppDataSet.Clases;
using System.Data;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para IngresarCliente.xaml
    /// </summary>
    public partial class IngresarCliente : MetroWindow
    {
        #region Atributos
        string modo;
        System.Data.DataRow[] modificar;
        string id;
        DataSetBiblioteca objBibli;

        #endregion
        public string Id { get => id; set => id = value; }

        public IngresarCliente(string modo)
        {
            InitializeComponent();
            this.modo = modo;
            objBibli = new DataSetBiblioteca();
            objBibli.ReadXml("../../Archivos/Usuarios.xml");
            txtIdUsuario.Focus();
            if (modo == "modificar")
            {
                VentanaIngreso.Title = "Modificar Usuario";
                btnAceptar.Content = "Modificar";
                btnSalir.Content = "Cancelar";
                btnAceptar.UpdateLayout();
                btnSalir.UpdateLayout();
                txtIdUsuario.IsEnabled = false;
            }
            else if(modo == "ingreso")
            {
                VentanaIngreso.Title = "Ingresar Usuario";
                btnAceptar.Content = "Ingresar";
                btnSalir.Content = "Regresar";
                btnAceptar.UpdateLayout();
                btnSalir.UpdateLayout();
            }

        }

        #region Funciones
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
                    if (objVal.idValidacion(txtIdUsuario.Text) &&
                    objVal.cadenas(txtNombre.Text) &&
                    objVal.cadenas(txtApellido.Text) &&
                    (objVal.cedula(txtCedula.Text) && objVal.tamanio(txtCedula.Text)) &&
                    objVal.cadenas(txtDireccion.Text) &&
                    (objVal.cedula(txtTelefono.Text) && objVal.tamanio(txtTelefono.Text)))
                    {
                        btnSalir.IsEnabled = false;
                        btnAceptar.IsEnabled = false;

                        System.Data.DataRow[] buscar;
                        buscar = objBibli.Usuario.Select("idUsuario='" + txtIdUsuario.Text + "'");
                        if (buscar.Length <= 0)
                        {
                            object[] cliente = new object[6];
                            cliente[0] = txtIdUsuario.Text;
                            cliente[1] = txtNombre.Text;
                            cliente[2] = txtApellido.Text;
                            cliente[3] = txtCedula.Text;
                            cliente[4] = txtDireccion.Text;
                            cliente[5] = txtTelefono.Text;
                            objBibli.Usuario.Rows.Add(cliente);
                            objBibli.WriteXml("../../Archivos/Usuarios.xml");
                            worker.RunWorkerAsync();
                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "El ID ingresado ya se encuentra registrado");

                            txtIdUsuario.Clear();
                            txtIdUsuario.Focus();
                            btnAceptar.IsEnabled = true;
                            btnSalir.IsEnabled = true;
                        }

                    }
                }
                catch (Exception error)
                {

                    await this.ShowMessageAsync("Error", error.Message);

                    btnAceptar.IsEnabled = true;
                    btnSalir.IsEnabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void modificarDatos()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            try
            {
                Validaciones objVal = new Validaciones();
                if (objVal.idValidacion(txtIdUsuario.Text) &&
                    objVal.cadenas(txtNombre.Text) &&
                    objVal.cadenas(txtApellido.Text) &&
                    (objVal.cedula(txtCedula.Text) && objVal.tamanio(txtCedula.Text)) &&
                    objVal.cadenas(txtDireccion.Text) &&
                    (objVal.cedula(txtTelefono.Text) && objVal.tamanio(txtTelefono.Text)))
                {
                    try
                    {
                        btnSalir.IsEnabled = false;
                        btnAceptar.IsEnabled = false;
                        modificar = objBibli.Usuario.Select("idUsuario='" + id + "'");
                        modificar[0]["idUsuario"] = txtIdUsuario.Text;
                        modificar[0]["Nombre"] = txtNombre.Text;
                        modificar[0]["Apellido"] = txtApellido.Text;
                        modificar[0]["Cedula"] = txtCedula.Text;
                        modificar[0]["Direccion"] = txtDireccion.Text;
                        modificar[0]["Telefono"] = txtTelefono.Text;
                        modificar[0].AcceptChanges();
                        objBibli.WriteXml("../../Archivos/Usuarios.xml");
                        worker.RunWorkerAsync();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        btnSalir.IsEnabled = true;
                        btnAceptar.IsEnabled = true;
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
            txtNombre.Clear();
            txtApellido.Clear();
            txtIdUsuario.Clear();
            txtCedula.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            status.Value = 0;
        }

        #endregion

        #region Eventos
        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
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
                btnSalir.IsEnabled = true;
                btnAceptar.IsEnabled = true;
                Thread.Sleep(20);
                limpiar();
                if(modo=="modificar")
                {
                    this.DialogResult = false;
                }

            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                txtApellido.Focus();
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtCedula.Focus();
            }
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnAceptar.Focus();
            }
        }

        private void btnAceptar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (modo == "ingreso")
                {
                    IngresoDatos();
                }
                else if (modo == "modificar")
                {
                 
                    modificarDatos();
                }
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtTelefono.Focus();
            }
        }
        private void txtIdUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                txtNombre.Focus();
            }
        }

        #endregion


    }
}

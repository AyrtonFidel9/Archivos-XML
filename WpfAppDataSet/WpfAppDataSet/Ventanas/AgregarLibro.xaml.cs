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
    /// Lógica de interacción para AgregarLibro.xaml
    /// </summary>
    /// 

    public partial class AgregarLibro : MetroWindow
    {
        DataSetBiblioteca autores;
        DataSetBiblioteca libros;
        string modo;
        string id;
        string idAutor;
        int indice;
        public string Id { get => id; set => id = value; }
        public string IdAutor { get => idAutor; set => idAutor = value; }
        public int Indice { get => indice; set => indice = value; }

        public AgregarLibro(string modo)
        {
            InitializeComponent();
            autores = new DataSetBiblioteca();
            libros = new DataSetBiblioteca();
            libros.ReadXml("../../Archivos/Libros.xml");
            autores.ReadXml("../../Archivos/Autores.xml");
            dgAutores.ItemsSource = autores.Autor.DefaultView;

            

            this.modo = modo;
            if (modo == "ingreso")
            {
                txtIdLibro.Focus();
                txtIdLibro.IsEnabled = true;
                VentanaIngreso.Title = "Ingresar Libro";
                btnIngresar.Content = "Ingresar";
                btnRegresar.Content = "Regresar";
            }
            else if (modo == "modificar")
            {
                txtIdLibro.IsEnabled = false;
                VentanaIngreso.Title = "Modificar Libro";
                VentanaIngreso.WindowStartupLocation = WindowStartupLocation.Manual;
                btnIngresar.Content = "Modificar";
                btnRegresar.Content = "Cancelar";
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
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
                    if (objVal.idValidacion(txtIdLibro.Text) &&
                    objVal.cadenas(txtEditorial.Text) &&
                    objVal.camposVacios(txtTitulo.Text) &&
                    objVal.numeros(txtPaginas.Text) &&
                    tbxIdAutor.Text != "")
                    {
                        btnRegresar.IsEnabled = false;
                        btnIngresar.IsEnabled = false;

                        System.Data.DataRow[] buscar;
                        System.Data.DataRow[] buscarAut;
                        buscar = libros.Libros.Select("idLibro='" + txtIdLibro.Text + "'");
                        
                        if (buscar.Length <= 0)
                        {
                            object[] libro = new object[5];
                            libro[0] = txtIdLibro.Text;
                            
                            buscarAut = autores.Autor.Select("idAutor='" + tbxIdAutor.Text + "'");
                            if (buscarAut.Length > 0)
                            {
                                try
                                {
                                    libro[1] = buscarAut[0]["idAutor"].ToString();
                                    buscarAut[0].AcceptChanges();
                                    autores.WriteXml("../../Archivos/Autores.xml");
                                    libro[2] = txtTitulo.Text;
                                    libro[3] = txtEditorial.Text;
                                    libro[4] = txtPaginas.Text;
                                    libros.Libros.Rows.Add(libro);
                                    libros.WriteXml("../../Archivos/Libros.xml");
                                    worker.RunWorkerAsync();
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message);
                                    //System.Data.ForeignKeyConstraint e;
                                    
                                    btnRegresar.IsEnabled = true;
                                    btnIngresar.IsEnabled = true;
                                }
                                
                            }
                            

                        }
                        else if(buscar.Length > 0)
                        {
                            string miId = buscar[0]["idAutor"].ToString();
                            if (miId.Equals(tbxIdAutor.Text) == false)
                            {
                                object[] libro = new object[5];
                                libro[0] = txtIdLibro.Text;
                                libro[1] = tbxIdAutor.Text;
                                libro[2] = txtTitulo.Text;
                                libro[3] = txtEditorial.Text;
                                libro[4] = txtPaginas.Text;

                                libros.Libros.Rows.Add(libro);
                                libros.WriteXml("../../Archivos/Libros.xml");
                                worker.RunWorkerAsync();
                            }
                            else
                            {
                                await this.ShowMessageAsync("Error", "El ID del Autor ya estas asociado al libro de ID: " + txtIdLibro.Text);

                                tbxIdAutor.Text = "";
                                btnRegresar.IsEnabled = true;
                                btnIngresar.IsEnabled = true;
                            }
                        }
                    }
                }
                catch (System.Data.ConstraintException error)
                {

                    await this.ShowMessageAsync("Error", error.Message);
                    txtIdLibro.Clear();
                    txtIdLibro.Focus();
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

        private void ModificarDatos()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            try
            {
                Validaciones objVal = new Validaciones();
                if (objVal.idValidacion(txtIdLibro.Text) &&
                    objVal.cadenas(txtEditorial.Text) &&
                    objVal.camposVacios(txtTitulo.Text) &&
                    objVal.numeros(txtPaginas.Text) &&
                    tbxIdAutor.Text != "")
                {
                    try
                    {
                        btnRegresar.IsEnabled = false;
                        btnIngresar.IsEnabled = false;

                        System.Data.DataRow[] modificar;
                        //System.Data.DataRow[] modificar2;
                        modificar = libros.Libros.Select("idLibro='" + id + "'");
                       // modificar2 = libros.Libros.Select("idAutor='" + idAutor + "'");
                        if(modificar[indice]["idAutor"].ToString() == idAutor)
                        {
                            modificar[indice]["idLibro"] = txtIdLibro.Text;
                            modificar[indice]["idAutor"] = tbxIdAutor.Text;
                            modificar[indice]["Titulo"] = txtTitulo.Text;
                            modificar[indice]["Editorial"] = txtEditorial.Text;
                            modificar[indice]["NumPags"] = txtPaginas.Text;
                            modificar[indice].AcceptChanges();
                            libros.WriteXml("../../Archivos/Libros.xml");
                            worker.RunWorkerAsync();
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
                btnRegresar.IsEnabled = true;
                btnIngresar.IsEnabled = true;
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
                btnRegresar.IsEnabled = true;
                btnIngresar.IsEnabled = true;
                Thread.Sleep(20);

                if (modo == "modificar")
                {
                    this.DialogResult = false;
                }
                else if (modo == "ingreso")
                {
                    
                    limpiar();
                }

            }
        }
        private void limpiar()
        {
            txtEditorial.Clear();
            txtIdLibro.Clear();
            tbxIdAutor.Text = "";
            txtPaginas.Clear();
            txtTitulo.Clear();
            status.Value = 0;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (modo == "ingreso")
            {
                IngresoDatos();
            }
            else if (modo == "modificar")
            {
                ModificarDatos();
            }
            
        }

        private void dgAutores_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgAutores.SelectedItems.Count == 1)
            {
                try
                {
                    System.Data.DataRowView view = (System.Data.DataRowView)dgAutores.SelectedItem;
                    string cellvalue = view.Row.ItemArray[0].ToString();
                    tbxIdAutor.Text = cellvalue;
                }
                catch
                {

                }
                

            }
        }

        private void txtIdLibro_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                txtTitulo.Focus();
            }

        }

        private void txtTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtEditorial.Focus();
            }
        }

        private void txtEditorial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPaginas.Focus();
            }
        }

        private void txtPaginas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnIngresar.Focus();
            }
        }

        private void tbxIdAutor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (modo == "ingreso")
                {
                    IngresoDatos();
                }
                else if (modo == "modificar")
                {
                    ModificarDatos();
                }
            }
        }
    }   
}

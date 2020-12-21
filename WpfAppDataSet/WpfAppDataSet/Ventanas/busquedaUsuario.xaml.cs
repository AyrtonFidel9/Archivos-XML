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
using System.Threading;
using System.ComponentModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfAppDataSet.Ventanas
{
    /// <summary>
    /// Lógica de interacción para busquedaUsuario.xaml
    /// </summary>
    public partial class busquedaUsuario : CustomDialog
    {
        #region Atributos
        DataSetBiblioteca objBiblioteca; //se crea un objeto del dataset
        System.Data.DataRow[] buscar; //datarow para buscar un elemento del archivo XML
        string operacion;
        #endregion
        public busquedaUsuario(string operacion)
        {
            InitializeComponent();
            objBiblioteca = new DataSetBiblioteca();
            if(operacion == "modificar" || operacion == "eliminar")
            {
                objBiblioteca.ReadXml("../../Archivos/Usuarios.xml"); //se llama al archivo XML, se lo lee
            }
            else if(operacion == "modificarAutor" || operacion == "eliminarAutor")
            {
                subtitulo.Text = "Ingrese el ID del Autor";
                objBiblioteca.ReadXml("../../Archivos/Autores.xml");
            }
            else if(operacion == "modificarLibro" || operacion == "eliminarLibro")
            {
                subtitulo.Text = "Ingrese el ID del Libro";
                objBiblioteca.ReadXml("../../Archivos/Libros.xml");
            }
            else if(operacion == "modificarPrestamo" || operacion == "eliminarPrestamo")
            {
                subtitulo.Text = "Ingrese el ID del Préstamo";
                objBiblioteca.ReadXml("../../Archivos/Prestamos.xml");
            }
            
            txtBuscarByID.Focus();
            this.operacion = operacion;
        }

        #region Eventos
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
                operacionBuscar();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(15);
            }
        }

        async void  worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            status.Value = e.ProgressPercentage;
            if (status.Value == 100)
            {
                btnBuscar.IsEnabled = true;
                if (operacion == "modificar")
                {
                    IngresarCliente objIngresar = new IngresarCliente("modificar");
                    objIngresar.txtIdUsuario.Text = buscar[0]["idUsuario"].ToString();
                    objIngresar.txtNombre.Text = buscar[0]["Nombre"].ToString();
                    objIngresar.txtApellido.Text = buscar[0]["Apellido"].ToString();
                    objIngresar.txtCedula.Text = buscar[0]["Cedula"].ToString();
                    objIngresar.txtDireccion.Text = buscar[0]["Direccion"].ToString();
                    objIngresar.txtTelefono.Text = buscar[0]["Telefono"].ToString();
                    objIngresar.Id = buscar[0]["idUsuario"].ToString();
                    await (this.OwningWindow
                    ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);

                    objIngresar.ShowDialog();
                }
                else if (operacion == "eliminar")
                {
                    EliminarUsuario eliminar = new EliminarUsuario();
                    eliminar.ucMostrarUsuarios.tbxIdUsuario.Text = buscar[0]["idUsuario"].ToString();
                    eliminar.ucMostrarUsuarios.tbxNombre.Text = buscar[0]["Nombre"].ToString();
                    eliminar.ucMostrarUsuarios.tbxApellido.Text = buscar[0]["Apellido"].ToString();
                    eliminar.ucMostrarUsuarios.tbxCedula.Text = buscar[0]["Cedula"].ToString();
                    eliminar.ucMostrarUsuarios.tbxDireccion.Text = buscar[0]["Direccion"].ToString();
                    eliminar.ucMostrarUsuarios.tbxTelefono.Text = buscar[0]["Telefono"].ToString();
                    eliminar.Id = buscar[0]["idUsuario"].ToString();
                    await (this.OwningWindow
                    ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);

                    eliminar.ShowDialog();
                } else if (operacion == "modificarAutor")
                {
                    AgregarAutor modificar = new AgregarAutor("modificar");
                    modificar.txtIdAutor.Text = buscar[0]["idAutor"].ToString();
                    modificar.txtNombreCompleto.Text = buscar[0]["Nombre"].ToString();
                    modificar.cmdNacionalidad.Text = buscar[0]["Nacionalidad"].ToString();
                    modificar.Id = buscar[0]["idAutor"].ToString();
                    await (this.OwningWindow
                    ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);

                    modificar.ShowDialog();
                }
                else if (operacion == "eliminarAutor")
                {
                    EliminarAutor eliminar = new EliminarAutor();
                    eliminar.tbxIdAutor.Text = buscar[0]["idAutor"].ToString();
                    eliminar.tbxNombreCompleto.Text = buscar[0]["Nombre"].ToString();
                    eliminar.tbxNacionalidad.Text = buscar[0]["Nacionalidad"].ToString();
                    eliminar.Id = buscar[0]["idAutor"].ToString();
                    await (this.OwningWindow
                    ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);

                    eliminar.ShowDialog();

                }
                else if (operacion == "modificarLibro")
                {
                    for (int i = 0; i < buscar.Length; i++)
                    {
                        AgregarLibro libro = new AgregarLibro("modificar");
                        libro.txtIdLibro.Text = buscar[i]["idLibro"].ToString();
                        libro.txtTitulo.Text = buscar[i]["Titulo"].ToString();
                        libro.txtEditorial.Text = buscar[i]["Editorial"].ToString();
                        libro.txtPaginas.Text = buscar[i]["NumPags"].ToString();
                        libro.tbxIdAutor.Text = buscar[i]["idAutor"].ToString();
                        libro.Id = buscar[i]["idLibro"].ToString();
                        libro.IdAutor = buscar[i]["idAutor"].ToString();
                        libro.Indice = i;
                        if (libro.ShowDialog() != false)
                        {

                        }
                        Thread.Sleep(10);


                    }
                    await (this.OwningWindow
                        ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);

                }
                else if (operacion == "eliminarLibro")
                {
                    List<Users> users = new List<Users>();
                    EliminarLibro libro = new EliminarLibro(buscar[0]["idLibro"].ToString());
                    libro.tbxIdLibro.Text = buscar[0]["idLibro"].ToString();
                    libro.tbxTitulo.Text = buscar[0]["Titulo"].ToString();
                    libro.tbxEditorial.Text = buscar[0]["Editorial"].ToString();
                    libro.tbxPaginas.Text = buscar[0]["NumPags"].ToString();
                    libro.Id = buscar[0]["idLibro"].ToString();

                    await (this.OwningWindow
                        ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);
                    libro.ShowDialog();
                }
                else if (operacion == "modificarPrestamo")
                {
                    AgregarPrestamo prestamo = new AgregarPrestamo("modificar");
                    prestamo.txtidPrestamo.Text = buscar[0]["idPrestamos"].ToString();
                    prestamo.tbxidLibro.Text = buscar[0]["idLibro"].ToString();
                    prestamo.tbxidUsuario.Text = buscar[0]["idUsuario"].ToString();
                    prestamo.fecDEV.SelectedDateTime = (System.DateTime.Parse(buscar[0]["FecDevolucion"].ToString()));
                    prestamo.fecPres.SelectedDateTime = (System.DateTime.Parse(buscar[0]["FecPrestamo"].ToString()));
                    prestamo.Id = buscar[0]["idPrestamos"].ToString();

                    await (this.OwningWindow
                        ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);
                    prestamo.ShowDialog();
                }
                else if(operacion == "eliminarPrestamo")
                {
                    EliminarPrestamo prestamo = new EliminarPrestamo();
                    DataSetBiblioteca libros = new DataSetBiblioteca();
                    DataSetBiblioteca usuarios = new DataSetBiblioteca();
                    libros.ReadXml("../../Archivos/Libros.xml");
                    usuarios.ReadXml("../../Archivos/Usuarios.xml");
                    System.Data.DataRow[] libro;
                    System.Data.DataRow[] usuario;
                    libro = libros.Libros.Select("idLibro='" + buscar[0]["idLibro"].ToString() + "'");
                    usuario = usuarios.Usuario.Select("idUsuario='" + buscar[0]["idUsuario"].ToString() + "'");
                    prestamo.tbxidPrestamo.Text = buscar[0]["idPrestamos"].ToString();
                    prestamo.tbxLibro.Text = libro[0]["Titulo"].ToString();
                    prestamo.tbxUsuario.Text = usuario[0]["Nombre"].ToString() + " " + usuario[0]["Apellido"].ToString();
                    prestamo.tbxFecPres.Text = buscar[0]["FecPrestamo"].ToString();
                    prestamo.tbxFecDev.Text = buscar[0]["FecDevolucion"].ToString();
                    prestamo.Id = buscar[0]["idPrestamos"].ToString();

                    await (this.OwningWindow
                       ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);
                    prestamo.ShowDialog();

                }
            }
        }

        private void txtBuscarByID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnBuscar.Focus();
            }
        }

        private void btnBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                    operacionBuscar();
            }
        }

        private async void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            await(this.OwningWindow
                    ?? (MetroWindow)Application.Current.MainWindow).HideMetroDialogAsync(this);
        }

        #endregion

        #region Funciones
        private void operacionBuscar()
        {
            btnBuscar.IsEnabled = false;

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            if(operacion == "modificar" || operacion == "eliminar")
            {
                buscar = objBiblioteca.Usuario.Select("idUsuario='" + txtBuscarByID.Text + "'");
                if (buscar.Length > 0)
                {
                    txtBMensaje.Text = "Usuario encontrado...";
                    worker.RunWorkerAsync();
                }
                else
                {
                    txtBMensaje.Text = "Usuario inexistente...";
                    txtBuscarByID.Clear();
                    txtBuscarByID.Focus();
                    btnBuscar.IsEnabled = true;
                }
            }
            else if(operacion == "modificarAutor" || operacion == "eliminarAutor")
            {
                buscar = objBiblioteca.Autor.Select("idAutor='" + txtBuscarByID.Text + "'");
                if (buscar.Length > 0)
                {
                    txtBMensaje.Text = "Autor encontrado...";
                    worker.RunWorkerAsync();
                }
                else
                {
                    txtBMensaje.Text = "Autor inexistente...";
                    txtBuscarByID.Clear();
                    txtBuscarByID.Focus();
                    btnBuscar.IsEnabled = true;
                }
            }
            else if (operacion == "modificarLibro" || operacion == "eliminarLibro")
            {
                buscar = objBiblioteca.Libros.Select("idLibro='" + txtBuscarByID.Text + "'");
                if (buscar.Length > 0)
                {
                    txtBMensaje.Text = "Libro encontrado...";
                    worker.RunWorkerAsync();
                }
                else
                {
                    txtBMensaje.Text = "Libro inexistente...";
                    txtBuscarByID.Clear();
                    txtBuscarByID.Focus();
                    btnBuscar.IsEnabled = true;
                }
            }
            else if(operacion == "modificarPrestamo" || operacion == "eliminarPrestamo")
            {
                buscar = objBiblioteca.Prestamos.Select("idPrestamos='" + txtBuscarByID.Text + "'");
                if (buscar.Length > 0)
                {
                    txtBMensaje.Text = "Préstamo encontrado...";
                    worker.RunWorkerAsync();
                }
                else
                {
                    txtBMensaje.Text = "Préstamo inexistente...";
                    txtBuscarByID.Clear();
                    txtBuscarByID.Focus();
                    btnBuscar.IsEnabled = true;
                }
            }


        }
        #endregion
    }
    public class Users
    {
        public string Name { get; set; }
    }
}

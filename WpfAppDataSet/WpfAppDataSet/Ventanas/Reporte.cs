﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfAppDataSet.Ventanas
{
    public partial class Reporte : Form
    {
        DataSetBiblioteca Biblioteca;
        public Reporte()
        {
            InitializeComponent();
            Biblioteca = new DataSetBiblioteca();
            dataSetBiblioteca.ReadXml("../../Archivos/Usuarios.xml");
  
        }

        private void Reporte_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

        }
    }
}

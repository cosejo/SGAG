using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ITCR.SGAG.Reportes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'SGAG_BDDataSet.pr_SGPRINGRESO_SeleccionarTodos_Por_Fechas' Puede moverla o quitarla según sea necesario.
            this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasTableAdapter.Fill(this.SGAG_BDDataSet.pr_SGPRINGRESO_SeleccionarTodos_Por_Fechas);
            this.reportViewer1.RefreshReport();
        }
    }
}
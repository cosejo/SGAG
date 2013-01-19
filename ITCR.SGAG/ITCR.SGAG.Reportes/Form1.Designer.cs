namespace ITCR.SGAG.Reportes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Windows Form Designer

        /// <summary>
        /// Método necesario para admitir el Designer. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SGAG_BDDataSet = new ITCR.SGAG.Reportes.SGAG_BDDataSet();
            this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasTableAdapter = new ITCR.SGAG.Reportes.SGAG_BDDataSetTableAdapters.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SGAG_BDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ITCR.SGAG.Reportes.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 386);
            this.reportViewer1.TabIndex = 0;
            // 
            // SGAG_BDDataSet
            // 
            this.SGAG_BDDataSet.DataSetName = "SGAG_BDDataSet";
            this.SGAG_BDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pr_SGPRINGRESO_SeleccionarTodos_Por_FechasBindingSource
            // 
            this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasBindingSource.DataMember = "pr_SGPRINGRESO_SeleccionarTodos_Por_Fechas";
            this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasBindingSource.DataSource = this.SGAG_BDDataSet;
            // 
            // pr_SGPRINGRESO_SeleccionarTodos_Por_FechasTableAdapter
            // 
            this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SGAG_BDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource pr_SGPRINGRESO_SeleccionarTodos_Por_FechasBindingSource;
        private SGAG_BDDataSet SGAG_BDDataSet;
        private SGAG_BDDataSetTableAdapters.pr_SGPRINGRESO_SeleccionarTodos_Por_FechasTableAdapter pr_SGPRINGRESO_SeleccionarTodos_Por_FechasTableAdapter;
    }
}


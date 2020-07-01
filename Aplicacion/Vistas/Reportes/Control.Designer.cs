namespace Aplicacion.Vistas.Reportes
{
    partial class Control
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this._dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._chlFiltros = new System.Windows.Forms.CheckedListBox();
            this._cbxEmpleados = new System.Windows.Forms.ComboBox();
            this._chbRegistros = new System.Windows.Forms.CheckBox();
            this._chbTodos = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio";
            // 
            // _dtpInicio
            // 
            this._dtpInicio.CustomFormat = "dd-MM-yyyy HH-mm";
            this._dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpInicio.Location = new System.Drawing.Point(53, 82);
            this._dtpInicio.Name = "_dtpInicio";
            this._dtpInicio.Size = new System.Drawing.Size(130, 20);
            this._dtpInicio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Salida";
            // 
            // _dtpEnd
            // 
            this._dtpEnd.CustomFormat = "dd-MM-yyyy HH-mm";
            this._dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpEnd.Location = new System.Drawing.Point(53, 108);
            this._dtpEnd.Name = "_dtpEnd";
            this._dtpEnd.Size = new System.Drawing.Size(130, 20);
            this._dtpEnd.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(478, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._chlFiltros);
            this.groupBox1.Controls.Add(this._cbxEmpleados);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this._chbRegistros);
            this.groupBox1.Controls.Add(this._chbTodos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._dtpEnd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._dtpInicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración del Reporte";
            // 
            // _chlFiltros
            // 
            this._chlFiltros.FormattingEnabled = true;
            this._chlFiltros.Items.AddRange(new object[] {
            "Total de Horas",
            "Total de Horas Extras",
            "Ganancias",
            "Valor Horario",
            "Dias Trabajados"});
            this._chlFiltros.Location = new System.Drawing.Point(264, 20);
            this._chlFiltros.Name = "_chlFiltros";
            this._chlFiltros.Size = new System.Drawing.Size(289, 79);
            this._chlFiltros.TabIndex = 4;
            // 
            // _cbxEmpleados
            // 
            this._cbxEmpleados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxEmpleados.FormattingEnabled = true;
            this._cbxEmpleados.Location = new System.Drawing.Point(91, 44);
            this._cbxEmpleados.Name = "_cbxEmpleados";
            this._cbxEmpleados.Size = new System.Drawing.Size(147, 21);
            this._cbxEmpleados.TabIndex = 2;
            // 
            // _chbRegistros
            // 
            this._chbRegistros.AutoSize = true;
            this._chbRegistros.Checked = true;
            this._chbRegistros.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chbRegistros.Location = new System.Drawing.Point(264, 108);
            this._chbRegistros.Name = "_chbRegistros";
            this._chbRegistros.Size = new System.Drawing.Size(70, 17);
            this._chbRegistros.TabIndex = 1;
            this._chbRegistros.Text = "Registros";
            this._chbRegistros.UseVisualStyleBackColor = true;
            // 
            // _chbTodos
            // 
            this._chbTodos.AutoSize = true;
            this._chbTodos.Checked = true;
            this._chbTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chbTodos.Location = new System.Drawing.Point(6, 21);
            this._chbTodos.Name = "_chbTodos";
            this._chbTodos.Size = new System.Drawing.Size(130, 17);
            this._chbTodos.TabIndex = 1;
            this._chbTodos.Text = " Todos los Empleados";
            this._chbTodos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Empleado";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Control";
            this.Size = new System.Drawing.Size(566, 510);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _dtpInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker _dtpEnd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox _chlFiltros;
        private System.Windows.Forms.ComboBox _cbxEmpleados;
        private System.Windows.Forms.CheckBox _chbRegistros;
        private System.Windows.Forms.CheckBox _chbTodos;
        private System.Windows.Forms.Label label3;
    }
}

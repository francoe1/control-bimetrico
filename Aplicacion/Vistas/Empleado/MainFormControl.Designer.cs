namespace Aplicacion.Vistas.Empleado
{
    partial class MainFormControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnNuevo = new System.Windows.Forms.Button();
            this._btnActualizar = new System.Windows.Forms.Button();
            this._table = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._btnRegistros = new System.Windows.Forms.Button();
            this._btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._table)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnNuevo
            // 
            this._btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnNuevo.FlatAppearance.BorderSize = 0;
            this._btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnNuevo.ForeColor = System.Drawing.Color.White;
            this._btnNuevo.Location = new System.Drawing.Point(4, 4);
            this._btnNuevo.Name = "_btnNuevo";
            this._btnNuevo.Size = new System.Drawing.Size(75, 23);
            this._btnNuevo.TabIndex = 0;
            this._btnNuevo.Text = "Nuevo";
            this._btnNuevo.UseVisualStyleBackColor = false;
            // 
            // _btnActualizar
            // 
            this._btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnActualizar.FlatAppearance.BorderSize = 0;
            this._btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnActualizar.ForeColor = System.Drawing.Color.White;
            this._btnActualizar.Location = new System.Drawing.Point(166, 4);
            this._btnActualizar.Name = "_btnActualizar";
            this._btnActualizar.Size = new System.Drawing.Size(75, 23);
            this._btnActualizar.TabIndex = 0;
            this._btnActualizar.Text = "Actualizar";
            this._btnActualizar.UseVisualStyleBackColor = false;
            // 
            // _table
            // 
            this._table.AllowUserToAddRows = false;
            this._table.AllowUserToDeleteRows = false;
            this._table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.Direccion,
            this.Telefono,
            this.Email});
            this._table.Location = new System.Drawing.Point(4, 33);
            this._table.MultiSelect = false;
            this._table.Name = "_table";
            this._table.ReadOnly = true;
            this._table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._table.Size = new System.Drawing.Size(550, 423);
            this._table.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // _btnRegistros
            // 
            this._btnRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnRegistros.FlatAppearance.BorderSize = 0;
            this._btnRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRegistros.ForeColor = System.Drawing.Color.White;
            this._btnRegistros.Location = new System.Drawing.Point(85, 4);
            this._btnRegistros.Name = "_btnRegistros";
            this._btnRegistros.Size = new System.Drawing.Size(75, 23);
            this._btnRegistros.TabIndex = 0;
            this._btnRegistros.Text = "Registros";
            this._btnRegistros.UseVisualStyleBackColor = false;
            // 
            // _btnEliminar
            // 
            this._btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnEliminar.FlatAppearance.BorderSize = 0;
            this._btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEliminar.ForeColor = System.Drawing.Color.White;
            this._btnEliminar.Location = new System.Drawing.Point(247, 4);
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(75, 23);
            this._btnEliminar.TabIndex = 0;
            this._btnEliminar.Text = "Eliminar";
            this._btnEliminar.UseVisualStyleBackColor = false;
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._table);
            this.Controls.Add(this._btnRegistros);
            this.Controls.Add(this._btnEliminar);
            this.Controls.Add(this._btnActualizar);
            this.Controls.Add(this._btnNuevo);
            this.Name = "Control";
            this.Size = new System.Drawing.Size(557, 459);
            ((System.ComponentModel.ISupportInitialize)(this._table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnNuevo;
        private System.Windows.Forms.Button _btnActualizar;
        private System.Windows.Forms.DataGridView _table;
        private System.Windows.Forms.Button _btnRegistros;
        private System.Windows.Forms.Button _btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}

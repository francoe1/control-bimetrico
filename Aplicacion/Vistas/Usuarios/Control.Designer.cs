namespace Aplicacion.Vistas.Usuarios
{
    partial class Control
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
            this._table = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._btnNuevo = new System.Windows.Forms.Button();
            this._btnActualizar = new System.Windows.Forms.Button();
            this._btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._table)).BeginInit();
            this.SuspendLayout();
            // 
            // _table
            // 
            this._table.AllowUserToAddRows = false;
            this._table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Email,
            this.Clave});
            this._table.Location = new System.Drawing.Point(3, 32);
            this._table.MultiSelect = false;
            this._table.Name = "_table";
            this._table.ReadOnly = true;
            this._table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._table.Size = new System.Drawing.Size(520, 351);
            this._table.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 62.89308F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.FillWeight = 102.7879F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Clave
            // 
            this.Clave.FillWeight = 134.319F;
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            // 
            // _btnNuevo
            // 
            this._btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnNuevo.FlatAppearance.BorderSize = 0;
            this._btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnNuevo.ForeColor = System.Drawing.Color.White;
            this._btnNuevo.Location = new System.Drawing.Point(3, 3);
            this._btnNuevo.Name = "_btnNuevo";
            this._btnNuevo.Size = new System.Drawing.Size(75, 23);
            this._btnNuevo.TabIndex = 1;
            this._btnNuevo.Text = "Nuevo";
            this._btnNuevo.UseVisualStyleBackColor = false;
            // 
            // _btnActualizar
            // 
            this._btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnActualizar.FlatAppearance.BorderSize = 0;
            this._btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnActualizar.ForeColor = System.Drawing.Color.White;
            this._btnActualizar.Location = new System.Drawing.Point(84, 3);
            this._btnActualizar.Name = "_btnActualizar";
            this._btnActualizar.Size = new System.Drawing.Size(75, 23);
            this._btnActualizar.TabIndex = 1;
            this._btnActualizar.Text = "Actualizar";
            this._btnActualizar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this._btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnEliminar.FlatAppearance.BorderSize = 0;
            this._btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEliminar.ForeColor = System.Drawing.Color.White;
            this._btnEliminar.Location = new System.Drawing.Point(165, 3);
            this._btnEliminar.Name = "button1";
            this._btnEliminar.Size = new System.Drawing.Size(75, 23);
            this._btnEliminar.TabIndex = 1;
            this._btnEliminar.Text = "Eliminar";
            this._btnEliminar.UseVisualStyleBackColor = false;
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnEliminar);
            this.Controls.Add(this._btnActualizar);
            this.Controls.Add(this._btnNuevo);
            this.Controls.Add(this._table);
            this.Name = "Control";
            this.Size = new System.Drawing.Size(526, 386);
            ((System.ComponentModel.ISupportInitialize)(this._table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _table;
        private System.Windows.Forms.Button _btnNuevo;
        private System.Windows.Forms.Button _btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.Button _btnEliminar;
    }
}

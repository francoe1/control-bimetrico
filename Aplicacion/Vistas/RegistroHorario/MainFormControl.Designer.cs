namespace Aplicacion.Vistas.RegistroHorario
{
    partial class MainFormControl
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
            this._btnNuevo = new System.Windows.Forms.Button();
            this._btnActualizar = new System.Windows.Forms.Button();
            this._table = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minutos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_btnFilters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._table)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnNuevo
            // 
            this._btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(58)))));
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
            this._btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(58)))));
            this._btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnActualizar.ForeColor = System.Drawing.Color.White;
            this._btnActualizar.Location = new System.Drawing.Point(84, 3);
            this._btnActualizar.Name = "_btnActualizar";
            this._btnActualizar.Size = new System.Drawing.Size(75, 23);
            this._btnActualizar.TabIndex = 1;
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
            this.Entrada,
            this.Salida,
            this.Minutos,
            this.Estado});
            this._table.Location = new System.Drawing.Point(3, 32);
            this._table.MultiSelect = false;
            this._table.Name = "_table";
            this._table.ReadOnly = true;
            this._table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._table.Size = new System.Drawing.Size(790, 512);
            this._table.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Entrada
            // 
            this.Entrada.HeaderText = "Entrada";
            this.Entrada.Name = "Entrada";
            this.Entrada.ReadOnly = true;
            // 
            // Salida
            // 
            this.Salida.HeaderText = "Salida";
            this.Salida.Name = "Salida";
            this.Salida.ReadOnly = true;
            // 
            // Minutos
            // 
            this.Minutos.HeaderText = "Minutos";
            this.Minutos.Name = "Minutos";
            this.Minutos.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // m_btnFilters
            // 
            this.m_btnFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(58)))));
            this.m_btnFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnFilters.ForeColor = System.Drawing.Color.White;
            this.m_btnFilters.Location = new System.Drawing.Point(718, 3);
            this.m_btnFilters.Name = "m_btnFilters";
            this.m_btnFilters.Size = new System.Drawing.Size(75, 23);
            this.m_btnFilters.TabIndex = 1;
            this.m_btnFilters.Text = "Filtros";
            this.m_btnFilters.UseVisualStyleBackColor = false;
            this.m_btnFilters.Click += new System.EventHandler(this.m_btnFilters_Click);
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnFilters);
            this.Controls.Add(this._btnActualizar);
            this.Controls.Add(this._btnNuevo);
            this.Controls.Add(this._table);
            this.Name = "Control";
            this.Size = new System.Drawing.Size(796, 547);
            ((System.ComponentModel.ISupportInitialize)(this._table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnNuevo;
        private System.Windows.Forms.Button _btnActualizar;
        private System.Windows.Forms.DataGridView _table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button m_btnFilters;
    }
}

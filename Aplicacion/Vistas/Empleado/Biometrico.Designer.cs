namespace Aplicacion.Vistas.Empleado
{
    partial class Biometrico
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._cbxDedo = new System.Windows.Forms.ComboBox();
            this._chbManoDerecha = new System.Windows.Forms.CheckBox();
            this._btnCapturar = new System.Windows.Forms.Button();
            this._picHuella = new System.Windows.Forms.PictureBox();
            this._progress = new System.Windows.Forms.ProgressBar();
            this._cblRegistrados = new System.Windows.Forms.CheckedListBox();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.m_btnManual = new System.Windows.Forms.Button();
            this.m_btn_delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 61);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::App.Properties.Resources.HuellaDigital_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(11, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro Biometrico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dedo";
            // 
            // _cbxDedo
            // 
            this._cbxDedo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxDedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cbxDedo.FormattingEnabled = true;
            this._cbxDedo.Location = new System.Drawing.Point(54, 66);
            this._cbxDedo.Name = "_cbxDedo";
            this._cbxDedo.Size = new System.Drawing.Size(218, 21);
            this._cbxDedo.TabIndex = 2;
            // 
            // _chbManoDerecha
            // 
            this._chbManoDerecha.AutoSize = true;
            this._chbManoDerecha.Location = new System.Drawing.Point(54, 93);
            this._chbManoDerecha.Name = "_chbManoDerecha";
            this._chbManoDerecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chbManoDerecha.Size = new System.Drawing.Size(97, 17);
            this._chbManoDerecha.TabIndex = 3;
            this._chbManoDerecha.Text = "Mano Derecha";
            this._chbManoDerecha.UseVisualStyleBackColor = true;
            // 
            // _btnCapturar
            // 
            this._btnCapturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnCapturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCapturar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCapturar.ForeColor = System.Drawing.Color.White;
            this._btnCapturar.Location = new System.Drawing.Point(97, 272);
            this._btnCapturar.Name = "_btnCapturar";
            this._btnCapturar.Size = new System.Drawing.Size(81, 25);
            this._btnCapturar.TabIndex = 4;
            this._btnCapturar.Text = "Capturar";
            this._btnCapturar.UseVisualStyleBackColor = false;
            // 
            // _picHuella
            // 
            this._picHuella.Location = new System.Drawing.Point(83, 116);
            this._picHuella.Name = "_picHuella";
            this._picHuella.Size = new System.Drawing.Size(125, 125);
            this._picHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picHuella.TabIndex = 5;
            this._picHuella.TabStop = false;
            // 
            // _progress
            // 
            this._progress.Location = new System.Drawing.Point(83, 247);
            this._progress.Name = "_progress";
            this._progress.Size = new System.Drawing.Size(125, 11);
            this._progress.TabIndex = 6;
            // 
            // _cblRegistrados
            // 
            this._cblRegistrados.FormattingEnabled = true;
            this._cblRegistrados.Location = new System.Drawing.Point(278, 67);
            this._cblRegistrados.Name = "_cblRegistrados";
            this._cblRegistrados.Size = new System.Drawing.Size(135, 199);
            this._cblRegistrados.Sorted = true;
            this._cblRegistrados.TabIndex = 7;
            this._cblRegistrados.TabStop = false;
            // 
            // _btnCancelar
            // 
            this._btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCancelar.ForeColor = System.Drawing.Color.White;
            this._btnCancelar.Location = new System.Drawing.Point(10, 272);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(81, 25);
            this._btnCancelar.TabIndex = 4;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = false;
            // 
            // m_btnManual
            // 
            this.m_btnManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.m_btnManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnManual.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnManual.ForeColor = System.Drawing.Color.White;
            this.m_btnManual.Location = new System.Drawing.Point(184, 272);
            this.m_btnManual.Name = "m_btnManual";
            this.m_btnManual.Size = new System.Drawing.Size(88, 25);
            this.m_btnManual.TabIndex = 4;
            this.m_btnManual.Text = "Manual";
            this.m_btnManual.UseVisualStyleBackColor = false;
            this.m_btnManual.Click += new System.EventHandler(this.m_btnManual_Click);
            // 
            // m_btn_delete
            // 
            this.m_btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.m_btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btn_delete.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btn_delete.ForeColor = System.Drawing.Color.White;
            this.m_btn_delete.Location = new System.Drawing.Point(325, 272);
            this.m_btn_delete.Name = "m_btn_delete";
            this.m_btn_delete.Size = new System.Drawing.Size(88, 25);
            this.m_btn_delete.TabIndex = 4;
            this.m_btn_delete.Text = "Eliminar";
            this.m_btn_delete.UseVisualStyleBackColor = false;
            // 
            // Biometrico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 303);
            this.Controls.Add(this._cblRegistrados);
            this.Controls.Add(this._progress);
            this.Controls.Add(this._picHuella);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this.m_btn_delete);
            this.Controls.Add(this.m_btnManual);
            this.Controls.Add(this._btnCapturar);
            this.Controls.Add(this._chbManoDerecha);
            this.Controls.Add(this._cbxDedo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Biometrico";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biometrico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picHuella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cbxDedo;
        private System.Windows.Forms.CheckBox _chbManoDerecha;
        private System.Windows.Forms.Button _btnCapturar;
        private System.Windows.Forms.PictureBox _picHuella;
        private System.Windows.Forms.ProgressBar _progress;
        private System.Windows.Forms.CheckedListBox _cblRegistrados;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.Button m_btnManual;
        private System.Windows.Forms.Button m_btn_delete;
    }
}
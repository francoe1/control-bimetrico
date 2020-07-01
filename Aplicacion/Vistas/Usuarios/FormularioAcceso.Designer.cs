namespace Aplicacion.Vistas.Usuarios
{
    partial class FormularioAcceso
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtClave = new System.Windows.Forms.TextBox();
            this._btnEntrar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 65);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acceso de Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // _txtUser
            // 
            this._txtUser.Location = new System.Drawing.Point(103, 82);
            this._txtUser.Name = "_txtUser";
            this._txtUser.Size = new System.Drawing.Size(178, 20);
            this._txtUser.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Clave";
            // 
            // _txtClave
            // 
            this._txtClave.Location = new System.Drawing.Point(103, 108);
            this._txtClave.Name = "_txtClave";
            this._txtClave.Size = new System.Drawing.Size(178, 20);
            this._txtClave.TabIndex = 2;
            this._txtClave.UseSystemPasswordChar = true;
            // 
            // _btnEntrar
            // 
            this._btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(58)))));
            this._btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEntrar.ForeColor = System.Drawing.Color.White;
            this._btnEntrar.Location = new System.Drawing.Point(161, 141);
            this._btnEntrar.Name = "_btnEntrar";
            this._btnEntrar.Size = new System.Drawing.Size(120, 24);
            this._btnEntrar.TabIndex = 3;
            this._btnEntrar.Text = "Entrar";
            this._btnEntrar.UseVisualStyleBackColor = false;
            // 
            // _btnCancelar
            // 
            this._btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(58)))));
            this._btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancelar.ForeColor = System.Drawing.Color.White;
            this._btnCancelar.Location = new System.Drawing.Point(35, 141);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(120, 24);
            this._btnCancelar.TabIndex = 4;
            this._btnCancelar.TabStop = false;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormularioAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 177);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnEntrar);
            this.Controls.Add(this._txtClave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioAcceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioAcceso";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtClave;
        private System.Windows.Forms.Button _btnEntrar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}
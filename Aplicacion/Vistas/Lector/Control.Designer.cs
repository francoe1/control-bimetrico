namespace Aplicacion.Vistas.Lector
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._lblState = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btnStop = new System.Windows.Forms.Button();
            this._btnStart = new System.Windows.Forms.Button();
            this._btnConsole = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estado";
            // 
            // _lblState
            // 
            this._lblState.AutoSize = true;
            this._lblState.BackColor = System.Drawing.SystemColors.Control;
            this._lblState.ForeColor = System.Drawing.Color.Red;
            this._lblState.Location = new System.Drawing.Point(59, 13);
            this._lblState.Name = "_lblState";
            this._lblState.Size = new System.Drawing.Size(40, 13);
            this._lblState.TabIndex = 0;
            this._lblState.Text = "Estado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btnConsole);
            this.groupBox1.Controls.Add(this._btnStart);
            this.groupBox1.Controls.Add(this._btnStop);
            this.groupBox1.Location = new System.Drawing.Point(13, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // _btnStop
            // 
            this._btnStop.Location = new System.Drawing.Point(7, 20);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(178, 23);
            this._btnStop.TabIndex = 0;
            this._btnStop.Text = "Detener";
            this._btnStop.UseVisualStyleBackColor = true;
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(7, 49);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(178, 23);
            this._btnStart.TabIndex = 0;
            this._btnStart.Text = "Iniciar";
            this._btnStart.UseVisualStyleBackColor = true;
            // 
            // _btnConsole
            // 
            this._btnConsole.Location = new System.Drawing.Point(7, 78);
            this._btnConsole.Name = "_btnConsole";
            this._btnConsole.Size = new System.Drawing.Size(178, 23);
            this._btnConsole.TabIndex = 0;
            this._btnConsole.Text = "Consola";
            this._btnConsole.UseVisualStyleBackColor = true;
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 154);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._lblState);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Control";
            this.Text = "Control Biometrico";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnConsole;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnStop;
    }
}
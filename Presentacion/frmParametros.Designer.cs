namespace Presentacion
{
    partial class frmParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametros));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBaseURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExplorar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnParametros = new System.Windows.Forms.Button();
            this.txtRutaBD = new System.Windows.Forms.TextBox();
            this.abrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBaseURL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExplorar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnParametros);
            this.groupBox1.Controls.Add(this.txtRutaBD);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 173);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PARÁMETROS";
            // 
            // txtBaseURL
            // 
            this.txtBaseURL.Location = new System.Drawing.Point(16, 45);
            this.txtBaseURL.Name = "txtBaseURL";
            this.txtBaseURL.Size = new System.Drawing.Size(260, 20);
            this.txtBaseURL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BASE URL:";
            // 
            // btnExplorar
            // 
            this.btnExplorar.Location = new System.Drawing.Point(249, 98);
            this.btnExplorar.Name = "btnExplorar";
            this.btnExplorar.Size = new System.Drawing.Size(27, 20);
            this.btnExplorar.TabIndex = 4;
            this.btnExplorar.Text = "...";
            this.btnExplorar.UseVisualStyleBackColor = true;
            this.btnExplorar.Click += new System.EventHandler(this.btnExplorar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "RUTA ACCESS";
            // 
            // btnParametros
            // 
            this.btnParametros.Location = new System.Drawing.Point(16, 133);
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.Size = new System.Drawing.Size(260, 25);
            this.btnParametros.TabIndex = 5;
            this.btnParametros.Text = "GUARDAR";
            this.btnParametros.UseVisualStyleBackColor = true;
            this.btnParametros.Click += new System.EventHandler(this.btnGuardarParams_Click);
            // 
            // txtRutaBD
            // 
            this.txtRutaBD.Location = new System.Drawing.Point(17, 98);
            this.txtRutaBD.Name = "txtRutaBD";
            this.txtRutaBD.ReadOnly = true;
            this.txtRutaBD.Size = new System.Drawing.Size(226, 20);
            this.txtRutaBD.TabIndex = 3;
            // 
            // abrirArchivo
            // 
            this.abrirArchivo.FileName = "openFileDialog1";
            this.abrirArchivo.Filter = "Acces Files (*.mdb)|*.mdb";
            // 
            // frmParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(316, 197);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmParametros";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIGURAR PARÁMETROS";
            this.Load += new System.EventHandler(this.frmParametros_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBaseURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExplorar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnParametros;
        private System.Windows.Forms.TextBox txtRutaBD;
        private System.Windows.Forms.OpenFileDialog abrirArchivo;
    }
}
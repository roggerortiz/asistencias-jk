namespace Presentacion
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.abrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuConfigParametros = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActualizarAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMostrarLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLogs = new System.Windows.Forms.Button();
            this.rtxtLogs = new System.Windows.Forms.RichTextBox();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // abrirArchivo
            // 
            this.abrirArchivo.FileName = "openFileDialog1";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfigParametros,
            this.menuActualizarAccess,
            this.menuMostrarLogs});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(225, 92);
            // 
            // menuConfigParametros
            // 
            this.menuConfigParametros.Name = "menuConfigParametros";
            this.menuConfigParametros.Size = new System.Drawing.Size(224, 22);
            this.menuConfigParametros.Text = "Configurar Parámetros";
            this.menuConfigParametros.Click += new System.EventHandler(this.menuConfigParametros_Click);
            // 
            // menuActualizarAccess
            // 
            this.menuActualizarAccess.Name = "menuActualizarAccess";
            this.menuActualizarAccess.Size = new System.Drawing.Size(224, 22);
            this.menuActualizarAccess.Text = "Sincronizar Access - Hosting";
            this.menuActualizarAccess.Click += new System.EventHandler(this.menuActualizarAccess_Click);
            // 
            // menuMostrarLogs
            // 
            this.menuMostrarLogs.Name = "menuMostrarLogs";
            this.menuMostrarLogs.Size = new System.Drawing.Size(224, 22);
            this.menuMostrarLogs.Text = "Mostrar Logs del Sistema";
            this.menuMostrarLogs.Click += new System.EventHandler(this.menuMostrarLogs_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnLogs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxtLogs);
            this.splitContainer1.Size = new System.Drawing.Size(695, 331);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnLogs
            // 
            this.btnLogs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogs.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.Location = new System.Drawing.Point(602, 0);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(93, 33);
            this.btnLogs.TabIndex = 0;
            this.btnLogs.Text = "ACTUALIZAR";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // rtxtLogs
            // 
            this.rtxtLogs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtxtLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLogs.Location = new System.Drawing.Point(0, 0);
            this.rtxtLogs.Name = "rtxtLogs";
            this.rtxtLogs.ReadOnly = true;
            this.rtxtLogs.Size = new System.Drawing.Size(695, 294);
            this.rtxtLogs.TabIndex = 4;
            this.rtxtLogs.Text = "";
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.contextMenu;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "notifyIcon1";
            this.notify.Visible = true;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 331);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JAN KOMENSKY - CONTROL DE DATOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicio_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.contextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog abrirArchivo;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuConfigParametros;
        private System.Windows.Forms.ToolStripMenuItem menuActualizarAccess;
        private System.Windows.Forms.ToolStripMenuItem menuMostrarLogs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.RichTextBox rtxtLogs;
        private System.Windows.Forms.NotifyIcon notify;
    }
}
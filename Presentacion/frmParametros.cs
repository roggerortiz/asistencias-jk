using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmParametros : Form
    {
        public String ruta_bd;
        public String base_url;

        public frmParametros(String ruta_bd, String base_url)
        {
            InitializeComponent();

            this.ruta_bd = ruta_bd;
            this.base_url = base_url;
        }

        private void btnExplorar_Click(object sender, EventArgs e)
        {
            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                txtRutaBD.Text = abrirArchivo.FileName;
            }
        }

        private void btnGuardarParams_Click(object sender, EventArgs e)
        {

            if (txtBaseURL.Text.Length >= 7)
            {
                String url = txtBaseURL.Text.Replace("\\", "/");
                String last = url.Substring(url.Length - 1, 1);

                this.base_url = url;

                if (last != "/")
                {
                    this.base_url = this.base_url + "/";
                    txtBaseURL.Text = this.base_url;
                }
            }

            this.ruta_bd = txtRutaBD.Text;

            MessageBox.Show("Configuración Satisfactoria", "Parámetros de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            txtRutaBD.Text = this.ruta_bd;
            txtBaseURL.Text = this.base_url;
        }
    }
}

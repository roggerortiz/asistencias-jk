using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Entidades;
using RestApi;
using Newtonsoft.Json;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        private String ruta_bd = "D:/APP ASISTENCIAS/BD/ASISTENCIAS.mdb";
        private String base_url = "https://www.iejankomensky.edu.pe/sistema/api/";
        // private String base_url = "http://localhost/colegio-v4/cgilogs/public/api/";
        // private String base_url = "http://colegio.test/api/";

        private String logs = String.Empty;

        Thread hebraNuevasPersonas;
        Thread hebraNuevasAsistencias;
        Thread hebraActualizarAccess;

        public frmPrincipal()
        {
            InitializeComponent(); 
        }

        #region Eventos

        private void Principal_Load(object sender, EventArgs e)
        {
            ejecutarSegundoPlano();

            hebraNuevasPersonas = new Thread(new ThreadStart(nuevasPersonas));
            hebraNuevasPersonas.Start();

            hebraNuevasAsistencias = new Thread(new ThreadStart(nuevasAsistencias));
            hebraNuevasAsistencias.Start();
        }

        private void menuConfigParametros_Click(object sender, EventArgs e)
        {
            configurarParametros();
        }

        private void menuActualizarAccess_Click(object sender, EventArgs e)
        {
            hebraActualizarAccess = new Thread(new ThreadStart(sincronizarAccessHosting));
            hebraActualizarAccess.Start();
        }

        private void menuMostrarLogs_Click(object sender, EventArgs e)
        {
            mostrarLogs();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            rtxtLogs.Text = this.logs;
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            ejecutarSegundoPlano();
        }

        #endregion

        #region Funciones

        private void ejecutarSegundoPlano()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            notify.Visible = true;
        }

        private void configurarParametros()
        {
            frmParametros parametros = new frmParametros(this.ruta_bd, this.base_url);

            if (parametros.ShowDialog() == DialogResult.OK)
            {
                this.ruta_bd = parametros.ruta_bd;
                this.base_url = parametros.base_url;
            }
        }

        private void mostrarLogs()
        {
            rtxtLogs.Text = this.logs;

            notify.Visible = false;

            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void nuevasPersonas()
        {
            while (true)
            {
                nuevaPersona();
            }
        }

        private void nuevasAsistencias()
        {
            while (true)
            {
                nuevaAsistencia();
            }
        }

        private void nuevaPersona()
        {
            try
            {
                PersonaDA personaDA = new PersonaDA(ruta_bd);

                RestClient requestClient = new RestClient(base_url);

                DataTable personas = personaDA.getUltima();

                if (personas.Rows.Count > 0)
                {
                    Persona ultimaPersona = new Persona(personas.Rows[0], personas);

                    Boolean buscar = true;

                    while(buscar)
                    {
                        String responseJson = requestClient.makeRequest("persona/nueva/" + ultimaPersona.Dni);
                        Persona nuevaPersona = JsonConvert.DeserializeObject<Persona>(responseJson);

                        if (nuevaPersona != null)
                        {
                            this.logs += "Nueva Persona Hosting: " + responseJson + "\n";

                            nuevaPersona.DeptID = "82";

                            DataTable personaDT = personaDA.getPorDniONombre(nuevaPersona);

                            if (personaDT.Rows.Count > 0)
                            {
                                nuevaPersona.Id = personaDT.Rows[0]["id"].ToString();

                                ultimaPersona = nuevaPersona;

                                if (personaDA.actualizar(nuevaPersona))
                                {
                                    this.logs += "Actualizar Persona Access: {'user_id':'" + nuevaPersona.Id + "','ssn':'" + nuevaPersona.Dni + "','name':'" + nuevaPersona.Nombre + "'}\n";
                                }
                            }
                            else
                            {
                                buscar = false;

                                if (personaDA.registrar(nuevaPersona))
                                {
                                    Int32 user_id = personaDA.maxUserId();

                                    this.logs += "Registrar Persona Access: {'user_id':'" + user_id + "','ssn':'" + nuevaPersona.Dni + "','name':'" + nuevaPersona.Nombre + "'}\n";
                                }
                            }
                        }
                        else
                        {
                            buscar = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.logs += "Excepcion Nueva Persona [ " + ex.Message + " ]\n";
            }
        }

        private void nuevaAsistencia()
        {
            try
            {
                AsistenciaDA asistenciaDA = new AsistenciaDA(ruta_bd);

                RestClient requestClient = new RestClient(base_url);

                DataTable asistencias = asistenciaDA.getPrimera();

                if (asistencias.Rows.Count > 0)
                {
                    Asistencia asistencia = new Asistencia(asistencias.Rows[0], asistencias);

                    if (asistencia.Dni != String.Empty)
                    {
                        this.logs += "Nueva Asistencia Access: {'user_id':'" + asistencia.UserID + "','dni':'" + asistencia.Dni + "','fecha':'" + asistencia.Fecha + "','hora':'" + asistencia.Hora + "','tipo':'" + asistencia.Tipo + "'}\n";

                        String responseJson = requestClient.makeRequest("asistencia/" + asistencia.Dni + "/" + asistencia.Fecha + "/" + asistencia.Hora + "/" + asistencia.Tipo);

                        if (responseJson != String.Empty)
                        {
                            this.logs += "Registro Asistencia Hosting: " + responseJson + "\n";

                            if (asistenciaDA.actualizar(asistencia))
                            {
                                this.logs += "Actualizacion Asistencia Access: {'user_id':'" + asistencia.UserID + "','dni':'" + asistencia.Dni + "','fecha':'" + asistencia.Fecha + "','hora':'" + asistencia.Hora + "','tipo':'" + asistencia.Tipo + "'}\n";
                            }
                        }
                    }
                    else
                    {
                        this.logs += "Nueva Asistencia Access: DNI de Usuario No Registrado\n";

                        asistenciaDA.actualizar(asistencia);
                    }

                }
            }
            catch (Exception ex)
            {
                this.logs += "Excepcion Nueva Asistencia [ " + ex.Message + " ]\n";
            }
        }

        private void sincronizarAccessHosting()
        {
            if (MessageBox.Show("Se Iniciará la Sincronización de Datos entre la Base de Datos Access y la del Hosting. Ud. será notificado cuando el proceso haya finalizado. ¿Desea Continuar?", "Sincronización Access - Hosting", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                hebraNuevasPersonas.Suspend();
                hebraNuevasAsistencias.Suspend();

                try
                {
                    PersonaDA personaDA = new PersonaDA(ruta_bd);

                    RestClient requestClient = new RestClient(base_url);

                    String responseJson = requestClient.makeRequest("personas");
                    List<Persona> personas = JsonConvert.DeserializeObject<List<Persona>>(responseJson);

                    foreach (Persona persona in personas)
                    {
                        persona.DeptID = "82";

                        DataTable personaDT = personaDA.getPorDniONombre(persona);

                        if (personaDT.Rows.Count > 0)
                        {
                            persona.Id = personaDT.Rows[0]["id"].ToString();

                            if (personaDA.actualizar(persona))
                            {
                                this.logs += "Actualizar Persona Access: {'user_id':'" + persona.Id + "','ssn':'" + persona.Dni + "','name':'" + persona.Nombre + "'}\n";
                            }
                        }
                        else
                        {
                            if (personaDA.registrar(persona))
                            {
                                Int32 user_id = personaDA.maxUserId();

                                this.logs += "Registrar Persona Access: {'user_id':'" + user_id + "','ssn':'" + persona.Dni + "','name':'" + persona.Nombre + "'}\n";
                            }
                        }
                    }

                    MessageBox.Show("Se Finalizó la Actualización del Archivo Access", "Actualización de Access", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    this.logs += "Excepcion Actualizar Personas Access [ " + ex.Message + " ]\n";
                }
                finally
                {
                    hebraNuevasPersonas.Resume();
                    hebraNuevasAsistencias.Resume();
                }
            }
        }

        #endregion
    }
}

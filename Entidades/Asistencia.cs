using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Asistencia
    {
        private String user_id;
        private String checktime;
        private String dni;
        private String nombre;
        private String fecha;
        private String hora;
        private String tipo;

        public Asistencia(DataRow row, DataTable table)
        {
            this.user_id = (table.Columns.Contains("user_id")) ? row["user_id"].ToString().Trim() : null;
            this.checktime = (table.Columns.Contains("checktime")) ? row["checktime"].ToString().Trim() : null;
            this.dni = (table.Columns.Contains("dni")) ? row["dni"].ToString().Trim() : null;
            this.nombre = (table.Columns.Contains("nombre")) ? row["nombre"].ToString().Trim() : null;
            this.fecha = (table.Columns.Contains("fecha")) ? row["fecha"].ToString().Trim() : null;
            this.hora = (table.Columns.Contains("hora")) ? row["hora"].ToString().Trim() : null;
            this.tipo = (table.Columns.Contains("tipo")) ? row["tipo"].ToString().Trim() : null;
        }

        public String UserID
        {
            get { return (user_id != null) ? user_id.Trim() : String.Empty; }
            set { user_id = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Checktime
        {
            get { return (checktime != null) ? checktime.Trim() : String.Empty; }
            set { checktime = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Dni
        {
            get { return (dni != null) ? dni.Trim() : String.Empty; }
            set { dni = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Nombre
        {
            get { return (nombre != null) ? nombre.Trim() : String.Empty; }
            set { nombre = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Fecha
        {
            get { return (fecha != null) ? fecha.Trim() : String.Empty; }
            set { fecha = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Hora
        {
            get { return (hora != null) ? hora.Trim() : String.Empty; }
            set { hora = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Tipo
        {
            get { return (tipo != null) ? tipo.ToLower().Trim() : String.Empty; }
            set { tipo = (value != null) ? value.Trim() : String.Empty; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        private String id;
        private String dni;
        private String sexo;
        private String nombre;
        private String nombres;
        private String apellidos;
        private String tipo;
        private String dept_id;

        public Persona() { }

        public Persona(DataRow row, DataTable table)
        {
            this.id = (table.Columns.Contains("id")) ? row["id"].ToString().Trim() : null;
            this.dni = (table.Columns.Contains("dni")) ? row["dni"].ToString().Trim() : null;
            this.sexo = (table.Columns.Contains("sexo")) ? row["sexo"].ToString().Trim() : null;
            this.nombre = (table.Columns.Contains("nombre")) ? row["nombre"].ToString().Trim() : null;
            this.nombres = (table.Columns.Contains("nombres")) ? row["nombres"].ToString().Trim() : null;
            this.apellidos = (table.Columns.Contains("apellidos")) ? row["apellidos"].ToString().Trim() : null;
            this.tipo = (table.Columns.Contains("tipo")) ? row["tipo"].ToString().Trim() : null;
        }

        public String Id
        {
            get { return (id != null) ? id.Trim() : String.Empty; }
            set { id = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Dni
        {
            get { return (dni != null) ? dni.Trim() : String.Empty; }
            set { dni = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Sexo
        {
            get { return (sexo != null) ? sexo.Trim() : String.Empty; }
            set { sexo = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Nombre
        {
            get { return (apellidos != null && nombres != null) ? (apellidos.ToUpper() + ", " + nombres).Trim() : (nombre != null) ? nombre.Trim() : String.Empty; }
            set { nombre = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Nombres
        {
            get { return (nombres != null) ? nombres.Trim() : String.Empty; }
            set { nombres = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Apellidos
        {
            get { return (apellidos != null) ? apellidos.Trim() : String.Empty; }
            set { apellidos = (value != null) ? value.Trim() : String.Empty; }
        }

        public String Tipo
        {
            get { return (tipo == null) ? String.Empty : (tipo == "AL") ? "ALUMNOS" : (tipo == "D") ? "DOCENTES" : (tipo == "A") ? "ADMINISTRATIVOS" : "SERVICIOS"; }
            set { tipo = (value != null) ? value.Trim() : String.Empty; }
        }

        public String DeptID
        {
            get { return (dept_id != null) ? dept_id.Trim() : String.Empty; }
            set { dept_id = (value != null) ? value.Trim() : String.Empty; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DepartamentoDA : Database
    {
        public DepartamentoDA(String ruta_bd) : base(ruta_bd) { }

        public String buscarPorNombre(String nombre)
        {
            String deptID = String.Empty;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "SELECT DEPTID FROM DEPARTMENTS WHERE DEPTNAME = '" + nombre + "'";

                this.Conexion.Open();

                Object result = cmd.ExecuteScalar();
                if (result != null) deptID = result.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Buscar Departamento por Nombre: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return deptID;
        }
    }
}

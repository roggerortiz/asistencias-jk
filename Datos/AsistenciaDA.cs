using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class AsistenciaDA : Database
    {
        public AsistenciaDA(String ruta_bd) : base(ruta_bd) { }

        public DataTable getPrimera()
        {
            DataTable table = new DataTable();

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "SELECT USERINFO.USERID as user_id, CHECKTIME as checktime, USERINFO.Name AS nombre, USERINFO.SSN AS dni, Format(CHECKTIME, \"yyyy-mm-dd\") AS fecha, Format(CHECKTIME, \"hh:mm:ss\") AS hora, CHECKTYPE AS tipo FROM CHECKINOUT INNER JOIN USERINFO ON USERINFO.USERID = CHECKINOUT.USERID WHERE CHECKINOUT.Registered = False";

                this.Conexion.Open();

                table.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Primera Asistencia: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return table;
        }

        public Boolean actualizar(Asistencia a)
        {
            Boolean result = false;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "UPDATE CHECKINOUT SET Registered = True WHERE USERID = " + a.UserID + " AND Format(CHECKTIME, \"yyyy-mm-dd\") = '" + a.Fecha + "' AND Format(CHECKTIME, \"hh:mm:ss\") = '" + a.Hora + "'";

                this.Conexion.Open();

                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Actualizar Asistencia: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return result;
        }
    }
}

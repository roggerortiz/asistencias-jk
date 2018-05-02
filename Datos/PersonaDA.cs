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
    public class PersonaDA : Database
    {
        public PersonaDA(String ruta_bd) : base(ruta_bd) { }

        public DataTable getPorDniONombre(Persona p)
        {
            DataTable table = new DataTable();

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "SELECT USERID as id, SSN as dni, Name as nombre FROM USERINFO WHERE SSN = '" + p.Dni + "' OR '" + p.Nombre + "' LIKE '%' & Name & '%'";

                this.Conexion.Open();

                table.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get Persona Por DNI or Nombre: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return table;
        }

        public DataTable getUltima()
        {
            DataTable table = new DataTable();

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "SELECT USERID as id, SSN as dni, Name as nombre FROM USERINFO WHERE USERID = " + maxUserIdWithSSN();

                this.Conexion.Open();

                table.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ultima Persona: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return table;
        }
        
        public DataTable getAll()
        {
            DataTable table = new DataTable();

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "SELECT USERID as id, SSN as dni, Name as nombre, Gender FROM USERINFO";

                this.Conexion.Open();

                table.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Todas las Personas: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return table;
        }

        public Boolean actualizar(Persona p)
        {
            Boolean result = false;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "UPDATE USERINFO SET SSN = '" + p.Dni + "', Name = '" + p.Nombre + "', DEFAULTDEPTID = " + p.DeptID + " WHERE USERID = " + p.Id;

                this.Conexion.Open();

                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Actualizar Persona: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return result;
        }

        public Boolean registrar(Persona p)
        {
            Boolean result = false;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "INSERT INTO USERINFO(Badgenumber, SSN, Name, DEFAULTDEPTID) VALUES(@badgenumber, @dni, @nombre, @dept_id); ";
                cmd.Parameters.AddWithValue("@badgenumber", badgeNumber());
                cmd.Parameters.AddWithValue("@dni", p.Dni);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@dept_id", p.DeptID);

                this.Conexion.Open();

                cmd.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Registrar Persona: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return result;
        }

        public Int32 maxUserId()
        {
            Int32 number = 0;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "SELECT Max(USERID) FROM USERINFO";

                this.Conexion.Open();

                Object result = cmd.ExecuteScalar();
                if (result != null) number = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Maximo USERID: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return number;
        }

        public Int32 maxUserIdWithSSN()
        {
            Int32 number = 0;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "SELECT Max(USERID) FROM USERINFO WHERE SSN <> ''";

                this.Conexion.Open();

                Object result = cmd.ExecuteScalar();
                if (result != null) number = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Maximo USERID: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return number;
        }

        private String badgeNumber()
        {
            Int32 number = 0;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = this.Conexion;
                cmd.CommandText = "SELECT Max(CLng(Badgenumber)) FROM USERINFO WHERE Badgenumber <> ''";

                this.Conexion.Open();

                Object result = cmd.ExecuteScalar();
                if (result != null) number = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Badge Number: '{0}'", ex.Message);
            }
            finally
            {
                this.Conexion.Close();
            }

            return (number + 1).ToString();
        }
    }
}

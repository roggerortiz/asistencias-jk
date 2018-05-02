using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public abstract class Database
    {
        private OleDbConnection conexion;

        public Database(String ruta_bd)
        {
            try
            {
                this.conexion = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta_bd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ConnectException: '{0}'", ex.Message);
            }
        }

        public OleDbConnection Conexion
        {
            get { return conexion; }
        }
    }
}

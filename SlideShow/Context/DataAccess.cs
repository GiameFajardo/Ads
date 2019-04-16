using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SlideShow.Context
{
    public class DataAccess
    {
        public Item GetItem(string reference)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.ConnectionValue("Admin")))
            {
                var item = connection.Query<Item>($"SELECT * FROM DatosProducto WHERE CODIBARR = '{reference}'").First();
                return item;
            }
        }
        public Item GetEmployee(string code)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.ConnectionValue("Admin")))
            {
                var item = connection.Query<Item>($"SELECT * FROM Empleado WHERE Codigo = '{code}'").First();
                return item;
            }
        }
    }
}

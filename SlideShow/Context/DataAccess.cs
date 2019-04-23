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
            Item itemFound;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.ConnectionValue("Admin")))
            {
                var item = connection.Query<Item>($"SELECT * FROM DatosProducto WHERE REFEARTI = '{reference}'");
                if (item.Count() > 0)
                {
                    itemFound = item.First();
                }
                else
                {
                    item = connection.Query<Item>($"SELECT * FROM DatosProducto WHERE CODIBARR = '{reference}'");
                    if (item.Count() > 0)
                    {
                        itemFound = item.First();
                    }
                    else
                    {
                        throw new Exception("Lectura invalida");
                    }
                }
                return itemFound;
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

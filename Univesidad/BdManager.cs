using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;

namespace Univesidad{
    public class BdManager{
    MySqlConnection connection;
        private string connectionString;

        public BdManager()
        {
            connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
             //connectionString = "server=localhost;port=3307;user=juan;password=Contrasena99;database=universidad";
            connection = new MySqlConnection(connectionString);
        }

        public List<string> ExecuteReader(string sqlQuery, string getValue = "nombre",string getValueId = "id")
        {
            List<string> values = new List<string>();
            try
            {
                connection.Open();
                var command = new MySqlCommand(sqlQuery, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var valueId = reader.GetInt32(getValueId);
                    var valueNombre = reader.GetString(getValue);
                    // Console.WriteLine(value.ToString());
                    values.Add(valueId.ToString());
                    values.Add(valueNombre);
                }

                if(values.Count == 0) Console.WriteLine("Vacío");
                connection.Close();
            } catch(Exception ex)
            {
                Console.WriteLine("Ocurrió un error"+ ex.Message);
            }
            return values;
        }

        public void ExecuteQuery(string sqlQuery)
        {
            try
            {
                Console.WriteLine(sqlQuery);
                connection.Open();
                var command = new MySqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
            } catch(Exception ex)
            {
                Console.WriteLine("Ocurrió un error"+ ex.Message);
            }
        }


}

}



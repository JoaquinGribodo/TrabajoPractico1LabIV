using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class DronesDB
    {
        private static DronesDB _instance;
        private string connectionString = "Server=;Database=Repartidores;Trusted_Connection=True;";
        
        private DronesDB()
        {

        }

        public static DronesDB Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DronesDB();
                }
                return _instance;
            }
        }
        public List<Drones> GetDronesList(IDroneFactory droneFactory)
        {
            List<Drones> dronesList = new List<Drones>();

            string query = "select id, modelo, responsable, capacidad_kilos from Drones";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string modelo = reader.GetString(1);
                        string responsable = reader.GetString(2);
                        int capacidad_kilos = reader.GetInt32(3);

                        Drones drone = droneFactory.CreateDrone(id, modelo, responsable, capacidad_kilos);

                        dronesList.Add(drone);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception)
                {
                    throw new Exception("Ha ocurrido un error en la base de datos.");
                }
            }


            return dronesList;
        }

        public Drones GetDronesList(int id, IDroneFactory droneFactory)
        {
            string query = "select id, modelo, responsable, capacidad_kilos from Drones where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    {
                        int droneId = reader.GetInt32(0);
                        string modelo = reader.GetString(1);
                        string responsable = reader.GetString(2);
                        int capacidad_kilos = reader.GetInt32(3);

                        Drones drone = droneFactory.CreateDrone(droneId, modelo, responsable, capacidad_kilos);

                        reader.Close();
                        connection.Close();
                        return drone;
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ha ocurrido un error en la base de datos.");
                }
            }
        }

        public void Add(string modelo, string responsable, int capacidad_kilos)
        {
            string query = "insert into Drones(modelo, responsable, capacidad_kilos) values" + "(@modelo, @responsable, @capacidad_kilos)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@modelo", modelo);
                command.Parameters.AddWithValue("@responsable", responsable);
                command.Parameters.AddWithValue("@capacidad_kilos", capacidad_kilos);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception)
                {
                    throw new Exception("Ha ocurrido un error en la base de datos.");
                }
            }
        }

        public void Update(int id, string modelo, string responsable, int capacidad_kilos)
        {
            string query = "update Drones set modelo = @modelo, responsable = @responsable, capacidad_kilos = @capacidad_kilos where id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@modelo", modelo);
                command.Parameters.AddWithValue("@responsable", responsable);
                command.Parameters.AddWithValue("@capacidad_kilos", capacidad_kilos);
                command.Parameters.AddWithValue("@id", id);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception)
                {
                    throw new Exception("Ha ocurrido un error en la base de datos.");
                }
            }
        }

        public void Delete(int id)
        {
            string query = "delete from Drones where id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception)
                {
                    throw new Exception("Ha ocurrido un error en la base de datos.");
                }
            }
        }
    }
   
}

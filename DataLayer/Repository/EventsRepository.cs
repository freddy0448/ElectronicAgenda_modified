namespace ElectronicAgenda_modified.DataLayer.Repository
{
    using Microsoft.Data.SqlClient;
    using DataLayer.Core;

    public class EventsRepository : principalDataLayer, IDataLayer
    {
        private string stringChange;
        private int idChange;

        public EventsRepository()
        {
            this.sqlConnection.ConnectionString = connectionString;
        }

        public void delete()
        {
            try
            {
                sqlConnection.Open();
                System.Console.WriteLine("El evento que desea eliminar, que numero de ID tiene?");
                int idDelete = int.Parse(Console.ReadLine()!);
                
                var query = new SqlCommand($"DELETE FROM Evento WHERE id ={idDelete}",sqlConnection);
                query.ExecuteNonQuery();
                System.Console.WriteLine("Evento borrado exitosamente!");

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error abriendo la bases de datos o ejecutando el comando. " +ex);
            }
            finally
            {
                closeConnection();
            }
        }
 
        public void edit(string row)
        {
                try
                {
                    sqlConnection.Open();
                    System.Console.WriteLine("Escriba el ID del evento al cual le hara cambios");
                    int idCambio = int.Parse(Console.ReadLine()!);
                    System.Console.WriteLine("Cual es el dato nuevo?");
    
                    stringChange = Console.ReadLine()!;
    
                    var query = new SqlCommand($"UPDATE Evento set '{row}' = '{stringChange}' WHERE id ={idChange}",sqlConnection);
                    query.ExecuteNonQuery();
                    System.Console.WriteLine("Valor actualizado!");

                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Error abriendo la bases de datos o ejecutando el comando. " +ex);
                    
                }
                finally
                {
                    closeConnection();
                }

        }

        public void insertRow(string name, string date, string hour, string address, string row)
        {
            try
            {
                sqlConnection.Open();
                var query = new SqlCommand ($"INSERT INTO {row} VALUES ('{name}', '{date}', '{hour}', '{address}'", sqlConnection);
                query.ExecuteNonQuery();

                System.Console.WriteLine("Se agrego el nuevo evento!");
            }
            catch (Exception ex)
            {
                
                System.Console.WriteLine("Error abriendo la bases de datos o ejecutando el comando. " +ex);

            }
            finally
            {
                closeConnection();
            }

        }

        public void insertRow(string name, string lastName, string phoneNumber, string address, string email, string row)
        {
            throw new NotImplementedException();
        }

        public void retrieveAllData()
        {
            var retrievedData = new List<List<String>>();
            
            try
            {
                sqlConnection.Open();
                var query = new SqlCommand("SELECT * FROM Evento",sqlConnection);
                var reader = query.ExecuteReader();

                while (reader.Read())
                {
                    retrievedData.Add(new List<string>{reader["id"].ToString()!, reader["Nombre"].ToString()!, reader["Fecha"].ToString()!,
                    reader["Hora"].ToString()!, reader["Lugar"].ToString()!});
                }

                closeConnection();

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error abriendo la bases de datos o ejecutando el comando. " +ex);
                closeConnection();

            }
            finally
            {
                closeConnection();
                System.Console.WriteLine("ID  |   NOMBRE   |    FECHA   |    HORA    |    LUGAR   ");
                System.Console.WriteLine("-------------------------------------------------------------------------");

                foreach (var item in retrievedData)
                {
                    System.Console.WriteLine(item[0] +"       "+item[1] +"       "+item[2] +"       "+item[3] +"       "+item[4]);
                    System.Console.WriteLine("-------------------------------------------------------------------------");
                }

            }

        }
        public void search(string row)
        {
            var retrievedRows = new List<List<string>>();
            try
            {
                sqlConnection.Open();
                
                string searchString = Console.ReadLine()!;
                var query = new SqlCommand($"SELECT * FROM Evento WHERE {row} LIKE '%{searchString}%'",sqlConnection);
                
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    retrievedRows.Add(new List<string>{reader["id"].ToString()!, reader["Nombre"].ToString()!, 
                    reader["Fecha"].ToString()!, reader["Hora"].ToString()!, reader["Lugar"].ToString()!});
                }
                
                closeConnection();
                
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error abriendo la base de datos o ejecutando el comando. " +ex);    
                closeConnection();

            }
            finally
            {
                closeConnection();

                System.Console.WriteLine("ID  |   NOMBRE   |    FECHA   |    HORA    |    LUGAR   ");
                System.Console.WriteLine("-------------------------------------------------------------------------");

                foreach (var item in retrievedRows)
                {
                    System.Console.WriteLine(item[0] +"       "+item[1] +"       "+item[2] +"       "+item[3] +"       "+item[4]);
                    System.Console.WriteLine("-------------------------------------------------------------------------");
                }

            }
            
           

        }

    }
}
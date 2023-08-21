namespace ElectronicAgenda_modified.DataLayer.Repository
{
    using Microsoft.Data.SqlClient;
    using DataLayer.Core;
    
    public class ContactsRepository : principalDataLayer, IDataLayer 
    {
        private string _stringChange;
        private int _idChange;
        private bool _parseSuccess;
        private sbyte menuOption;
        

        public void delete()
        {
            try
            {
                sqlConnection.Open();
                System.Console.WriteLine("El contacto que desea eliminar, que numero de ID tiene?");
                int idDelete = int.Parse(Console.ReadLine()!);
                
                var query = new SqlCommand($"DELETE FROM Contacto WHERE id ={idDelete}",sqlConnection);
                query.ExecuteNonQuery();
                System.Console.WriteLine("Contacto borrado exitosamente!");

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
                    System.Console.WriteLine("Escriba el ID de la persona a la cual le hara cambios");
                    int idCambio = int.Parse(Console.ReadLine()!);
                    System.Console.WriteLine("Cual es el dato nuevo?");
    
                    _stringChange = Console.ReadLine()!;
    
                    var query = new SqlCommand($"UPDATE Contacto set '{row}' = '{_stringChange}' WHERE id ={_idChange}",sqlConnection);
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

        public  void insertRow(string name, string lastName, string phoneNumber, string address, string email, string row)
        {
            try
            {
                sqlConnection.Open();
                var query = new SqlCommand ($"INSERT INTO {row} VALUES ('{name}', '{lastName}', '{phoneNumber}', '{address}', '{email}' )", sqlConnection);
                query.ExecuteNonQuery();

                System.Console.WriteLine("Se agrego el nuevo contacto!");


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
            throw new NotImplementedException();
        }

        public void retrieveAllData()
        {
            var retrievedData = new List<List<String>>();
            
            try
            {
                sqlConnection.Open();
                var query = new SqlCommand("SELECT * FROM Contacto",sqlConnection);
                var reader = query.ExecuteReader();

                while (reader.Read())
                {
                    retrievedData.Add(new List<string>{reader["id"].ToString()!, reader["Nombre"].ToString()!, reader["Apellido"].ToString()!,
                    reader["Telefono"].ToString()!, reader["Direccion"].ToString()!, reader["Email"].ToString()!});
                }


            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error abriendo la bases de datos o ejecutando el comando. " +ex);

            }
            finally
            {
                closeConnection();

                System.Console.WriteLine("ID  |   NOMBRE   |    APELLIDO   |    TELEFONO    |    DIRECCION   |    EMAIL  ");
                System.Console.WriteLine("---------------------------------------------------------------------------------------------------------");

                foreach (var item in retrievedData)
                {
                    System.Console.WriteLine(item[0] +"       "+item[1] +"       "+item[2] +"       "+item[3] +"       "+item[4] +"       "+item[5]);
                    System.Console.WriteLine("-----------------------------------------------------------------------------------------------------");
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
                var query = new SqlCommand($"SELECT * FROM Contacto WHERE {row} LIKE '%{searchString}%'",sqlConnection);
                
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    retrievedRows.Add(new List<string>{reader["id"].ToString()!, reader["Nombre"].ToString()!, 
                    reader["Apellido"].ToString()!, reader["Telefono"].ToString()!, reader["Direccion"].ToString()!, 
                    reader["Email"].ToString()!});
                }
                                
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error abriendo la base de datos o ejecutando el comando. " +ex);    

            }
            finally
            {
                closeConnection();
                System.Console.WriteLine("ID  |   NOMBRE   |    APELLIDO   |    TELEFONO    |    DIRECCION   |    EMAIL  ");
                System.Console.WriteLine("---------------------------------------------------------------------------------------------------------");

                foreach (var item in retrievedRows)
                {
                    System.Console.WriteLine(item[0] +"       "+item[1] +"       "+item[2] +"       "+item[3] +"       "+item[4] +"       "+item[5]);
                    System.Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                }

            }
           

        }
        public ContactsRepository()
        {
            sqlConnection.ConnectionString = connectionString;
        }
    }
}
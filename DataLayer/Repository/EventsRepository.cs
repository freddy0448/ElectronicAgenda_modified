namespace ElectronicAgenda_modified.DataLayer.Repository
{
    using Microsoft.Data.SqlClient;
    using DataLayer.Core;

    public class EventsRepository : principalDataLayer, IDataLayer
    {
        private string stringChange;
        private int idChange;
        private bool _parseSuccess;

        private List<string> _insertValues = new List<string>();

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

        public EventsRepository(sbyte menuOption)
        {
            this.sqlConnection.ConnectionString = connectionString;
            
                do{
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("-------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
     _                         _                             _            
    / \   _ __ ___  __ _    __| | ___    _____   _____ _ __ | |_ ___  ___ 
   / _ \ | '__/ _ \/ _` |  / _` |/ _ \  / _ \ \ / / _ \ '_ \| __/ _ \/ __|
  / ___ \| | |  __/ (_| | | (_| |  __/ |  __/\ V /  __/ | | | || (_) \__ \
 /_/   \_\_|  \___|\__,_|  \__,_|\___|  \___| \_/ \___|_| |_|\__\___/|___/
                                                                          
            ");
                    System.Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.WriteLine("Que desea hacer?");
                    System.Console.WriteLine("[0] Salir");
                    System.Console.WriteLine("[1] Agregar evento ");
                    System.Console.WriteLine("[2] Editar evento ");
                    System.Console.WriteLine("[3] Borrar evento ");
                    System.Console.WriteLine("[4] Buscar evento ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(".........................");
                    System.Console.Write("Ingrese su opción--> ");

                    _parseSuccess = sbyte.TryParse(Console.ReadLine()!, out menuOption);

                    if (_parseSuccess && menuOption != 0)
                    {
                        switch (menuOption)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                System.Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            break;

                            case 1:
                                string [] valueRequired = {"Nombre", "Fecha", "Hora", "Lugar"};

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                System.Console.WriteLine("Escriba los datos que se le pide");
                                for (int i = 0; i == 4; i++)
                                {
                                    System.Console.WriteLine(valueRequired[i]);
                                    _insertValues.Add(Console.ReadLine()!);
                                }
                                insertRow(_insertValues[0], _insertValues[1], _insertValues[2], _insertValues[3], "Event" );
                                _insertValues.Clear();

                            break;

                            case 2:
                                Console.Clear();
                                System.Console.WriteLine(@"A continuacion, le mostraremos los valores registrados, 
                                para que pueda visualizar el ID del contacto a editar");

                                Thread.Sleep(5000);
                                Console.Clear();
                                retrieveAllData();

                                System.Console.WriteLine("Que campo del evento quiere editar?");
                                System.Console.WriteLine("Nombre [1], Fecha [2], Hora [3], Lugar [4] ");

                                sbyte sbyteTemp;
                                string row;
                                _parseSuccess = sbyte.TryParse(Console.ReadLine(), out sbyteTemp);

                                if (_parseSuccess)
                                {
                                    switch (sbyteTemp)
                                    {
                                        case 1:
                                            row = "Nombre";
                                        break;
                                        case 2:
                                            row = "Fecha";
                                        break;
                                        case 3:
                                            row = "Hora";
                                        break;
                                        case 4:
                                            row = "Lugar";
                                        break;

                                        default:
                                            System.Console.WriteLine(@"El valor que se inserto no es parte de la lista.
                                            El valor a cambiar sera el nombre");
                                            row = "Nombre";
                                        break;
                                    }

                                    edit(row);

                                }
                                else
                                {
                                    System.Console.WriteLine("Error. El valor ingresado no fue un numero.");
                                }

                            break;

                            case 3:
                                Console.Clear();
                                System.Console.WriteLine(@"A continuacion, le mostraremos los valores registrados, 
                                para que pueda visualizar el ID del contacto a editar");

                                Thread.Sleep(5000);
                                Console.Clear();
                                retrieveAllData();

                                System.Console.WriteLine("");
                                delete();
                            break;
                        }
                    }
                    else if (_parseSuccess == false && menuOption != 0)
                    {
                        System.Console.WriteLine("El dato ingresado no es un numero, vuelva a ingresar una opcion! ");
                        Console.ReadKey();
                    }



                    }while(menuOption != 0);
        }
    }
}
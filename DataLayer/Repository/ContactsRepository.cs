namespace ElectronicAgenda_modified.DataLayer.Repository
{
    using Microsoft.Data.SqlClient;
    using DataLayer.Core;
    
    public class ContactsRepository : principalDataLayer, IDataLayer 
    {
        private string _stringChange;
        private int _idChange;
        private List<string> _insertValues = new List<string>();
        private bool _parseSuccess;

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
        public ContactsRepository(sbyte menuOption)
        {
                this.sqlConnection.ConnectionString = connectionString;

                do{
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("-----------------------------------------------------------------------------------");
                    System.Console.WriteLine(@"
                _                         _                        _             _            
                / \   _ __ ___  __ _    __| | ___    ___ ___  _ __ | |_ __ _  ___| |_ ___  ___ 
            / _ \ | '__/ _ \/ _` |  / _` |/ _ \  / __/ _ \| '_ \| __/ _` |/ __| __/ _ \/ __|
            / ___ \| | |  __/ (_| | | (_| |  __/ | (_| (_) | | | | || (_| | (__| || (_) \__ \
            /_/   \_\_|  \___|\__,_|  \__,_|\___|  \___\___/|_| |_|\__\__,_|\___|\__\___/|___/
                                                                                            
            ");
                    System.Console.WriteLine("-----------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    System.Console.WriteLine("¿Qué desea hacer?");
                    System.Console.WriteLine("[1] Agregar contacto ");
                    System.Console.WriteLine("[2] Editar contacto ");
                    System.Console.WriteLine("[3] Borrar contacto ");
                    System.Console.WriteLine("[4] Buscar contacto ");
                    System.Console.WriteLine("[0] Salir");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine(".........................");

                    System.Console.Write("Ingrese su opción--> ");
                    _parseSuccess = sbyte.TryParse(Console.ReadLine()!, out menuOption);

                    if (_parseSuccess && menuOption != 0)
                    {
                        switch (menuOption)
                        {   
                            
                            case 1:
                                string [] valueRequired = {"Nombre", "Apellido", "Telefono", "Direccion", "Email"};

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                System.Console.WriteLine("Escriba los datos que se le pide");
                                for (int i = 0; i == 4; i++)
                                {
                                    System.Console.WriteLine(valueRequired[i]);
                                    _insertValues.Add(Console.ReadLine()!);
                                }
                                insertRow(_insertValues[0], _insertValues[1], _insertValues[2], _insertValues[3], _insertValues[4] );
                                _insertValues.Clear();
                            break;

                            case 2:
                                
                                Console.Clear();
                                System.Console.WriteLine(@"A continuacion, le mostraremos los valores registrados, 
                                para que pueda visualizar el ID del contacto a editar");

                                Thread.Sleep(5000);
                                Console.Clear();
                                retrieveAllData();

                                System.Console.WriteLine("Que campo del contacto quiere editar?");
                                System.Console.WriteLine("Nombre [1], Apellido [2], Telefono [3], Direccion [4], Email [5] ");

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
                                            row = "Apellido";
                                        break;
                                        case 3:
                                            row = "Telefono";
                                        break;
                                        case 4:
                                            row = "Direccion";
                                        break;
                                        case 5:
                                            row = "Email";
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
using ElectronicAgenda_modified.DataLayer.Repository;

sbyte menuOption = 0;

ContactsRepository contactsRepository = new ContactsRepository();
EventsRepository eventsRepository = new EventsRepository();
bool _parseSuccess;
string [] _insertValues = new string[5];
string stringValue;


    do
    {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine(@"
 .-') _                                                                              
(  OO) )                                                                             
/     '._ ,--. ,--.                                                                  
|'--...__)|  | |  |                                                                  
'--.  .--'|  | | .-')                                                                
   |  |   |  |_|( OO )                                                               
   |  |   |  | | `-' /                                                               
   |  |  ('  '-'(_.-'                                                                
   `--'    `-----'                                                                   
   ('-.                   ('-.       .-') _  _ .-') _     ('-.                       
  ( OO ).-.             _(  OO)     ( OO ) )( (  OO) )   ( OO ).-.                   
  / . --. /  ,----.    (,------.,--./ ,--,'  \     .'_   / . --. /                   
  | \-.  \  '  .-./-')  |  .---'|   \ |  |\  ,`'--..._)  | \-.  \                    
.-'-'  |  | |  |_( O- ) |  |    |    \|  | ) |  |  \  '.-'-'  |  |                   
 \| |_.'  | |  | .--, \(|  '--. |  .     |/  |  |   ' | \| |_.'  |                   
  |  .-.  |(|  | '. (_/ |  .--' |  |\    |   |  |   / :  |  .-.  |                   
  |  | |  | |  '--'  |  |  `---.|  | \   |   |  '--'  /  |  | |  |                   
  `--' `--'  `------'   `------'`--'  `--'   `-------'   `--' `--'                   
            ('-.          (`-.                _  .-')           .-') _      ('-.     
           ( OO ).-.    _(OO  )_             ( \( -O )         (  OO) )    ( OO ).-. 
   ,------./ . --. /,--(_/   ,. \ .-'),-----. ,------.  ,-.-') /     '._   / . --. / 
('-| _.---'| \-.  \ \   \   /(__/( OO'  .-.  '|   /`. ' |  |OO)|'--...__)  | \-.  \  
(OO|(_\  .-'-'  |  | \   \ /   / /   |  | |  ||  /  | | |  |  \'--.  .--'.-'-'  |  | 
/  |  '--.\| |_.'  |  \   '   /, \_) |  |\|  ||  |_.' | |  |(_/   |  |    \| |_.'  | 
\_)|  .--' |  .-.  |   \     /__)  \ |  | |  ||  .  '.',|  |_.'   |  |     |  .-.  | 
  \|  |_)  |  | |  |    \   /       `'  '-'  '|  |\  \(_|  |      |  |     |  | |  | 
   `--'    `--' `--'     `-'          `-----' `--' '--' `--'      `--'     `--' `--' 
");
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("[1] Contactos");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("[2] Eventos");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("[3] Utilitarios");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("[0] Salir");
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            System.Console.WriteLine("............................");
            System.Console.Write("Ingrese su opción--> ");
            
            menuOption = sbyte.Parse(Console.ReadLine()!);

                switch (menuOption)
    {
        case 1:


            
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

                if (_parseSuccess)
                {
                    switch (menuOption)
                    {   
                        
                        case 1:
                            string [] valueRequired = {"Nombre", "Apellido", "Telefono", "Direccion", "Email"};

                            
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            System.Console.WriteLine("Escriba los datos que se le pide");
                            for (int i = 0; i == 4; i++)
                            {
                                System.Console.WriteLine(valueRequired[i]);
                                stringValue = Console.ReadLine();
                                _insertValues[i] = stringValue;
                            }
                            contactsRepository.insertRow(_insertValues[0], _insertValues[1], _insertValues[2]
                            , _insertValues[3], _insertValues[4], "Contacto" );
                       
                        break;

                        case 2:
                            
                            Console.Clear();
                            System.Console.WriteLine(@"A continuacion, le mostraremos los valores registrados, 
                            para que pueda visualizar el ID del contacto a editar");

                            Thread.Sleep(5000);
                            Console.Clear();
                            contactsRepository.retrieveAllData();

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

                                contactsRepository.edit(row);

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
                            contactsRepository.retrieveAllData();

                            System.Console.WriteLine("");
                            contactsRepository.delete();
                        break;
                    }

                }
                else if (_parseSuccess == false && menuOption != 0)
                {
                    System.Console.WriteLine("El dato ingresado no es un numero, vuelva a ingresar una opcion! ");
                    Console.ReadKey();
                }

    
            }while(menuOption != 0);

        break;
                        
        case 2:

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
                                for (int i = 0; i == 31; i++)
                                {
                                    System.Console.WriteLine(valueRequired[i]);
                                    _insertValues[i] = Console.ReadLine()!;
                                }
                                eventsRepository.insertRow(_insertValues[0], _insertValues[1], _insertValues[2], _insertValues[3], "Event" );
                                

                            break;

                            case 2:
                                Console.Clear();
                                System.Console.WriteLine(@"A continuacion, le mostraremos los valores registrados, 
                                para que pueda visualizar el ID del contacto a editar");

                                Thread.Sleep(5000);
                                Console.Clear();
                                eventsRepository.retrieveAllData();

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

                                    eventsRepository.edit(row);

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
                                eventsRepository.retrieveAllData();

                                System.Console.WriteLine("");
                                eventsRepository.delete();
                            break;
                        }
                    }
                    else if (_parseSuccess == false && menuOption != 0)
                    {
                        System.Console.WriteLine("El dato ingresado no es un numero, vuelva a ingresar una opcion! ");
                        Console.ReadKey();
                    }



                    }while(menuOption != 0);

        break;
    }

    } while (menuOption != 0);


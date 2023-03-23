using ElectronicAgenda_modified.DataLayer.Repository;

sbyte menuOption;

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

    } while (menuOption != 0);

    switch (menuOption)
    {
        case 1:
            ContactsRepository contactsRepository = new ContactsRepository(menuOption);
        break;
        
    }
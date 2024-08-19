using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemon
{
    internal class Menu
    {
            
        private static void header() 
        {
        Console.WriteLine(@",-.----.       ,----..          ,--.                    ____      ,----..            ,--.
\    /  \     /   /   \     ,--/  /|    ,---,.        ,'  , `.   /   /   \         ,--.'|
|   :    \   /   .     : ,---,': / '  ,'  .' |     ,-+-,.' _ |  /   .     :    ,--,:  : |
|   |  .\ : .   /   ;.  \:   : '/ / ,---.'   |  ,-+-. ;   , || .   /   ;.  \,`--.'`|  ' :
.   :  |: |.   ;   /  ` ;|   '   ,  |   |   .' ,--.'|'   |  ;|.   ;   /  ` ;|   :  :  | |
|   |   \ :;   |  ; \ ; |'   |  /   :   :  |-,|   |  ,', |  ':;   |  ; \ ; |:   |   \ | :
|   : .   /|   :  | ; | '|   ;  ;   :   |  ;/||   | /  | |  |||   :  | ; | '|   : '  '; |
;   | |`-' .   |  ' ' ' ::   '   \  |   :   .''   | :  | :  |,.   |  ' ' ' :'   ' ;.    ;
|   | ;    '   ;  \; /  ||   |    ' |   |  |-,;   . |  ; |--' '   ;  \; /  ||   | | \   |
:   ' |     \   \  ',  / '   : |.  \'   :  ;/||   : |  | ,     \   \  ',  / '   : |  ; .'
:   : :      ;   :    /  |   | '_\.'|   |    \|   : '  |/       ;   :    /  |   | '`--'  
|   | :       \   \ .'   '   : |    |   :   .';   | |`-'         \   \ .'   '   : |      
`---'.|        `---`     ;   |,'    |   | ,'  |   ;/              `---`     ;   |.'      
  `---`                  '---'      `----'    '---'                         '---'        ");
        }

        public static void delimiter(string type)
        {

            switch (type)
            {
                case "MENU":
                    Console.WriteLine($"------------------------------------------  MENU  ------------------------------------------");
                    break;

                case "CYP":
                    Console.WriteLine($"------------------------------------ CHOOSE YOUR POKEMON ------------------------------------");
                    break;

                case "EMPTY":
                    Console.WriteLine($"---------------------------------------------------------------------------------------------");
                    break;
            }
        }

        public static void welcome(out string name, out string choice)
        {
            string DelimiterType = "MENU";

            Menu.header();
            Console.WriteLine($"\nWhat is your name? ");
            name = Console.ReadLine();

            Console.WriteLine($"\nHello, {name}, welcome to the latest Pokemon game" +
            $" out on the Nintendo Switch XL Console.");
            Console.WriteLine();

            Menu.delimiter(DelimiterType);

            Console.WriteLine($"What do you want to do, {name}? \n1 - Choose Pokemon\n2 - See your current Pokemons\n3 - Exit");
            choice = Console.ReadLine();

        }

        public static void ChooseYourPokemon(string name)
        {
            string delimiter = "CYP";
            Menu.delimiter(delimiter);
            Console.WriteLine($"{name}, type the number of the pokemon specie that you want to check");
        }

        public static void ChooseValidOption (out string choice)
        {
            Console.WriteLine("Choose a valid option");
            choice = Console.ReadLine();
        }

        public static void bye()
        {
            Console.WriteLine("See ya!");

        }

    }


}


    




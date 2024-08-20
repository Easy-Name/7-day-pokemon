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



        public static async Task ChoosePokemon(string name)
        {
            //string[] PokemonList = { "1 - Alakazam", "2 - Machamp", "3 - Onix", "4 - Gyarados", "5 - Lapras", "6 - Snorlax" };

            Dictionary<string, string> pokemonlist = new Dictionary<string, string>();
            pokemonlist.Add("65", "Alakazam");
            pokemonlist.Add("68", "Machamp");
            pokemonlist.Add("95", "Onix");
            pokemonlist.Add("130", "Gyarados");
            pokemonlist.Add("131", "Lapras");
            pokemonlist.Add("143", "Snorlax");

            /*string delimiter = "CYP";
            Menu.delimiter(delimiter);*/


            Menu.ChooseYourPokemon(name);
            //Console.WriteLine($"{name}, type the number of the pokemon specie that you want to check");

            string decision = null;

            while (decision != "1")
            {
                if (!String.IsNullOrEmpty(decision))
                {
                    Console.WriteLine($"Type the number of the pokemon specie from the list below to check its skills");
                }
                foreach (KeyValuePair<string, string> kvpokemon in pokemonlist)
                {
                    Console.WriteLine($"{kvpokemon.Key} - {kvpokemon.Value}");
                }

                string choice = Console.ReadLine();

                if (pokemonlist.ContainsKey(choice))
                {
                    await Program.CheckPokemon(choice);

                    Console.WriteLine($"Type 1 if you want to select this pokemon or 0 if you want to go back to your options");


                    decision = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"{choice} is not available in the options you can choose from.");
                    decision = "0";
                }

            }

        }

        public static void ChooseValidOption(out string choice)
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


    




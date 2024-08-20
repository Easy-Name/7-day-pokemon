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



        public static void ListPokemon(string name, Dictionary<string, string> PokemonList, out string decision)
        {
            Menu.ChooseYourPokemon(name);
            //Console.WriteLine($"{name}, type the number of the pokemon specie that you want to check");

            decision = null;
            //string delimiter = "EMPTY";

            if (!String.IsNullOrEmpty(decision))
            {
                Console.WriteLine($"Type the number of the pokemon specie from the list below to check its skills");
            }
            foreach (KeyValuePair<string, string> kvpokemon in PokemonList)
            {
                Console.WriteLine($"{kvpokemon.Key} - {kvpokemon.Value}");
            }
        }





        public static async Task ChoosePokemon(string name)
        {

            Dictionary<string, string> pokemonlist = new Dictionary<string, string>();
            pokemonlist.Add("65", "Alakazam");
            pokemonlist.Add("68", "Machamp");
            pokemonlist.Add("95", "Onix");
            pokemonlist.Add("130", "Gyarados");
            pokemonlist.Add("131", "Lapras");
            pokemonlist.Add("143", "Snorlax");

            string delimiter = "EMPTY";
            bool adopted;

            //Menu.ChooseYourPokemon(name);
            //Console.WriteLine($"{name}, type the number of the pokemon specie that you want to check");

            string decision = null;
            //string delimiter = "EMPTY";

            while (decision != "1")
            {
                /*if (!String.IsNullOrEmpty(decision))
                {
                    Console.WriteLine($"Type the number of the pokemon specie from the list below to check its skills");
                }
                foreach (KeyValuePair<string, string> kvpokemon in pokemonlist)
                {
                    Console.WriteLine($"{kvpokemon.Key} - {kvpokemon.Value}");
                }*/

                /*Menu.ListPokemon(name, pokemonlist, out decision);

                string choice = Console.ReadLine();*/

                bool LoopExit = false;
                do
                {
                    Menu.ListPokemon(name, pokemonlist, out decision);
                    string choice = Console.ReadLine();


                    if (pokemonlist.ContainsKey(choice))
                    {

                        Menu.delimiter(delimiter);
                        Console.WriteLine($"{name}, what do you want to do with {pokemonlist[choice]}");
                        Console.WriteLine($"1 - Check Info\n2 - Adopt\n3 - Return to species menu");
                        string ChoiceTaken = Console.ReadLine();

                        switch (ChoiceTaken)
                        {
                            case "1":

                                string delimitation = "EMPTY";
                                Menu.delimiter(delimitation);
                                await Program.CheckPokemon(choice);

                                Menu.delimiter(delimitation);
                                Console.WriteLine($"Adopt {pokemonlist[choice]}?\n1 - Adopt\n2 - Return to species menu");
                                //string o = Console.ReadLine();
                                if(Console.ReadLine() == "1")
                                {
                                    adopted = true;
                                    LoopExit = true;
                                    decision = "1";
                                }
                                /*else
                                {

                                }*/
                                
                                break;
                            case "2":
                                LoopExit = true;
                                decision = "1";
                                //i have to develop the HELD POKEMON PART
                                adopted = true;
                                break;
                            case "3":
                                decision = null;
                                Menu.ListPokemon(name, pokemonlist, out decision);
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine($"{choice} is not available in the options you can choose from.");
                        decision = "0";
                    }

                } while (LoopExit != true);


                //Console.WriteLine($"Type 1 if you want to select this pokemon or 0 if you want to go back to your options");

                //decision = Console.ReadLine();        

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


    




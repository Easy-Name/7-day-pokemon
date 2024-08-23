using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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


            Menu.WelcomeCompliment(name);
            choice = Console.ReadLine();

        }

        public static void WelcomeCompliment(string name)
        {
            Console.WriteLine($"What do you want to do, {name}? \n1 - Choose Pokemon\n2 - See your current Pokemons\n3 - Interact with your current Pokemon\n4 - Exit");
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
                System.Threading.Thread.Sleep(200);
                Console.WriteLine($"{kvpokemon.Key} - {kvpokemon.Value}");
            }
        }

        public static void AllTimeAdoptedPokemon(List<string> ListOfPokemon, string name, out bool NoPokeAdopted)
        {

            //string delimiter = "EMPTY";

            if (ListOfPokemon.Count == 0) 
            { 
                Console.WriteLine($"{name}, you haven't adopted any Pokemon yet! Adopt one or more Pokemon so you can interact with them. Returning to main menu");
            }
            else
            {
                Console.WriteLine($"{name} the pokemons you have adopted are:");

                foreach (string pokemon in ListOfPokemon)
                {
                    System.Threading.Thread.Sleep(200);
                    Console.WriteLine($"{pokemon}");
                }

            }

            if (ListOfPokemon.Count == 0) { NoPokeAdopted = true; } else { NoPokeAdopted= false; }

        }

        public static void AdoptedSuccess(string PokemonName, out bool LoopExit,out string StopChoosing)
        {

            string pokeball = ".......@@@@@@@@@@.......\r\n....@@@@@@@@@@@@@@@@....\r\n...@@@@@@@@@@@@@@@@@@@..\r\n.@@@@@@@@@@@@@@@@@@@@@@.\r\n.@@@@@@@@@@@@@@@@@@@@@@.\r\n@@@@@@@@@@....@@@@@@@@@@\r\n@@@......@....@.......@@\r\n.@@.......@@@@.......@@.\r\n.@@@................@@@.\r\n...@@..............@@@..\r\n....@@@@@......@@@@@....\r\n.......@@@@@@@@@@.......";
            LoopExit = false;
            StopChoosing = null;

            string delimitation = "EMPTY";
            //AdoptedPokemon.Add(pokemonlist[choice]);
            Menu.delimiter(delimitation);
            Console.WriteLine($"{PokemonName} adopted!\n" + pokeball + "\nWhat next?\n1 - Checkout more Pokemons" +
                $"\n2 - Return to main menu");
            
            string whatnext = null;
            bool firstloop = true;

            do
            {

                if (!firstloop) { Console.WriteLine($"{whatnext} is not a valid choice! Choose a valid option"); } 

                whatnext = Console.ReadLine();

                if (whatnext == "2")
                {
                    LoopExit = true;
                    StopChoosing = "1";
                }

                firstloop = false;
            } while (whatnext!="1" && whatnext!="2");

        }


        public static async Task<List<string>> ChoosePokemon(string name, int CurrentPokeQuantity)
        {

            Dictionary<string, string> pokemonlist = new Dictionary<string, string>();
            pokemonlist.Add("65", "Alakazam");
            pokemonlist.Add("68", "Machamp");
            pokemonlist.Add("95", "Onix");
            pokemonlist.Add("130", "Gyarados");
            pokemonlist.Add("131", "Lapras");
            pokemonlist.Add("143", "Snorlax");

            string delimiter = "EMPTY";
            
            List<string> AdoptedPokemon = new List<string>();

            //Menu.ChooseYourPokemon(name);
            //Console.WriteLine($"{name}, type the number of the pokemon specie that you want to check");

            string StopChoosing = null;
            //string delimiter = "EMPTY";

            while (StopChoosing != "1")
            {

                bool LoopExit = false;
                do
                {
                    Menu.ListPokemon(name, pokemonlist, out StopChoosing);
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
                                    AdoptedPokemon.Add($"{CurrentPokeQuantity + AdoptedPokemon.Count+1} - {pokemonlist[choice]}"); //put the number of the pokemon in the function, not over here

                                    Menu.AdoptedSuccess(pokemonlist[choice], out LoopExit, out StopChoosing);
                                   
                                }
                                break;
                            case "2":
                              
                                AdoptedPokemon.Add($"{CurrentPokeQuantity + AdoptedPokemon.Count+1} - {pokemonlist[choice]}"); //put the number of the pokemon in the function, not over here
                                Menu.AdoptedSuccess(pokemonlist[choice], out LoopExit, out StopChoosing);
                                break;
                            case "3":
                                StopChoosing = null;
                                Menu.ListPokemon(name, pokemonlist, out StopChoosing);
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine($"{choice} is not available in the options you can choose from.");
                        StopChoosing = "0";
                    }

                } while (LoopExit != true);
            }
            return AdoptedPokemon;
        }

        public static void ChooseValidOption(string name, string option, out string choice)
        {

            string delimiter = "MENU";



            if(option != "1" && option != "2" && option != "3")
            {
                Console.WriteLine($"{option} is not a valid option! Choose one of the options below");
            }
            else
            {
                Console.WriteLine($"Choose one of the options below");
            }

            

            Menu.delimiter(delimiter);

            Menu.WelcomeCompliment(name);

            choice = Console.ReadLine();
        }

        public static void Bye()
        {
            Console.WriteLine("See ya!");

        }

    }
}


    




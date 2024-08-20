using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;
using Newtonsoft.Json;

namespace ProjectPokemon
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            Menu.welcome(out string name, out string choice);
            //Console.WriteLine(name);

            bool FirstLoop = true;

            do
            {
                if (!FirstLoop)
                {
                    Menu.ChooseValidOption(out choice);
                }

                switch (choice)
                {   
                    case "1":
                        await Menu.ChoosePokemon(name);
                        break;
                    case "2":
                        //i have to develop the "view my currentpokemon" part
                        break;
                    case "3":
                        Menu.bye();
                        break;
                }
                FirstLoop = false;

            } while (choice != "1" && choice != "2" && choice != "3"); 

            //await ChoosePokemon();
            //Console.WriteLine("decision");

            // checkpokemon();
            
            Console.ReadLine();
        }

        /*static async Task ChoosePokemon(string name)
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
            Menu.delimiter(delimiter);


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
                    await CheckPokemon(choice);

                    Console.WriteLine($"Type 1 if you want to select this pokemon or 0 if you want to go back to your options");
                    

                    decision = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"{choice} is not available in the options you can choose from.");
                    decision = "0";
                }
                
            }
        }*/

        public static async Task CheckPokemon(string choice)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            //var client = new RestClient("https://jsonplaceholder.typicode.com/");

            var request = new RestRequest(choice, Method.Get);
            //var request = new RestRequest("posts");
            var response = await client.GetAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                PokemonStats deserialized = JsonConvert.DeserializeObject< PokemonStats >(response.Content);


                //Console.WriteLine($"{response.Content}");
                Console.WriteLine($"BASE EXPERIENCE: {deserialized.BaseExperience}");
                Console.Write($"ABILITIES: ");
             
                foreach (var ability in deserialized.Abilities)
                {
                    Console.Write($"{ability.Ability.Name}, ");
                }

                Console.Write($"\nHELD ITEMS: ");

                foreach (var items in deserialized.Held_Items)
                {
                    Console.Write($"{items.Item.Name}, ");
                }

                Console.WriteLine();
                Console.WriteLine($"HEIGHT: {deserialized.Height}");
                Console.WriteLine($"WEIGHT: {deserialized.Weight}");
                
            }
            else
            {
                Console.WriteLine($"{response.ErrorMessage}");
            }

            //Console.WriteLine($"{response.StatusCode}");
            //Console.WriteLine($"{System.Net.HttpStatusCode.OK}");

        }

    }   

}

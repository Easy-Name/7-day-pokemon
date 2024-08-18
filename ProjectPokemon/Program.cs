using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
//using RestSharp.Authenticators;
namespace ProjectPokemon
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            await ChoosePokemon();
            //Console.WriteLine("decision");

            // checkpokemon();
            
            Console.ReadLine();
        }

        static async Task ChoosePokemon()
        {
            //string[] PokemonList = { "1 - Alakazam", "2 - Machamp", "3 - Onix", "4 - Gyarados", "5 - Lapras", "6 - Snorlax" };
            
            Dictionary<string, string> pokemonlist = new Dictionary<string, string>();
            pokemonlist.Add("65", "Alakazam");
            pokemonlist.Add("68", "Machamp");
            pokemonlist.Add("95", "Onix");
            pokemonlist.Add("130", "Gyarados");
            pokemonlist.Add("131", "Lapras");
            pokemonlist.Add("143", "Snorlax");

            Console.WriteLine($"Hello, type the number of the pokemon specie from the list below to check its skills");

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
                    await checkpokemon(choice);

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

        static async Task checkpokemon(string choice)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            //var client = new RestClient("https://jsonplaceholder.typicode.com/");

            var request = new RestRequest(choice, Method.Get);
            //var request = new RestRequest("posts");
            var response = await client.GetAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"{response.Content}");
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

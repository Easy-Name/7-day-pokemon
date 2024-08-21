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

            await Play();

            Console.ReadLine();
        }


        static async Task Play()
        {
            Menu.welcome(out string name, out string choice);
            //Console.WriteLine(name);

            bool FirstLoop = true;
            List<string> adoptedPokemon = new List<string>();

            do
            {
                if (!FirstLoop)
                {
                    Menu.ChooseValidOption(name, choice, out choice);
                }

                switch (choice)
                {
                    case "1":
                        List<string> ChosenPokemon = await Menu.ChoosePokemon(name);
                        adoptedPokemon.AddRange(ChosenPokemon);
                        break;

                    case "2":
                        Menu.AllTimeAdoptedPokemon(adoptedPokemon);
                        break;
                    case "3":
                        Menu.bye();
                        break;
                }
                FirstLoop = false;

            } while (choice != "3");
        }
        
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

        }

    }   

}

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
            int CurrentPokeQuantity = 0;
            bool FirstLoop = true;
            List<string> adoptedPokemon = new List<string>();
            List<PokemonMetrics> InitializedPokemon = new List<PokemonMetrics>(); // this list is not being generated
            //int PokemonQuantity;
            //int difference;

            do
            {
                if (!FirstLoop)
                {
                    
                    Menu.ChooseValidOption(name, choice, out choice);
                }

                switch (choice)
                {
                    case "1":
                        List<string> ChosenPokemon = await Menu.ChoosePokemon(name, CurrentPokeQuantity);
                        adoptedPokemon.AddRange(ChosenPokemon);
                        CurrentPokeQuantity = adoptedPokemon.Count;


                        foreach (string poke in adoptedPokemon)
                        {
                            InitializedPokemon.Add(new PokemonMetrics());
                        }

                        break;

                    case "2":
                        Menu.AllTimeAdoptedPokemon(adoptedPokemon, name, out bool NoPokeAdopted1);

                        break;
                    case "3":

                        int pokemonchoice = 1;

                        bool loop = true;
                        while (pokemonchoice != 0)
                        {
                            Menu.delimiter("EMPTY");

                            if (adoptedPokemon.Count > 0) { Console.WriteLine($"{name} choose the Pokemon you want to interact with or type \"0\" to return to main menu"); }

                            
                            Menu.AllTimeAdoptedPokemon(adoptedPokemon, name, out bool NoPokeAdopted2);

                            if (NoPokeAdopted2) 
                            {   
                                loop = false;
                                pokemonchoice = 0;
                            } 
                            else 
                            {
                                string UserInput = Console.ReadLine();
                                
                                bool ParseOK = int.TryParse(UserInput, out pokemonchoice); //improve in case user types something that is not convertable to number or falls out of range (case scenario: when you havent adopted any pokemon yet)

                                if (pokemonchoice == 0) { loop = false; }

                                if (adoptedPokemon.Count - pokemonchoice < 0 || pokemonchoice > adoptedPokemon.Count || ParseOK == false)
                                {
                                    Console.WriteLine($"{UserInput} is not a valid option");
                                }

                            }


                            while (loop)
                            {
                                //Console.WriteLine($"{name}, checkout {adoptedPokemon[pokemonchoice]}'s condition");

                                System.Threading.Thread.Sleep(500);
                                Console.WriteLine($"Fullness: {InitializedPokemon[pokemonchoice-1 ].Fullness}/10");
                                System.Threading.Thread.Sleep(500);
                                Console.WriteLine($"Happyness: {InitializedPokemon[pokemonchoice-1].Happyness}/10");
                                System.Threading.Thread.Sleep(500);
                                Console.WriteLine($"Healthiness: {InitializedPokemon[pokemonchoice - 1].Healthiness}/10");
                                System.Threading.Thread.Sleep(500);
                                Console.WriteLine($"Tiredness: {InitializedPokemon[pokemonchoice - 1].Tiredness}/10");
                                System.Threading.Thread.Sleep(300);

                                Console.WriteLine($"{name}, which action would you like {adoptedPokemon[pokemonchoice-1]} to take?\n1 - Eat\n2 - Sleep\n3 - Play\n4 - Workout\n5 - Return to previous menu ");

                                string decide = Console.ReadLine();
                                switch (decide)
                                {
                                    case "1":
                                        InitializedPokemon[pokemonchoice - 1].Eat();
                                        break;

                                    case "2":
                                        InitializedPokemon[pokemonchoice - 1].Sleep();
                                        break;

                                    case "3":
                                        InitializedPokemon[pokemonchoice - 1].Play();
                                        break;

                                    case "4":
                                        InitializedPokemon[pokemonchoice - 1].Workout();
                                        break;

                                    case "5":
                                        loop = false;
                                        break;
                                    default:
                                        Console.WriteLine($"{decide} is not a valid option");
                                        break;
                                }


                            }
                        }

                        break;

                    case "4":
                        Menu.Bye();
                        break;
                }
                FirstLoop = false;

            } while (choice != "4");
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

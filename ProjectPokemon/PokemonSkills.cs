using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemon
{
    public class PokemonStats
    {
        public List<AbilityInfo> Abilities { get; set; }
        public List<HeldItemsInfo> Held_Items { get; set; }

        public float BaseExperience { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        //public Dictionary <string,int> stats;

    }

    public class Ability
    {
        //[JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AbilityInfo
    {
        public Ability Ability { get; set; }
    }

    public class HeldItems
    {
        public string Name { get; set; }
    }
    public class HeldItemsInfo
    {
        public HeldItems Item { get; set; }
    }

    public class PokemonMetrics
    {

        public int Number;

/*
        public PokemonMetrics(int number)
        {
            Number = number;
        }
        */


        public static int MaxStat = 10;
        public static int MinStat = 0;

        static Random Rnd = new Random();

        public double Fullness = Math.Round(Rnd.NextDouble() * (MaxStat - MinStat) + MinStat, 2);
        public double Tiredness = Math.Round(Rnd.NextDouble() * (MaxStat - MinStat) + MinStat, 2);
        public double Happyness = Math.Round(Rnd.NextDouble() * (MaxStat - MinStat) + MinStat, 2);
        public double Healthiness = Math.Round(Rnd.NextDouble() * (MaxStat - MinStat) + MinStat, 2);

        public void Eat()
        {
            if (Fullness > 8) { Fullness = 10; } else { Fullness += 2; }
            if (Happyness > 9.75) { Happyness = 10; } else { Happyness += 0.25; }
            if (Healthiness > 9.5) { Healthiness = 10; } else { Healthiness += 0.5; }
        }

        public void Sleep()
        {
            if (Tiredness < 3) { Tiredness = 0; } else { Tiredness -= 3; }
            if (Fullness < 1) { Fullness = 0; } else { Fullness -= 1; }
        }

        public void Play()
        {
            if (Happyness > 8) { Happyness = 10; } else { Happyness += 2; }
            if (Tiredness > 8.5) { Tiredness = 10; } else { Tiredness += 1.5; }
            if (Healthiness > 9.5) { Healthiness = 10; } else { Healthiness += 0.5; }
        }

        public void Workout()
        {
            if (Happyness > 9.75) { Happyness = 10; } else { Happyness += 0.25; }
            if (Tiredness > 8.0) { Tiredness = 10; } else { Tiredness += 2; }
            if (Healthiness > 8) { Healthiness = 10; } else { Healthiness += 2; }
            if (Fullness < 1) { Fullness = 0; } else { Fullness -= 3; }
        }
    
    } 
}
    



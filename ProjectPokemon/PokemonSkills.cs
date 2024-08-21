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
        public Ability Ability {  get; set; }
    } 

    public class HeldItems
    {
        public string Name {  get; set; }
    }
    public class HeldItemsInfo
    {
        public HeldItems Item { get; set; }
    }

}

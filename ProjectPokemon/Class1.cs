using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemon
{
    public class PokemonStats
    {

        public List<AbilityInfo> Abilities;
        public List<HeldItemsInfo> Held_Items;

        public float base_experience;
        public float height;
        public float weight;

        //public Dictionary <string,int> stats;

    }

    public class Ability
    {
        public string name { get; set; }
    }

    public class AbilityInfo 
    {
        public Ability ability {  get; set; }
    } 

    public class HeldItems
    {
        public string name {  get; set; }
    }
    public class HeldItemsInfo
    {
        public HeldItems item { get; set; }
    }

}

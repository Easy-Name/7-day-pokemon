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

        public float base_experience;
        //public Dictionary <string,int> stats;
        public float height;
        //public string[] held_items;
        public float weight;

    }

    public class Ability
    {
        public string Name { get; set; }
    }

    public class AbilityInfo 
    {
        public Ability Ability {  get; set; }
    }

}

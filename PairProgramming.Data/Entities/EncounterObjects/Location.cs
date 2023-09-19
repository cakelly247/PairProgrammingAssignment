using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PairProgramming.Data.Entities;

namespace PairProgramming.Data.Entities.EncounterObjects
{
    public class Location : PathEncounter
    {
        public Location() {}
        public Location(string name) : base(name)
        {

        }

    }
}
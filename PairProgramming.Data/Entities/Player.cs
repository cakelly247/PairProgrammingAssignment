using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairProgramming.Data.Entities
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public string AgeGroup { get; set; }
        public bool IsDead { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PairProgramming.Data.Entities.Enums;

namespace PairProgramming.Data.Entities
{
    public class PathEncounter
    {
        public PathEncounter(){}
        public PathEncounter(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Options = new List<string>();
        public PathOption PathOption { get; set; }
        public bool BossDead { get; set; } = false;

        public bool IsComplete
        {
            get
            {
                if (BossDead == true)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
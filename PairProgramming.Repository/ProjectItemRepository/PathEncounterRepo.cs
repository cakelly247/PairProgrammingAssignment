using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PairProgramming.Data.Entities;
using PairProgramming.Data.Entities.Enums;

namespace PairProgramming.Repository.ProjectItemRepository
{
    public class PathEncounterRepo
    {
        //* fake database
        List<PathEncounter> pathEncounterDb = new List<PathEncounter>();
        int _counter = 0;

        public PathEncounterRepo()
        {
            SeedEncounter();
            SeedLocation();
        }

        private void SeedLocation()
        {
            PathEncounter location2 = new PathEncounter();
            location2.Name = "Swamp";
            location2.Id = 2;
            AddLocation(location2);

            PathEncounter location3 = new PathEncounter();
            location3.Name = "Shed";
            location3.Id = 3;
            AddLocation(location3);
        }

        public bool AddLocation(PathEncounter location)
        {
            if (location is null)
            return false;
            else
            {
                return true;
            }
        }

        private void SeedEncounter()
        {
            PathEncounter zombieEncounter = new PathEncounter();
            zombieEncounter.Options = new List<string>
            {
                "1. Run through as fast as possible",
                "2. Pick up a nearby stick to defend yourself",
                "3. Pick up the crobar next to you to defend yourself",
                "4. Curl up into the fetal position"
            };
            zombieEncounter.PathOption = PathOption.Left;
            AddPathEncounter(zombieEncounter);

            // <----------------------------------------------->

            PathEncounter shrekEncounter = new PathEncounter();
            shrekEncounter.Options = new List<string>
            {
                "1. Tell him it's your swamp.",
                "2. Use the force on him",
                "3. Curl up into the fetal position"
            };
            shrekEncounter.PathOption = PathOption.Center;
            AddPathEncounter(shrekEncounter);

            // <----------------------------------------------->

            PathEncounter draculaEncounter = new PathEncounter();
            draculaEncounter.Options = new List<string>
            {
                "1. Continue to run as fast as you can.",
                "2. Climb a tree",
                "3. Throw garlic in his face and stab him with a stake",
                "4. Curl up into the fetal position"
            };
            draculaEncounter.PathOption = PathOption.Right;
            AddPathEncounter(draculaEncounter);

            // PathEncounter campPathRight = new PathEncounter();
            // campPathRight.Options = new List<string>
            // {
            //     "You've come to a dead end and were swarmed by ghosts."
            // };
            // campPathRight.PathOption = PathOption.Right;
            // AddPathEncounter(campPathRight);

            // PathEncounter campPathCenter = new PathEncounter();
            // campPathCenter.Options = new List<string>
            // {
            //     "The path leads on forever and night falls and the werewolves get you."
            // };
            // campPathCenter.PathOption = PathOption.Center;
            // AddPathEncounter(campPathCenter);
        }



        public bool AddPathEncounter(PathEncounter encounter) 
        {
            if(encounter is null)
            return false;
            else
            {
                _counter++;
                encounter.Id = _counter;
                pathEncounterDb.Add(encounter);
                return true;
            }
        }

        public List<string> GetPathOptionsById(int id)
        {
            foreach(var path in pathEncounterDb)
            {
                if(path.Id == id)
                return path.Options;
                else
                {
                    
                    // System.Console.WriteLine("You chose the wrong path... Try Again!\n"+
                    //                             "Press any Key to continue\n");
                    // Console.ReadKey();
                    // RestartGame();
                }
            }
            return null!;
        }
    }
}
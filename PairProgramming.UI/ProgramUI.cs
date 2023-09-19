using static System.Console;
using PairProgramming.Data.Entities;
using PairProgramming.Repository.ProjectItemRepository;
using PairProgramming.Data.Entities.Enums;

namespace PairProgramming.UI
{
    public class ProgramUI
    {
        // private readonly ProjectItemRepo _projRepo = new ProjectItemRepo();
        private readonly PathEncounterRepo _pathEncounterRepo = new PathEncounterRepo();
        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            
            while(isRunning)
            {
                //* Game Code goes here!
                WriteLine("Welcome\n"+
                                        "1. Start Game.\n"+
                                        "2. Exit App\n");
                string userInput = ReadLine()!;

                switch (userInput)
                {
                    case "1":
                    StartGame();
                    break;

                    case "2":
                    isRunning = ExitApplication();
                    break;

                    default:
                    WriteLine("Invalid Selection");
                    break;
                }
            }
        }

        private void StartGame()
        {
            Console.Clear();
            System.Console.WriteLine("It's dusk and you find out the forest you're in is Haunted!");
            System.Console.WriteLine("You need to navigate through the Forest in order to get to safety.\n"+
                                        "Which path will you take?");
            DisplayPathOption();
            string userInput = Console.ReadLine();
            int conversionInt = int.Parse(userInput);
            PathOption selectedPath = (PathOption)conversionInt; //! <---- Turns int -> PathOption
            if(selectedPath == PathOption.Left)
            {
                Console.Clear();
                System.Console.WriteLine("The path is blocked by zombies\n"+
                                        "\n"+
                                        "Choose a number for what to do next.\n"+
                                        "\n");
                var PathOption = _pathEncounterRepo.GetPathOptionsById(1);
                //* This is where the user makes a choice
                foreach(var option in PathOption)
                {
                    System.Console.WriteLine(option);
                }
                var userInputZombieEncounter = int.Parse(Console.ReadLine());
                var actualSelectedValue = PathOption[userInputZombieEncounter - 1];
                if (actualSelectedValue == "3. Pick up the crobar next to you to defend yourself")
                {
                    GoToLocation2();
                }
                else
                {
                    Death();
                }
            }

            if(selectedPath == PathOption.Right)
            {
                System.Console.WriteLine("You've come to a dead end and were swarmed by ghosts.");
                Thread.Sleep(2000);
                Death();
            }

            if(selectedPath == PathOption.Center)
            {
                System.Console.WriteLine("The path leads on forever and night falls and the werewolves get you.");
                Thread.Sleep(2000);
                Death();
            }

            ReadKey();
        }

        private void GoToLocation2()
        {
            Clear();
            System.Console.WriteLine("Well Done! You fought your way through the zombie horde Successfully! Now approaching the next area...\n"+
                                        "Press any key to Continue");
            Console.ReadKey();
            Clear();
            Console.WriteLine("Welcome to the Swamp. Which path will you take?");
            DisplayPathOption();
            string userInput = Console.ReadLine();
            int conversionInt = int.Parse(userInput);
            PathOption selectedPath = (PathOption)conversionInt;
            if(selectedPath == PathOption.Left)
            {
                System.Console.WriteLine("You walk into a spider web and are eaten by a Giant Spider!");
                Thread.Sleep(2000);
                Death();
            }

            if(selectedPath == PathOption.Right)
            {
                System.Console.WriteLine("You step into a Bubbling Pool of Acid.");
                Thread.Sleep(2000);
                Death();
            }

            if(selectedPath == PathOption.Center)
            {
                Console.Clear();
                System.Console.WriteLine("Shrek comes out of nowhere and blocks the path.\n"+
                                        "\n"+
                                        "Choose a number for what to do next.\n"+
                                        "\n");
                var PathOption = _pathEncounterRepo.GetPathOptionsById(2);
                //* This is where the user makes a choice
                foreach(var option in PathOption)
                {
                    System.Console.WriteLine(option);
                }
                var userInputShrekEncounter = int.Parse(Console.ReadLine());
                var actualSelectedValue = PathOption[userInputShrekEncounter - 1];
                if (actualSelectedValue == "2. Use the force on him")
                {
                    GoToLocation3();
                }
                else
                {
                    Death();
                }
            }
        }

        private void GoToLocation3()
        {
            Clear();
            System.Console.WriteLine("Shrek stands no chance against a the power the Force!\n"+
                                    "It is now Your Swamp, Congratulations\n"+
                                    "Press any key to Continue\n");
            Console.ReadKey();
            Clear();
            Console.WriteLine("You leave your newly found Swamp and head for the Shed.\n"+
                                "Choose your final path to escape the forest...");
            DisplayPathOption();
            string userInput = Console.ReadLine();
            int conversionInt = int.Parse(userInput);
            PathOption selectedPath = (PathOption)conversionInt;
            if(selectedPath == PathOption.Left)
            {
                System.Console.WriteLine("The path leads on forever and night falls and the werewolves get you.");
                Thread.Sleep(2000);
                Death();
            }
            if(selectedPath == PathOption.Right)
            {
                Console.Clear();
                System.Console.WriteLine("Count Dracula flies out of the Shed and Attacks!\n"+
                                        "\n"+
                                        "Choose a number for what to do next. BE QUICK\n"+
                                        "\n");
                var PathOption = _pathEncounterRepo.GetPathOptionsById(3);
                //* This is where the user makes a choice
                foreach(var option in PathOption)
                {
                    System.Console.WriteLine(option);
                }
                var userInputDraculaEncounter = int.Parse(Console.ReadLine());
                var actualSelectedValue = PathOption[userInputDraculaEncounter - 1];
                if (actualSelectedValue == "3. Throw garlic in his face and stab him with a stake")
                {
                    System.Console.WriteLine("Congratulations!!! You have escaped the Haunted Forest.");
                    Thread.Sleep(3000);
                    ExitApplication();
                }
                else
                {
                    Death();
                }
            }

            if(selectedPath == PathOption.Center)
            {
                System.Console.WriteLine("You've come to a dead end and were swarmed by ghosts... So close!");
                Thread.Sleep(2000);
                Death();
            }

        }

        private void Death()
        {
            System.Console.WriteLine("You died!");
            System.Console.WriteLine("Dou you want to try again? y/n");
            var userInput = Console.ReadLine();
            if (userInput.ToLower() == "Y".ToLower())
            {
                StartGame();
            }
            else
            {
                ExitApplication();
            }
        }



        private void DisplayPathOption()
        {
            System.Console.WriteLine($"1. Left\n"+
                                        "2. Right\n"+
                                        "3. Center\n");
        }

        private bool ExitApplication()
        {
            Console.Clear();
            Console.WriteLine("Thanks for Playing! Press any Key.");
            Console.ReadKey();
            return false;
        }

    }
}
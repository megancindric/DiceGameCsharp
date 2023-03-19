using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class Game
    {
        string playerOneName;
        string playerTwoName;
        int playerOneScore;
        int playerTwoScore;
        int numberOfSides;
        Random rand;

        public Game() {
            playerOneScore = 0;
            playerTwoScore = 0;
            

            rand = new Random();
        }

        public int RollDice()
        {
            return rand.Next(1,numberOfSides);
        }

        public void DisplayWelcome()
        {

            Console.WriteLine("Weeeeeeeeellllllcome to the Thuuuuuunderrrrrdomeeeee!!!");
        }

        public void AssignNames()
        {
            Console.WriteLine("First, what is your name, traveler? > ");
            playerOneName = Console.ReadLine();
            Console.WriteLine($"Greetings, {playerOneName}!  Would you like to select a name for your opponent? (y/n) >");
            string userChoice = Console.ReadLine();
            while(userChoice != "y" && userChoice != "n")
            {
                Console.WriteLine("Invalid choice, please enter either y or n!");
                userChoice = Console.ReadLine();
            }
            if (userChoice == "n")
            {
                playerTwoName = "Bert Macklin";
            }
            else
            {
                Console.WriteLine("Please enter Player Two's name > ");
                playerTwoName = Console.ReadLine();
            }
            Console.WriteLine($"Perfect!  It looks like {playerOneName} will be facing off against {playerTwoName} then!");
        }

        public void ChooseNumberOfSides()
        {
            Console.WriteLine("First, let's decide what kind of die we're playing with!\n\nPlease enter number of sides > ");
            int numSides = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Alright, so {numSides} number of sides it is!\n\n");
            numberOfSides = numSides;
        }

        public void CompareRolls(int pOneRole, int pTwoRole)
        {
            Console.WriteLine($"{playerOneName} rolled {pOneRole}\n");
            Console.WriteLine($"{playerTwoName} rolled {pTwoRole}\n");
            if ( pOneRole == pTwoRole)
            {
                Console.WriteLine("So it looks like this round's a tie!\n");
            }
            else if ( pOneRole > pTwoRole)
            {
                Console.WriteLine($"So it looks like {playerOneName} wins this round!\n");
                playerOneScore++;
            }
            else
            {
                Console.WriteLine($"So it looks like {playerTwoName} wins this round!\n");
                playerTwoScore++;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine(); 
        }

        public void DisplayWinner()
        {
            if(playerOneScore > playerTwoScore)
            {
                Console.WriteLine($"This game's winner is {playerOneName}!!  Nice work!!");
            }
            else
            {
                Console.WriteLine($"This game's winner is {playerOneName}!!  What an epic battle that was!!!");

            }
        }
        public void RunGameRound()
        {
            int pOneRole = RollDice();
            int PTwoRole = RollDice();
            CompareRolls(pOneRole, PTwoRole);
        }
        public void RunGame()
        {
            DisplayWelcome();
            AssignNames();
            ChooseNumberOfSides();
            while(playerOneScore < 3 && playerTwoScore < 3)
            {
                RunGameRound();
            }
            DisplayWinner();
        }
    }
       
}

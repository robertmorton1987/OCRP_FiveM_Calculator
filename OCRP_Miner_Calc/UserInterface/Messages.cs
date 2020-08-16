using System;

namespace OCRP_Miner_Calc.UserInterface
{
    public class Messages
    {
        public const string WelcomeMsg = "OCRP Mining/Fishing Calculator POC";
        public const string ContinueMsg = "Press Enter to Continue";
        public const string OptionMsg = "Please Select an Option:";
        public const string InvalidMsg = "Invalid Entry... Please Try Again.";
        public const string ExitMsg = "Exit Program? (Y)es/(N)o";

        public const string RunAgainMsg = "Run Another Calculation? (Y)es/(N)o";

        public const string FishHeaderMsg = "Fishing Calculator";
        public const string FishLabelMsg = "Enter Amount of Fish Gathered: ";

        public const string MiningHeaderMsg = "Mining Calculator \n NOTE: Calculation does NOT include Diamond Profit...";
        public const string MiningLabelMsg = "Enter Amount of Rocks Gatherd: ";

        public const string DiamondPromptMsg = "Do you want to add the collected Diamonds? (Y)es/(N)o";
        public const string DiamondLabelMsg = "Enter Amount of Diamonds: ";

        public string MainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine(OptionMsg);
            Console.WriteLine("1) Mining Calculator");
            Console.WriteLine("2) Fishing Calculator");
            Console.WriteLine("9) Quit");

            return Console.ReadLine();
        }

        public string ExitProgram()
        {
            Console.WriteLine(ExitMsg);
            return Console.ReadLine();
        }

        public void Welcome()
        {
            Console.WriteLine(WelcomeMsg);
        }

        public void Continue()
        {
            Console.WriteLine(ContinueMsg);
        }

        public void Invalid()
        {
            Console.WriteLine(InvalidMsg);
        }

        public void ClearBoard()
        {
            Console.Clear();
        }

        public void DisplayChoice(int choice)
        {
            Console.WriteLine("Selected Option: {0}", choice);
            Console.WriteLine();
        }

        public string DisplayFishHeader()
        {
            Console.WriteLine(FishHeaderMsg);
            Console.WriteLine();
            Console.WriteLine(FishLabelMsg);

            return Console.ReadLine();
        }

        public string DisplayMiningHeader()
        {
            Console.WriteLine(MiningHeaderMsg);
            Console.WriteLine();
            Console.WriteLine(MiningLabelMsg);

            return Console.ReadLine();
        }

        public string RunAgain()
        {
            Console.WriteLine(RunAgainMsg);
            return Console.ReadLine();
        }

        public string DisplayDiamondPrompt()
        {
            Console.WriteLine(DiamondPromptMsg);

            return Console.ReadLine();
        }

        public string DisplayDiamondLabel()
        {
            Console.WriteLine(DiamondLabelMsg);

            return Console.ReadLine();
        }
    }
}

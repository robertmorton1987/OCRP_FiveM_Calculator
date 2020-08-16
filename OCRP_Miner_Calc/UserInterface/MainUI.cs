using System;
using OCRP_Miner_Calc.BusinessLogic;

namespace OCRP_Miner_Calc.UserInterface
{
    public class MainUi
    {
        private readonly Manager _mgr;
        private readonly Messages _msg;

        public MainUi()
        {
            _mgr = new Manager();
            _msg = new Messages();
        }

        public void Start()
        {
            var continueProgram = true;

            _msg.Welcome();
            _msg.Continue();
            Console.ReadKey();

            while (continueProgram)
            {
                _msg.ClearBoard();

                var selection = _msg.MainMenu();

                if (string.IsNullOrEmpty(selection) || !int.TryParse(selection, out var option))
                {
                    _msg.ClearBoard();

                    _msg.Invalid();
                    _msg.Continue();
                    Console.ReadLine();
                }
                else
                    continueProgram = ProcessOption(option);
            } 

            Environment.Exit(0);
        }

        private bool ProcessOption(int option)
        {
            var toContinue = true;

            _msg.DisplayChoice(option);

            switch (option)
            {
                //Calculate Mining
                case 1:
                    var rockAmount = _msg.DisplayMiningHeader();

                    if (string.IsNullOrEmpty(rockAmount) || !int.TryParse(rockAmount, out var rocks))
                    {
                        _msg.ClearBoard();

                        _msg.Invalid();
                        _msg.Continue();
                        Console.ReadLine();
                    }
                    else
                    {
                        var totals = _mgr.CalculateMining(rocks);

                        Console.WriteLine("Totals based on {0} Rocks: ", rocks);

                        Console.WriteLine("Amount of Copper: {0} \n Expected Profit: $ {1}", totals.CopperReturned, totals.CopperProfit);
                        Console.WriteLine("Amount of Iron: {0} \n Expected Profit: $ {1}", totals.IronReturned, totals.IronProfit);
                        Console.WriteLine("Amount of Gold: {0} \n Expected Profit: $ {1} \n\n", totals.GoldReturned, totals.GoldProfit);

                        Console.WriteLine("Total Expected Profit (not counting Diamonds): $ {0} \n", totals.TotalProfit);

                        var runDiamonds = _msg.DisplayDiamondPrompt();

                        if (runDiamonds.ToUpper() == "Y")
                        {
                            var diamondAmount = _msg.DisplayDiamondLabel();

                            if (string.IsNullOrEmpty(rockAmount) || !int.TryParse(diamondAmount, out var diamonds))
                            {
                                _msg.ClearBoard();

                                _msg.Invalid();
                                _msg.Continue();
                                Console.ReadLine();
                            }
                            else
                            {
                                var diamondTotal = _mgr.CalculateDiamonds(diamonds);

                                var finalProfit = totals.TotalProfit + diamondTotal;

                                Console.WriteLine("Amount of Diamonds: {0} /n Expected Profit: $ {1}", diamonds, diamondTotal);

                                Console.WriteLine("Total Expected Profit: $ {0}", finalProfit);
                            }
                        }

                        var runAgain = _msg.RunAgain();

                        toContinue = runAgain.ToUpper() == "Y";
                    }

                    Console.ReadKey();
                    break;
                //Calculate Fish
                case 2:
                    var fishAmount = _msg.DisplayFishHeader();

                    if (string.IsNullOrEmpty(fishAmount) || !int.TryParse(fishAmount, out var fish))
                    {
                        _msg.ClearBoard();

                        _msg.Invalid();
                        _msg.Continue();
                        Console.ReadLine();
                    }
                    else
                    {
                        var profit = _mgr.CalculateFish(fish);

                        Console.WriteLine("Total Expected Profit for {0} fish: $ {1}", fish, profit);
                        Console.WriteLine();

                        var runAgain = _msg.RunAgain();

                        toContinue = runAgain.ToUpper() == "Y";
                    }

                    break;
                //Exit Program.
                case 9:
                    var confirm = _msg.ExitProgram();

                    toContinue = confirm.ToUpper() != "Y";
                    break;
                //Invalid Entry...
                default:
                    _msg.Invalid();
                    _msg.Continue();
                    break;
            }

            return toContinue;
        }
    }
}

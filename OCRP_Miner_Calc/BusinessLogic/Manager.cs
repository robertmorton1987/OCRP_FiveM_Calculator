using OCRP_Miner_Calc.Model;

namespace OCRP_Miner_Calc.BusinessLogic
{
    public class Manager
    {
        //Fishing Price
        private const int FishPrice = 100;

        //Mining Prices
        private const int GoldPrice = 40;
        private const int IronPrice = 70;
        private const int CopperPrice = 23;
        private const int DiamondPrice = 1400;

        //Rock Smelting (1 Washed Rock -> X copper/iron/gold)
        private const int CopperGiven = 8;
        private const int IronGiven = 6;
        private const int GoldGiven = 3;

        public int CalculateFish(int amount)
        {
            return amount * FishPrice;
        }

        public MiningMaterials CalculateMining(int amount)
        {
            var material = new MiningMaterials
            {
                CopperReturned = amount * CopperGiven,
                GoldReturned = amount * GoldGiven,
                IronReturned = amount * IronGiven
            };
            
            material.CopperProfit = CalculateProfit(CopperPrice, material.CopperReturned);
            material.GoldProfit = CalculateProfit(GoldPrice, material.GoldReturned);
            material.IronProfit = CalculateProfit(IronPrice, material.IronReturned);

            material.TotalProfit = material.CopperProfit + material.IronProfit + material.GoldProfit;

            return material;
        }

        private static int CalculateProfit(int price, int amount)
        {
            return price * amount;
        }

        public int CalculateDiamonds(int diamonds)
        {
            return CalculateProfit(DiamondPrice, diamonds);
        }
    }
}

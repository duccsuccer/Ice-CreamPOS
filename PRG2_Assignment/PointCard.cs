using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment : Customer
{
    internal class PointCard
    {
        public int Points { get; set; }
        public int PunchCard { get; set; }
        
        public string Tier { get; set; }
        public PointCard() { }
        public PointCard(int points, int punchCard)
        {
            Points = points;
            PunchCard = punchCard;

        }
        public void AddPoints(int points)
        {
            float total = Customer.Order.CalculateTotal();
            int points = (int)Math.Floor(total * 0.72);
        }
        public void RedeemPoints(int points)
        {
            if (Tier != "Silver" || Tier != "Gold")
            {
                return;
            }

            float discount = points * 0.02;
            points = 0;
        }
        public void Punch()
        {
            PunchCard++;
        }
        public override string ToString()
        {
            return base.ToString() + $"Points: {Points} NumberOfPunch: {PunchCard} Tier: {Tier}";
        }

    }
}

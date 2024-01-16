using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment 
{
    internal class PointCard : Customer
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

            double total = 2.5;
            points = (int)Math.Floor(total * 0.72);
        }
        public void RedeemPoints(int points)
        {
            if (Tier != "Silver" || Tier != "Gold")
            {
                return;
            }

            double discount = points * 0.02;
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

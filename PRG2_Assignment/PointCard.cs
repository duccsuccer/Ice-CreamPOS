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
            Points += points;
        }
        public void RedeemPoints(int points)
        {
            if (Tier != "Silver" || Tier != "Gold")
            {
                return;
            }
            double discount = points * 0.02;
        }
        public void Punch()
        {           
            PunchCard++;
            if(PunchCard == 11)
            {
                PunchCard = 0;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"Points: {Points} NumberOfPunch: {PunchCard} Tier: {Tier}";
        }

    }
}

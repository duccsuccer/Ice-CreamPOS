using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_Assignment
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
            
        }
        public void RedeemPoints(int points)
        {

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

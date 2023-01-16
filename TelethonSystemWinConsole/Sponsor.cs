using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelethonSystemWinConsole
{
    class Sponsor: Person
    {
        string sponsorID;
        double totalPrizeValue;

        //public Sponsor(string firstname, string lastname, string sponsID,
        //               double totalPrValue) : base(firstname, lastname)
        public Sponsor(string firstname, string lastname, string sponsID) : base(firstname, lastname)
        {
            this.sponsorID = sponsID;
            this.totalPrizeValue = 0.0;
        }

        public string SponsorID
        {
            get { return sponsorID; }   
            set { sponsorID = value; }  
        }

        public double TotalPrizeValue
        {
            get { return totalPrizeValue; }
            set { totalPrizeValue = value; }
        }

        public override string toString()
        {
            return base.toString() + ", " + SponsorID + ", " + TotalPrizeValue;
        }

        public string getID()
        {
            return SponsorID;
        }

        public double addValue(double num)
        {
            return totalPrizeValue + num;   
        }
    }
}

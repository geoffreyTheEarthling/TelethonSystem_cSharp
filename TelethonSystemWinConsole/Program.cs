using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelethonSystemWinConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ETSManager etsManager = new ETSManager();

            while(true)
            {
                Console.WriteLine("1. Add Donor");
                Console.WriteLine("2. Add Sponsor");
                Console.WriteLine("3. Add Prize");
                Console.WriteLine("4. Add Donation");
                Console.WriteLine("5. Donors List");
                Console.WriteLine("6. Sponsors List");
                Console.WriteLine("7. Prizes List");
                Console.WriteLine("8. Donations List");
                Console.WriteLine("9. Exit");
                Console.WriteLine("Please choose option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        etsManager.addDonor();
                        Console.WriteLine("=============================================");
                        break;
                    case 2:
                        etsManager.addSponsor();
                        Console.WriteLine("=============================================");
                        break;
                    case 3:
                        etsManager.addPrize();
                        Console.WriteLine("=============================================");
                        break;
                    case 4:
                        etsManager.addDonation();
                        Console.WriteLine("=============================================");
                        break;
                    case 5:
                        etsManager.displayListDonors();
                        Console.WriteLine("=============================================");
                        break;
                    case 6:
                        etsManager.displayListSponsors();
                        Console.WriteLine("=============================================");
                        break;
                    case 7:
                        etsManager.displayListPrizes();
                        Console.WriteLine("=============================================");
                        break;
                    case 8:
                        etsManager.displayListDonations();
                        Console.WriteLine("=============================================");
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error! Please enter an option between 1 and 9");
                        Console.WriteLine("=============================================");
                        break;
                }
            }
        }
    }
}

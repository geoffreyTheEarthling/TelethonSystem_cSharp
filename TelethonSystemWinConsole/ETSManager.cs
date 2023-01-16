using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TelethonSystemWinConsole
{
    public class ETSManager
    {
        public ETSManager() { }

        Sponsors sponsors = new Sponsors();
        Donors donors = new Donors();
        Prizes prizes = new Prizes();
        Donations donations = new Donations();

        public bool donorIDVerifier(string donID)
        {
            bool flag = false;
            foreach (Donor don in donors)
            {
                if(don.DonorID == donID)
                {
                    flag = true; 
                }
            }
            return flag;
        }

        public void addDonor()
        {
            Console.WriteLine("Please, enter donor ID: ");
            string donorID = Console.ReadLine();
            if(donorID.Length != 4)
            {
                Console.WriteLine("Error! Donor ID must have 4 characters\n");
            }
            else
            {
                if(donorIDVerifier(donorID) == true)
                {
                    Console.WriteLine("Error! This donor ID already exists\n");
                }
                else
                {
                    Console.WriteLine("Please, enter donor's firstname: ");
                    string firstname = Console.ReadLine().Trim();
                    if(firstname.Length > 15)
                    {
                        Console.WriteLine("Error! Firstname should be 15 characters maximum\n");
                    }
                    else
                    {
                        Console.WriteLine("Please, enter donor's lastname: ");
                        string lastname = Console.ReadLine().Trim();
                        if(lastname.Length > 15)
                        {
                            Console.WriteLine("Error! Lastname should be 15 characters " +
                                "maximum\n");
                        }
                        else
                        {
                            Console.WriteLine("Please, enter donor's full address: ");
                            string address = Console.ReadLine();
                            if(address.Length > 40)
                            {
                                Console.WriteLine("Error! Address must be 40 characters maximum\n");
                            }
                            else
                            {
                                Console.WriteLine("Please, enter phone number (e.g. 999 999-9999): ");
                                string phone = Console.ReadLine();
                                Regex phoneNum = new Regex(@"^[0-9]{3}\s[0-9]{3}-[0-9]{4}$");
                                if (phoneNum.IsMatch(phone.Trim()) != true)
                                {
                                    Console.WriteLine("Error! Format must be: 999 999-9999\n");
                                }
                                else
                                {
                                    Console.WriteLine("Please, enter credit card type: ");
                                    char type = Convert.ToChar(Console.ReadLine());
                                    if (type != 'V' && type != 'v' && type != 'M' && type != 'm' &&
                                        type != 'A' && type != 'a')
                                    {
                                        Console.WriteLine("Error! Type must be either 'V' for Visa, " +
                                            "'M' for Mastercard, or 'A' for American Express\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please, enter credit card number: ");
                                        string cardNum = Console.ReadLine();
                                        if ((type == 'V' && cardNum.Length != 16) ||
                                           (type == 'M' && cardNum.Length != 16) ||
                                           (type == 'A' && cardNum.Length != 15))
                                        {
                                            Console.WriteLine("Error! Visa cards and Mastercards must be" +
                                                " exactly 16 digits, and American Express cards 15 digits\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please, enter credit card expiry date" +
                                                " (e.g. MM/YY): ");
                                            string cardExpDate = Console.ReadLine();
                                            Regex expDate = new Regex(@"^(0[1-9]|1[0-2])\/([0-9]{2})$");
                                            if (expDate.IsMatch(cardExpDate.Trim()) != true)
                                            {
                                                Console.WriteLine("Error! Format must be: MM/YY\n");
                                            }
                                            else
                                            {
                                                Donor donor = new Donor(firstname, lastname, donorID, address,
                                                    phone, cardNum, cardExpDate, type);
                                                donors.add(donor);
                                                Console.WriteLine("Donor " + firstname + " " + lastname +
                                                    " has been added to the list\n");
                                            }
                                        }
                                    }
                                }
                            }                          
                        }
                    }                   
                }
            }          
        }//end addDonor

        public bool sponsorIDVerifier(string sponID)
        {
            bool flag = false;
            foreach (Sponsor spon in sponsors)
            {
                if (spon.getID() == sponID)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public void addSponsor()
        {
            Console.WriteLine("Please, enter sponsor ID: ");
            string sponsorID = Console.ReadLine();
            if (sponsorID.Length != 4)
            {
                Console.WriteLine("Error! Sponsor ID must have 4 characters\n");
            }
            else
            {
                if (sponsorIDVerifier(sponsorID) == true)
                {
                    Console.WriteLine("Error! This sponsor ID already exists\n");
                }
                else
                {
                    Console.WriteLine("Please, enter sponsor's firstname: ");
                    string firstname = Console.ReadLine().Trim();
                    Console.WriteLine("Please, enter sponsor's lastname: ");
                    string lastname = Console.ReadLine().Trim();
                    if (firstname.Length + lastname.Length > 30)
                    {
                        Console.WriteLine("Error! Firstname and lastname should be a total of " +
                            "30 characters maximum\n");
                    }
                    else
                    {
                        Sponsor sponsor = new Sponsor(firstname, lastname, sponsorID);
                        sponsors.add(sponsor);
                        Console.WriteLine("Sponsor " + firstname + " " + lastname +
                                            " has been added to the list\n");
                    }                  
                }
            }
        }//end addSponsor

        public bool prizeIDVerifier(string prID)
        {
            bool flag = false;
            foreach (Prize pr in prizes)
            {
                if (pr.getPrizeID() == prID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public void addPrize()
        {
            Console.WriteLine("Please, enter Prize ID: ");
            string prizeID = Console.ReadLine();
            if (prizeID.Length != 4)
            {
                Console.WriteLine("Error! Prize ID must have 4 characters\n");
            }
            else
            {
                if (prizeIDVerifier(prizeID) == true)
                {
                    Console.WriteLine("Error! This Prize ID already exists\n");
                }
                else
                {
                    Console.WriteLine("Please, enter description: ");
                    string desc = Console.ReadLine().Trim();
                    if (desc.Length > 15)
                    {
                        Console.WriteLine("Error! Description should be 15 characters maximum\n");
                    }
                    else
                    {
                        Console.WriteLine("Please enter Sponsor ID: ");
                        string sponsorID = Console.ReadLine();
                        if (sponsorID.Length != 4)
                        {
                            Console.WriteLine("Error! Sponsor ID must have 4 characters\n");
                        }
                        else
                        {
                            if (sponsorIDVerifier(sponsorID) == false)
                            {
                                Console.WriteLine("Error! Sponsor ID not found\n");
                            }
                            else
                            {
                                Console.WriteLine("Please, enter prize value: ");
                                double prValue = Convert.ToDouble(Console.ReadLine());
                                if(prValue > 299.99)
                                {
                                    Console.WriteLine("Error! The value must be less than $300.00\n");
                                }
                                else
                                {
                                    Console.WriteLine("Please, enter the donation limit for" +
                                        " this prize: ");
                                    double donationLimit = Convert.ToDouble(Console.ReadLine());
                                    if(donationLimit < 5 || donationLimit > 999999.99)
                                    {
                                        Console.WriteLine("Error! Donation limit must be between" +
                                            " $5.00 and $999,999.99\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please, enter quantity of prizes " +
                                            "originally available: ");
                                        int originalAvailable = Convert.ToInt32(Console.ReadLine());
                                        if(originalAvailable > 999)   
                                        {
                                            Console.WriteLine("Error! Quantity must be less than " +
                                                "1000\n");
                                        }
                                        //I don't know how to implement currentAvailable
                                        //int currentAvailable = originalAvailable;
                                        Prize prize = new Prize(prizeID, desc, sponsorID, prValue,
                                            donationLimit, originalAvailable);
                                        prizes.add(prize);
                                        Console.WriteLine("Prize " + prizeID + " has been added " +
                                            "to the list\n");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }//end addPrize

        public bool donationIDVerifier(string donID)
        {
            bool flag = false;
            foreach(Donation don in donations)
            {
                if(don.DonationID == donID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public void addDonation()
        {
            Console.WriteLine("Please, enter Donation ID: ");
            string donationID = Console.ReadLine();
            if (donationID.Length != 4)
            {
                Console.WriteLine("Error! Donation ID must have 4 characters\n");
            }
            else
            {
                if (donationIDVerifier(donationID) == true)
                {
                    Console.WriteLine("Error! This donation ID already exists\n");
                }
                else
                {
                    Console.WriteLine("Please, enter donation date (e.g. MM/DD/YYYY): ");
                    string donationDate = Console.ReadLine();
                    Regex donDate = new Regex(@"^(0[1-9]|1[0-2])\/(0[1-9]|[12][0-9]|3[01])\/(202[2-9])$");
                    if(donDate.IsMatch(donationDate.Trim()) != true)
                    {
                        Console.WriteLine("Error! Format must be: MM/DD/YYYY\n");
                    }
                    else
                    {
                        Console.WriteLine("Please, enter donor ID");
                        string donorID = Console.ReadLine();    
                        if(donorID.Length != 5)
                        {
                            Console.WriteLine("Error! Donor ID must have 5 characters\n");
                        }
                        else
                        {
                            if (donorIDVerifier(donorID) != true)
                            {
                                Console.WriteLine("Error! Donor ID not found\n");
                            }
                            else
                            {
                                Console.WriteLine("Please, enter prize ID");
                                string prizeID = Console.ReadLine();
                                if (prizeID.Length != 5)
                                {
                                    Console.WriteLine("Error! Prize ID must have 5 characters\n");
                                }
                                else
                                {
                                    if(prizeIDVerifier(prizeID) != true)
                                    {
                                        Console.WriteLine("Error! Prize ID not found\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please, enter donation amount: ");
                                        double donAmount = Convert.ToDouble(Console.ReadLine());
                                        if(donAmount<5 || donAmount > 999999.99)
                                        {
                                            Console.WriteLine("Error! Donation amount must be between" +
                                                " $5.00 and $999,999.99\n");
                                        }
                                        else
                                        {
                                            Donation donation = new Donation(donationID, donationDate,
                                            donorID, prizeID, donAmount);
                                            donations.add(donation);
                                            Console.WriteLine("Donation " + donationID +
                                                " has been added to the list\n");
                                        }                                     
                                    }
                                }
                            }
                        }                       
                    }
                }
            }
        }// end addDonation

        public void listDonors()
        {
            foreach (Donor don in donors)
            {
                Console.WriteLine(don.toString());
            }
        }

        public void listSponsors()
        {
            foreach (Sponsor spon in sponsors)
            {
                Console.WriteLine(spon.toString());
            }
        }

        public void listPrizes()
        {
            foreach (Prize priz in prizes)
            {
                Console.WriteLine(priz.toString());
            }
        }

        public void listDonations()
        {
            foreach (Donation don in donations)
            {
                Console.WriteLine(don.toString());
            }
        }

        public string listQualifiedPrizes(double donation)
        {
            string list = null;
            foreach (Prize priz in prizes)
            {
                if(priz.Value <= donation)
                {
                    list = priz.toString();   
                }
            }
            return list;
        }

        public bool recordDonation(string prizeID, int numPrizeAwarded, string donorID,
            double donationAmount, string donationDate, string donationID)
        {
            bool flag = false;
            string message = null;
            foreach (Prize priz in prizes)
            {
                if (priz.getPrizeID() == prizeID)
                {
                    if (priz.CurrentAvailable >= numPrizeAwarded)
                    {
                        flag = true;
                        priz.decrease(numPrizeAwarded);
                        addDonation();
                    }
                    else
                    {
                        flag = false;
                        Console.WriteLine("There are " + priz.CurrentAvailable + " left.\n Donation " + donationID + " could not be added");
                    }
                }
                else
                {
                    Console.WriteLine("Error! Prize ID incorrect");
                }
            }
            return flag;
        }

    }//end of ETSManager
}

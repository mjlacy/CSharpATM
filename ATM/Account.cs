using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Account
    {
        decimal balance;
        int acctNumber;
        string name;
        string PIN;

        public Account(int bal, int num, String name, String PIN)
        {
            balance = bal;
            acctNumber = num;
            this.name = name;
            this.PIN = PIN;
        }

        public String getName()
        {
            return name;
        }

        public String getPIN()
        {
            return PIN;
        }

        public void Menu()
        {
            string input;
            do
            {
                Console.WriteLine("|==================================|");
                Console.WriteLine("|        FIRST NATIONAL BANK       |");
                Console.WriteLine("|***********Menu Options***********|");
                Console.WriteLine("|__________________________________|");
                Console.WriteLine("|  Press 1 To Make Deposit         |");
                Console.WriteLine("|  Press 2 To Make Withdrawl       |");
                Console.WriteLine("|  Press 3 To View Current Balance |");
                Console.WriteLine("|  Press 4 To Save/Exit            |");
                Console.WriteLine("|__________________________________|");
                Console.WriteLine("|   Please Make Selection Now...   |");
                Console.WriteLine("|==================================|");
                Console.WriteLine();

                input = Console.ReadLine();

                Console.WriteLine();

                if (input == "1")
                {
                    Deposit();
                }
                else if (input == "2")
                {
                    Withdraw();
                }
                else if (input == "3")
                {
                    CheckBalance();
                }
                else if (input == "4")
                {
                    //do nothing
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose 1, 2, 3, or 4");
                }
                Console.WriteLine();
            } while (input != "4");
        }

        void Deposit()
        {
            Console.WriteLine("\nHow much would you like to deposit? $");
            decimal deposit = 0.00m;
            try
            {
                deposit = decimal.Parse(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Deposits must be a number");
                Deposit();
                return;
            }
            if (deposit > 0.00m)
            {
                balance += deposit;
                Console.WriteLine("\nDeposit of " + string.Format("{0:C}", deposit) + " successful");
            }
            else
            {
                Console.WriteLine("\nYou must enter a number greater than 0.00");
            }
        }

        void Withdraw()
        {
            Console.WriteLine("\nHow much would you like to withdraw? $");
            decimal withdrawl = 0.00m;
            try
            {
                withdrawl = decimal.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Withdrawls must be a number");
                Withdraw();
                return;
            }
            if (withdrawl > 0.00m)
            {
                if (withdrawl <= balance)
                {
                    balance -= withdrawl;
                    Console.WriteLine("\nHere is " + string.Format("{0:C}", withdrawl));
                }
                else
                {
                    Console.WriteLine("\nInsufficent Funds");
                }
            }
            else
            {
                Console.WriteLine("\nYou must enter a number greater than 0.00");
            }
        }

        void CheckBalance()
        {
            Console.WriteLine("\nYour balance is: " + string.Format("{0:C}", balance));
        }
    }
}

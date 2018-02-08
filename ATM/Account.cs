using System;

namespace ATM
{
    [Serializable]
    abstract class Account
    {
        protected decimal Balance { get; set; }
        protected int AcctNumber { get; set; }
        public string Name { get; set; }
        public string PIN { get; set; }
        protected DateTime date1 = new DateTime();
        protected DateTime date2 = new DateTime();
        protected bool firstdateflag = false;
        protected double Rate { get; set; }

        public Account(int bal, int num, String name, String PIN)
        {
            Balance = bal;
            AcctNumber = num;
            Name = name;
            this.PIN = PIN;
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
                    if (firstdateflag == false)
                    {
                        GetDate1();
                        Deposit();
                    }
                    else
                    {
                        GetDate2();
                        GetInterest();
                        Deposit();
                    }
                }
                else if (input == "2")
                {
                    if (firstdateflag == false)
                    {
                        GetDate1();
                        Withdraw();
                    }
                    else if (firstdateflag == true)
                    {
                        GetDate2();
                        GetInterest();
                        Withdraw();
                    }
                }
                else if (input == "3")
                {
                    if (firstdateflag == false)
                    {
                        GetDate1();
                        CheckBalance();
                    }
                    else if (firstdateflag == true)
                    {
                        GetDate2();
                        GetInterest();
                        CheckBalance();
                    }
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
                Balance += deposit;
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
                if (withdrawl <= Balance)
                {
                    Balance -= withdrawl;
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
            Console.WriteLine("\nYour balance is: " + string.Format("{0:C}", Balance));
        }

        void GetDate1()
        {
            Console.WriteLine("Please enter today's date in the format: mm/dd/yyyy");
            String input = Console.ReadLine();
            date1 = DateTime.Parse(input);

            firstdateflag = true;
        }

        void GetDate2()
        {
            Console.WriteLine("Please enter today's date in the format: mm/dd/yyyy");
            String input = Console.ReadLine();
            date2 = DateTime.Parse(input);

            if (date1.Year > date2.Year || date1.Year == date2.Year && date1.DayOfYear > date2.DayOfYear)
            {
                Console.WriteLine("\nYou must enter a later date than the previous date used\n");
                GetDate2();
            }
        }

        protected abstract void GetInterest();
    }
}

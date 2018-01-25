using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class ATM
    {
        static int numberOfAccounts = 3;
        private Account[] myAccounts = new Account[numberOfAccounts];
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            //atm.start();
            atm.greeting();
            atm.runATM();
        }

        void greeting()
        {
            Console.WriteLine("Welcome, is this your first time using the ATM? (Y/N)");
            String input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                populateAcct();
            }
            else if (input == "n" || input == "N")
            {
                //the main method or runATM will take it to runATM
            }
            else
            {
                Console.WriteLine("\nPlese type in Y or N, either case is acceptable\n");
                greeting();
            }
        }

        void runATM()
        {
            try
            {
                selectAcct();
            }
            catch (Exception exc)
            {
                Console.WriteLine("\nInvalid Input\n");
            }
            greeting();
            runATM();
        }

        void populateAcct()
        {
            int index = -99;
            for (int i = 0; i < myAccounts.Length; i++)
            {
                if (myAccounts[i] == null)
                {
                    index = i;
                    break;
                }
            }
            if (index != -99)
            {
                Console.WriteLine("\nPlease enter a name to be associated with the type of account you want");
                String name = Console.ReadLine();
                for (int i = 0; i < myAccounts.Length; i++)
                {
                    if (myAccounts[i] != null && name == myAccounts[i].getName())
                    {
                        Console.WriteLine("\nThat name has already been used\n");
                        greeting();
                        return;
                    }

                    if (name == "")
                    {
                        Console.WriteLine("You must enter a name\n");
                        greeting();
                        return;
                    }
                }
                Console.WriteLine("\nPlease enter a PIN to use with this account");
                String PIN = Console.ReadLine();

                if (PIN == "")
                {
                    Console.WriteLine("You must enter a PIN\n");
                    greeting();
                    return;
                }
                /*
                Console.WriteLine("\nWhat type of account would you like to open, checking, savings, or super saver?");
                String type = Console.ReadLine();
                
                if (type.equalsIgnoreCase("checking"))
                {
                    myAccounts[index] = new Checking(100, index, name, PIN);
                    Console.WriteLine("\nBalances start at $100, and the annual interest rate is 5%");
                }
                else if (type.equalsIgnoreCase("savings"))
                {
                    myAccounts[index] = new Savings(100, index, name, PIN);
                    Console.WriteLine("\nBalances start at $100, and the annual interest rate is 30%");
                }
                else
                {
                    Console.WriteLine("\nInvalid account type");
                    populateAcct();
                }*/
                myAccounts[index] = new Account(100, index, name, PIN);
                Console.WriteLine("\nBalances start at $100, and the annual interest rate is 5%");
            }
            else
            {
                Console.WriteLine("\nSorry, all available accounts are full\n");
                greeting();
            }
        }
        void selectAcct()
        {
            int num = -99;
            String name, PIN;

            try
            {
                Console.WriteLine("\nEnter your account name");
                name = Console.ReadLine();
                Console.WriteLine("\nEnter your PIN");
                PIN = Console.ReadLine();
                for (int i = 0; i < myAccounts.Length; i++)
                {
                    if (myAccounts[i] != null && name == myAccounts[i].getName() && PIN == myAccounts[i].getPIN())
                    {
                        num = i;
                        break;
                    }
                }
                Console.WriteLine();
                myAccounts[num].Menu();
            }
            catch (Exception exc)
            {
                Console.WriteLine("\nInvalid Input");
            }
        }
    }
}

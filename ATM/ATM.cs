using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ATM
{
    class ATM
    {
        static int numberOfAccounts = 3;
        private Account[] myAccounts = new Account[numberOfAccounts];
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.LoadAccounts();
            atm.Greeting();
            atm.RunATM();
        }

        void Greeting()
        {
            Console.WriteLine("Welcome, is this your first time using the ATM? (Y/N)");
            String input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                PopulateAcct();
            }
            else if (input == "n" || input == "N")
            {
                //the main method or runATM will take it to runATM
            }
            else
            {
                Console.WriteLine("\nPlese type in Y or N, either case is acceptable\n");
                Greeting();
            }
        }

        void RunATM()
        {
            try
            {
                SaveAccounts();
                SelectAcct();
            }
            catch (Exception exc)
            {
                Console.WriteLine("\nInvalid Input\n");
            }
            SaveAccounts();
            Greeting();
            RunATM();
        }

        void PopulateAcct()
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
                    if (myAccounts[i] != null && name.ToLowerInvariant() == myAccounts[i].Name.ToLowerInvariant())
                    {
                        Console.WriteLine("\nThat name has already been used\n");
                        Greeting();
                        return;
                    }

                    if (name == "")
                    {
                        Console.WriteLine("You must enter a name\n");
                        Greeting();
                        return;
                    }
                }
                Console.WriteLine("\nPlease enter a PIN to use with this account");
                String PIN = Console.ReadLine();

                if (PIN == "")
                {
                    Console.WriteLine("You must enter a PIN\n");
                    Greeting();
                    return;
                }

                Console.WriteLine("\nWhat type of account would you like to open, checking or savings?");
                String type = Console.ReadLine();
                
                if (type.Equals("checking", StringComparison.InvariantCultureIgnoreCase))
                {
                    myAccounts[index] = new Checking(100, index, name, PIN);
                    Console.WriteLine("\nBalances start at $100, and the annual interest rate is 5%");
                }
                else if (type.Equals("savings", StringComparison.InvariantCultureIgnoreCase))
                {
                    myAccounts[index] = new Savings(100, index, name, PIN);
                    Console.WriteLine("\nBalances start at $100, and the annual interest rate is 10%");
                }
                else
                {
                    Console.WriteLine("\nInvalid account type");
                    PopulateAcct();
                }
            }
            else
            {
                Console.WriteLine("\nSorry, all available accounts are full\n");
                Greeting();
            }
        }

        void SelectAcct()
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
                    if (myAccounts[i] != null && name.ToLowerInvariant() == myAccounts[i].Name.ToLowerInvariant() && PIN == myAccounts[i].PIN)
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

        void SaveAccounts()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Accounts.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, myAccounts);
                stream.Close();
            }
            catch(Exception exc)
            {
                Console.WriteLine();
                Console.WriteLine("Error in SaveAccounts:");
                Console.WriteLine(exc);
            }
        }

        void LoadAccounts()
        {
            try
            {
                if (File.Exists("Accounts.bin"))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("Accounts.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                    myAccounts = (Account[])formatter.Deserialize(stream);
                    stream.Close();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine();
                Console.WriteLine("Error in LoadAccounts:");
                Console.WriteLine(exc);
            }
        }
    }
}

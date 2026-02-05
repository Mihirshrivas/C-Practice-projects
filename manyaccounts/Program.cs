using System;

public enum MenuOption
{
    NewAccount,
    Deposit,
    Withdraw,
    Transfer,
    Print,
    Quit
}

public class Program
{
    public static void Main()
    {
        Bank bank = new Bank();

        MenuOption option;
        do
        {
            Console.WriteLine();
            option = ReadUserOption();
            Console.WriteLine();

            switch (option)
            {
                case MenuOption.NewAccount:
                    DoNewAccount(bank);
                    break;

                case MenuOption.Deposit:
                    DoDeposit(bank);
                    break;

                case MenuOption.Withdraw:
                    DoWithdraw(bank);
                    break;

                case MenuOption.Transfer:
                    DoTransfer(bank);
                    break;

                case MenuOption.Print:
                    DoPrint(bank);
                    break;

                case MenuOption.Quit:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        } while (option != MenuOption.Quit);
    }

    private static MenuOption ReadUserOption()
    {
        int option;
        bool valid;

        do
        {
            Console.WriteLine("  Bank Account Menu ");
            Console.WriteLine("1. New Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Print");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option (1-6): ");

            valid = int.TryParse(Console.ReadLine(), out option);

            if (!valid || option < 1 || option > 6)
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 6.");
            }

        } while (!valid || option < 1 || option > 6);

        return (MenuOption)(option - 1);
    }

    private static Account FindAccount(Bank fromBank)
    {
        Console.Write("Enter account name: ");
        string name = Console.ReadLine();

        Account result = fromBank.GetAccount(name);

        if (result == null)
        {
            Console.WriteLine($"No account found with name {name}");
        }

        return result;
    }

    private static void DoNewAccount(Bank bank)
    {
        try
        {
            Console.Write("Enter account name: ");
            string name = Console.ReadLine();

            Console.Write("Enter starting balance: $");
            decimal balance = decimal.Parse(Console.ReadLine());

            Account newAccount = new Account(name, balance);
            bank.AddAccount(newAccount);

            Console.WriteLine($"Account '{name}' created with balance ${balance}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid amount.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void DoDeposit(Bank toBank)
    {
        try
        {
            Account toAccount = FindAccount(toBank);
            if (toAccount == null) return;

            Console.Write("Enter amount to deposit: $");
            decimal amount = decimal.Parse(Console.ReadLine());

            DepositTransaction tx = new DepositTransaction(toAccount, amount);
            toBank.ExecuteTransaction(tx);
            tx.Print();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid amount.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void DoWithdraw(Bank fromBank)
    {
        try
        {
            Account fromAccount = FindAccount(fromBank);
            if (fromAccount == null) return;

            Console.Write("Enter amount to withdraw: $");
            decimal amount = decimal.Parse(Console.ReadLine());

            WithdrawTransaction tx = new WithdrawTransaction(fromAccount, amount);
            fromBank.ExecuteTransaction(tx);
            tx.Print();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid amount.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void DoTransfer(Bank bank)
    {
        try
        {
            Console.WriteLine("From account:");
            Account fromAccount = FindAccount(bank);
            if (fromAccount == null) return;

            Console.WriteLine("To account:");
            Account toAccount = FindAccount(bank);
            if (toAccount == null) return;

            Console.Write("Enter amount to transfer: $");
            decimal amount = decimal.Parse(Console.ReadLine());

            TransferTransaction tx = new TransferTransaction(fromAccount, toAccount, amount);
            bank.ExecuteTransaction(tx);
            tx.Print();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid amount.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void DoPrint(Bank bank)
    {
        try
        {
            Console.Write("Enter account name to print: ");
            string name = Console.ReadLine();

            Account account = bank.GetAccount(name);
            
            if (account != null)
            {
                account.Print();
            }
            else
            {
                Console.WriteLine($"No account found with name {name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
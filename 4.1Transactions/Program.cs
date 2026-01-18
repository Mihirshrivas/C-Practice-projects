using System;

public enum MenuOption
{
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
        Account account = new Account("Mihir", 1000);
        Account savings = new Account("Savings", 500);

        MenuOption option;
        do
        {
            Console.WriteLine();
            option = ReadUserOption();
            Console.WriteLine();

            switch (option)
            {
                case MenuOption.Deposit:
                    DoDeposit(account);
                    break;

                case MenuOption.Withdraw:
                    DoWithdraw(account);
                    break;

                case MenuOption.Transfer:
                    DoTransfer(account, savings);
                    break;

                case MenuOption.Print:
                    DoPrint(account, savings);
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
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Print");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option (1-5): ");

            valid = int.TryParse(Console.ReadLine(), out option);

            if (!valid || option < 1 || option > 5)
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 5.");
            }

        } while (!valid || option < 1 || option > 5);

        return (MenuOption)(option - 1);
    }

    private static void DoDeposit(Account account)
    {
        Console.Write("Enter amount to deposit: $");
        decimal amount = decimal.Parse(Console.ReadLine());

        DepositTransaction tx = new DepositTransaction(account, amount);
        tx.Execute();
        tx.Print();
    }

    private static void DoWithdraw(Account account)
    {
        Console.Write("Enter amount to withdraw: $");
        decimal amount = decimal.Parse(Console.ReadLine());

        WithdrawTransaction tx = new WithdrawTransaction(account, amount);
        tx.Execute();
        tx.Print();
    }

    private static void DoTransfer(Account from, Account to)
    {
        Console.Write("Enter amount to transfer: $");
        decimal amount = decimal.Parse(Console.ReadLine());

        TransferTransaction tx = new TransferTransaction(from, to, amount);
        tx.Execute();
        tx.Print();
    }

    private static void DoPrint(Account account, Account savings)
    {
        account.Print();
        savings.Print();
    }
}

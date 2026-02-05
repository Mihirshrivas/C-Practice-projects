using System;
using System.Collections.Generic;

public class Bank
{
    private List<Account> _accounts = new List<Account>();
    private List<Transaction> _transactions;

    

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    public Account GetAccount(string name)
    {
        foreach (Account account in _accounts)
        {
            if (account.Name == name)
            {
                return account;
            }
        }
        return null;
    }

    public void ExecuteTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        transaction.Execute();
    }

    public void PrintTransactionHistory()
    {
        Console.WriteLine("\n=== Transaction History ===");
        if (_transactions.Count == 0)
        {
            Console.WriteLine("No transactions recorded.");
        }
        else
        {
            foreach (Transaction transaction in _transactions)
            {
                transaction.Print();
            }
        }
        Console.WriteLine("All transactions have been completed.\n");
    }
}
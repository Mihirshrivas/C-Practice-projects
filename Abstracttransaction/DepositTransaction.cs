using System;

public class DepositTransaction : Transaction
{
    private Account _account;
    private bool _success;

    public override bool Success => _success;

    public DepositTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Deposit(_amount);
    }

    public override void Rollback()
    {
        base.Rollback();
        
        if (_success)
        {
            _account.Withdraw(_amount);
        }
    }

    public override void Print()
    {
        Console.WriteLine($"Deposit: ${_amount} to {_account.Name} - Success: {_success}");
    }
}
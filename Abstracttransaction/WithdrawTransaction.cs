using System;

public class WithdrawTransaction : Transaction
{
    private Account _account;
    private bool _success;

    public override bool Success => _success;

    public WithdrawTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Withdraw(_amount);
    }

    public override void Rollback()
    {
        base.Rollback();
        
        if (_success)
        {
            _account.Deposit(_amount);
        }
    }

    public override void Print()
    {
        Console.WriteLine($"Withdraw: ${_amount} from {_account.Name} - Success: {_success}");
    }
}
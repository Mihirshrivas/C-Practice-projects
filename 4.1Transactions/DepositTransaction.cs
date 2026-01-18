using System;

public class DepositTransaction
{
    private Account _account;
    private decimal _amount;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;

    public bool Success => _success;

    public DepositTransaction(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        if (_executed)
            throw new Exception("Transaction already executed.");

        _executed = true;
        _success = _account.Deposit(_amount);
    }

    public void Rollback()
    {
        if (!_executed)
            throw new Exception("Transaction not executed.");
        if (_reversed)
            throw new Exception("Transaction already reversed.");

        if (_success)
        {
            _account.Withdraw(_amount);
        }

        _reversed = true;
    }

    public void Print()
    {
        Console.WriteLine($"Deposit: ${_amount} to {_account.Name} - Success: {_success}");
    }
}

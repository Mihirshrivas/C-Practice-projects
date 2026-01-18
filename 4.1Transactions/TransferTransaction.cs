using System;

public class TransferTransaction
{
    private WithdrawTransaction _withdraw;
    private DepositTransaction _deposit;
    private bool _executed = false;
    private bool _reversed = false;

    public bool Success => _withdraw.Success && _deposit.Success;

    public TransferTransaction(Account from, Account to, decimal amount)
    {
        _withdraw = new WithdrawTransaction(from, amount);
        _deposit = new DepositTransaction(to, amount);
    }

    public void Execute()
    {
        if (_executed)
            throw new Exception("Transaction already executed.");

        _executed = true;

        _withdraw.Execute();
        if (_withdraw.Success)
        {
            _deposit.Execute();
            if (!_deposit.Success)
            {
                _withdraw.Rollback();
            }
        }
    }

    public void Rollback()
    {
        if (!_executed)
            throw new Exception("Transaction not executed.");
        if (_reversed)
            throw new Exception("Transaction already reversed.");

        if (_deposit.Success)
            _deposit.Rollback();
        if (_withdraw.Success)
            _withdraw.Rollback();

        _reversed = true;
    }

    public void Print()
    {
        Console.WriteLine("Transfer Transaction:");
        _withdraw.Print();
        _deposit.Print();
    }
}

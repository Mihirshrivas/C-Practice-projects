using System;

public class TransferTransaction
{
    private Account _fromAccount;
    private Account _toAccount;
    private decimal _amount;
    private WithdrawTransaction _withdraw;
    private DepositTransaction _deposit;
    private bool _executed = false;
    private bool _reversed = false;

    public bool Success => _withdraw.Success && _deposit.Success;
    public bool Executed => _executed;
    public bool Reversed => _reversed;

    public TransferTransaction(Account from, Account to, decimal amount)
    {
        _fromAccount = from;
        _toAccount = to;
        _amount = amount;
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
                Rollback();
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
        Console.Write($"Transferred ${_amount} from {_fromAccount.Name} to {_toAccount.Name}");
        if (_reversed)
        {
            Console.Write(" (Reversed)");
        }
        Console.WriteLine();
        
        Console.Write("  ");
        _withdraw.Print();
        Console.Write("  ");
        _deposit.Print();
    }
}
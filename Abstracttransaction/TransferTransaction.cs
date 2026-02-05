using System;

public class TransferTransaction : Transaction
{
    private Account _fromAccount;
    private Account _toAccount;
    private WithdrawTransaction _withdraw;
    private DepositTransaction _deposit;

    public override bool Success => _withdraw.Success && _deposit.Success;

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
    {
        _fromAccount = fromAccount;
        _toAccount = toAccount;
        _withdraw = new WithdrawTransaction(_fromAccount, amount);
        _deposit = new DepositTransaction(_toAccount, amount);
    }

    public override void Execute()
    {
        base.Execute();

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

    public override void Rollback()
    {
        base.Rollback();
        
        if (_deposit.Success)
            _deposit.Rollback();
        if (_withdraw.Success)
            _withdraw.Rollback();
    }

    public override void Print()
    {
        Console.WriteLine($"Transferred ${_amount} from {_fromAccount.Name} to {_toAccount.Name}");
        Console.Write("  ");
        _withdraw.Print();
        Console.Write("  ");
        _deposit.Print();
    }
}
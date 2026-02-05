using System;

public abstract class Transaction
{
    protected decimal _amount;
    private bool _executed;
    private bool _reversed;
    private DateTime _dateStamp;

    public abstract bool Success { get; }

    public Transaction(decimal amount)
    {
        _amount = amount;
        _executed = false;
        _reversed = false;
    }

    public abstract void Print();

    public virtual void Execute()
    {
        if (_executed)
            throw new Exception("Transaction already executed.");

        _executed = true;
        _dateStamp = DateTime.Now;
    }

    public virtual void Rollback()
    {
        if (!_executed)
            throw new Exception("Transaction not executed.");
        if (_reversed)
            throw new Exception("Transaction already reversed.");

        _reversed = true;
    }
}
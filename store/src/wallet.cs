using System.ComponentModel;

class Wallet :  ICanSpendMoney, ICanReceiveMoney
{
    private  decimal _amount;

    public decimal Amount => _amount;

    public bool HasMoney(decimal amount)
    {
        if(amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Value invalid!");
        return _amount >= amount;
    }

    public void ReceiveMoney(decimal amount)
    {
        if(amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Value invalid!");

        _amount+=amount;
    }

    public void SpendMoney(decimal amount)
    {
        if(amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Value invalid!");
        _amount-=amount;
    }
}
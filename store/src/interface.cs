interface ICanSpendMoney
{
    bool HasMoney(decimal amount);
    void SpendMoney(decimal amount);
}

interface ICanReceiveMoney
{
    void ReceiveMoney(decimal amount);
}
interface ICanReceiveItems
{
    void AddItem(Item item, int quantity);
}
interface ICanProvideItems
{
    bool HasItemQuantity(Item item, int quantity);
    void RemoveItem(Item item, int quantity);
}

interface ICanBuyItems: ICanReceiveItems, ICanSpendMoney
{
}
interface ICanSellItems: ICanProvideItems, ICanReceiveMoney
{
}
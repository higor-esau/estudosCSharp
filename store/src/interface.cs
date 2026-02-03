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
    bool HasItemQuantity(int itemId, int quantity);
    void RemoveItem(int itemId, int quantity);
}

interface ICanBuyItems: ICanReceiveItems, ICanSpendMoney
{
}
interface ICanSellItems: ICanProvideItems, ICanReceiveMoney
{
    bool TryGetItem(int idItem, out Item? item);
    decimal CalculateTotalPrice(int idItem , int quantity);
}
interface IUsable
{
    void Use();
}
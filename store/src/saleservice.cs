class SaleService
{
    public bool TryExecuteSale(
        ICanSellItems seller, 
        ICanBuyItems buyer,
        int itemId,
        int quantity)
    {
        if (!seller.HasItemQuantity(itemId, quantity))
            return false;

        decimal total = seller.CalculateTotalPrice(itemId, quantity);

        if (!buyer.HasMoney(total))
            return false;

        if (!seller.TryGetItem(itemId, out Item item))
            return false;

        //nesse codigo eu estou assumindo que o removeitem e SpendMoney nunca daram erro, vou adicionar uma exceção se isso vier a ocorrer, como o foco é treinar interfaces, não estou me atendando a tanto detalhes, mas não quer dizer que eu não o perceba.

        // buyer
        buyer.SpendMoney(total);
        buyer.AddItem(item, quantity);

        // seller
        seller.ReceiveMoney(total);
        seller.RemoveItem(itemId, quantity);

        return true;
    }
}

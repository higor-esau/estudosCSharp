class InventoryItem
{
    private Item _item;
    public int Quantity {get; private set;}

    public InventoryItem(Item item, int quantity)
    {
        //estou usando o exception mesmo sem enteder só pra tirar avisos, mas tá na lista de estudos
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        if(quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity),
            "Quantity cannot be negative"
            );
            
        _item = item;
        Quantity = quantity;
    }

    public int Id => _item.Id;
    public bool HasQuantity(int quantity)
    {
        return quantity <= Quantity;
    }
}

class Inventory
{
    private List<InventoryItem> items;

    public Inventory(List<InventoryItem> items)
    {
        this.items = items;
    }

    public bool HasItemQuantity(int itemId, int quantity)
    {
        foreach(var item in items)
        {
            if(itemId == item.Id)
                return item.HasQuantity(quantity);
        }
        return false;
    }
}
class InventoryItem
{
    private readonly Item _item;
    public int Quantity {get; private set;}

    public InventoryItem(Item item, int quantity)
    {
        _item = item;
        Quantity = quantity;
    }

    public int Id => _item.Id;
    public bool HasQuantity(int qtd)
    {
        return qtd <= Quantity;
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
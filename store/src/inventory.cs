class InventoryItem
{
    private Item _item;
    public int Quantity {get; private set;}

    public InventoryItem(Item item, int quantity)
    {
        if(quantity < 0)
            //aqui o certo seria um exceção mas não sei usa-las ainda
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
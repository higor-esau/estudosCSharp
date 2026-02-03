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
    public string Name => _item.Name;

    public int Price => _item.Price;
    public bool HasQuantity(int quantity)
    {
        return quantity <= Quantity;
    }
    public bool RemoveItem(int quantity)
    {
        if(quantity < 0)
            return false;
        if(Quantity < quantity)
            return false;
    
        Quantity-=quantity;
        return true;
    }

    public decimal CalculateTotalPrice(int quantity)
    {
        return quantity * _item.Price;
    }

}

class Inventory: ICanReceiveItems, ICanProvideItems
{
    private List<InventoryItem> items;

    public Inventory(List<InventoryItem> items)
    {
        this.items = items;
    }

    public void AddItem(Item item, int quantity)
    {
        if(quantity < 0)
            throw new ArgumentNullException(nameof(quantity), "Value invalid");
        
        items.Add(new InventoryItem(item, quantity));
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

    public void RemoveItem(int itemId, int quantity)
    {
        foreach(var item in items)
        {
            if(itemId == item.Id){

                if(!item.HasQuantity(quantity)){
                    throw new ArgumentNullException(nameof(quantity), "Value invalid");
                }
                
                if(!item.RemoveItem(quantity)){
                    throw new ArgumentNullException(nameof(quantity), "Erro ao remover");
                }
                break;
            }
        }
    }

    //no momento essa função é um ponto critico, se ela for usada antes de saber se tem o item, vai estourar uma exceção
    public decimal CalculateTotalPrice(int itemId, int quantity)
    {
        foreach(var item in items)
        {
            if(itemId == item.Id){

                if(quantity < 0 )
                    throw new ArgumentNullException(nameof(quantity), "Value invalid");
                
                return item.CalculateTotalPrice(quantity);
            }
        }
        throw new ArgumentNullException(nameof(quantity), "Value invalid");
    }

    //estou criando um item nomo apartir dos dados do item, pra mandar pro novo inventory, ideia minha é que mais pra frente usaremos uma base de itens padrão onde só precisaremos transicionar o id dela, sempre que um inventory não tiver um item nele, ele busca esse id no inventory padrão.
    public bool TryGetItem(int itemId, out Item? item)
    {
        item = null;
        foreach(var i in items)
        {
            if(itemId == i.Id){
                item = new Item(i.Id, i.Name, i.Price);
                return true;
            }
        }
        return false;
    }
}
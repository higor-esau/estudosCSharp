class Item
{
    public int Id {get; private set;}
    public string Name {get; private set;}
    public int Price {get; private set;}

    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }
}
//um pequeno exemplo de polimorfismo
class Consumable : Item
{
    public Consumable(string name, int price) : base(name, price)
    {
    }
}
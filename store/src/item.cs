class Item
{
    public int Id {get; private set;}
    public string Name {get; private set;}
    public int Price {get; private set;}

    public Item(int id, string name, int price)
    {
        Id =id;
        Name = name;
        Price = price;
    }
}
//um pequeno exemplo de polimorfismo
class Consumable : Item
{
    public Consumable(int id, string name, int price) : base(id ,name, price)
    {
    }
}
class Player : ICanBuyItems
{
    string name;
    private Wallet wallet;
    private Inventory inventory;

    public Player(string name, decimal value)
    {
        wallet = new Wallet(value);
        inventory = new Inventory(new List<InventoryItem>());
    }

    public void AddItem(Item item, int quantity) => inventory.AddItem(item, quantity);

    public bool HasMoney(decimal amount) => wallet.HasMoney(amount);

    public void SpendMoney(decimal amount) => wallet.SpendMoney(amount);

    public void Apresentation()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"R$: {wallet.Amount}");
    }
}
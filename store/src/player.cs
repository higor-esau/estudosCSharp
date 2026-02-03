class Player : ICanBuyItems
{
    private Wallet wallet;
    private Inventory inventory;

    public Player(decimal value)
    {
        wallet = new Wallet(value);
        inventory = new Inventory(new List<InventoryItem>());
    }

    public void AddItem(Item item, int quantity) => inventory.AddItem(item, quantity);

    public bool HasMoney(decimal amount) => wallet.HasMoney(amount);

    public void SpendMoney(decimal amount) => wallet.SpendMoney(amount);
}
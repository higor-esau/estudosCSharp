class Store: ICanSellItems
{
    private Wallet wallet;
    private Inventory inventory;

    public Store(decimal amount)
    {
        wallet = new Wallet(amount);
        inventory = new Inventory(StarInventory());
    }

    public decimal CalculateTotalPrice(int idItem, int quantity)
    {
        return inventory.CalculateTotalPrice(idItem, quantity);
    }

    public bool HasItemQuantity(int itemId, int quantity) => inventory.HasItemQuantity(itemId, quantity);

    public void ReceiveMoney(decimal amount) => wallet.ReceiveMoney(amount);

    public void RemoveItem(int itemId, int quantity) => inventory.RemoveItem(itemId, quantity);

    public bool TryGetItem(int idItem, out Item? item)
    {
        return inventory.TryGetItem(idItem, out item);
    }

    private List<InventoryItem> StarInventory()
    {
        List<InventoryItem> inventoryItems = new List<InventoryItem>()
        {
            new(new Item(0,  "Espada Curta",        50),  2),
            new(new Item(1,  "Espada Longa",        80),  3),
            new(new Item(2,  "Machado",             70),  4),
            new(new Item(3,  "Adaga",               30), 10)
        };
        return inventoryItems;

    }

    private List<InventoryItem> StarInventory2()
    {
        List<InventoryItem> inventoryItems = new List<InventoryItem>()
        {
            new InventoryItem(new Item(0,  "Espada Curta",        50),  2),
            new InventoryItem(new Item(1,  "Espada Longa",        80),  3),
            new InventoryItem(new Item(2,  "Machado",             70),  4),
            new InventoryItem(new Item(3,  "Adaga",               30), 10),
            new InventoryItem(new Item(4,  "Arco",                90),  2),
            new InventoryItem(new Item(5,  "Flecha",               5), 50),
            new InventoryItem(new Item(6,  "Poção de Vida",        25), 15),
            new InventoryItem(new Item(7,  "Poção de Mana",        20), 12),
            new InventoryItem(new Item(8,  "Escudo",              60),  3),
            new InventoryItem(new Item(9,  "Capacete",            45),  4),
            new InventoryItem(new Item(10, "Armadura Leve",       120),  2),
            new InventoryItem(new Item(11, "Armadura Pesada",     200),  1),
            new InventoryItem(new Item(12, "Anel de Força",       150),  1),
            new InventoryItem(new Item(13, "Anel de Defesa",      140),  1),
            new InventoryItem(new Item(14, "Bota",                35),  6),
            new InventoryItem(new Item(15, "Luvas",               30),  6),
            new InventoryItem(new Item(16, "Pergaminho de Fogo",  110),  2),
            new InventoryItem(new Item(17, "Pergaminho de Gelo",  110),  2),
            new InventoryItem(new Item(18, "Chave Antiga",         75),  1),
            new InventoryItem(new Item(19, "Mapa Misterioso",     95),  1),
        };
        return inventoryItems;

    }

    private void TheMenu()
    {
        Console.WriteLine("------Nosso itens------");
        inventory.ViewConsole();
        Console.WriteLine("-----------------------");
    }

    public void TrySell(ICanBuyItems buyer)
    {
        SaleService saleService = new();
        int id, quantity;
        while (true)
        {
            TheMenu();
            Console.WriteLine("Escolha o ID do produto que deseja comprar:");
            Console.WriteLine("Digite -1 pra voltar ao menu anterior.");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Digite um valor valido!");
            }

            if (id < 0 ) return;

            Console.WriteLine("Escolha a quantidade que deseja comprar:");
            
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Digite um valor valido!");
            }

            if (quantity < 0 ) return;

           if(!saleService.TryExecuteSale(  this,buyer, id, quantity))
                Console.WriteLine("Tenho uma má noticia, não foi possivel completar sua compra!");
        }
    }

}
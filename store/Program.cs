class Program
{
    public static void Main()
    {
        SaleService saleService = new SaleService();

        //seller
        Store store = new Store(1000);
        decimal x = 1000;
        //buyer
        Player player = new Player("Higor",x);
        player.Apresentation();
        saleService.TryExecuteSale(store,player, 0, 2);
        player.Apresentation();
        saleService.TryExecuteSale(store,player, 0, 2);
        player.Apresentation();

    }
}
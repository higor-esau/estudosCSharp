class SaleService
{
    public bool TryExecuteSale(
        ICanSellItems seller, 
        ICanBuyItems buyer,
        int itemId,
        int quantity)
    {
        Console.WriteLine("#####INICIANDO UMA VENDA#####");
        
        if (!seller.HasItemQuantity(itemId, quantity))
        {
            Console.WriteLine("Não tenho a quantidade de item disponivel!");
            return false;
        }

        decimal total = seller.CalculateTotalPrice(itemId, quantity);

        if (!buyer.HasMoney(total))
        {
            Console.WriteLine("O Comprador está sem money!");
            return false;
        }

        if (!seller.TryGetItem(itemId, out Item? item))
        {
            Console.WriteLine("Erro estranho, impossivel pegar o item");
            return false;
        }

        //nesse codigo eu estou assumindo que o removeitem e SpendMoney nunca daram erro, vou adicionar uma exceção se isso vier a ocorrer, como o foco é treinar interfaces, não estou me atendando a tanto detalhes, mas não quer dizer que eu não o perceba.
        if (item == null)
            throw new ArgumentNullException("Valor de Item nulo, impossivel continuar!");
        // buyer
        buyer.SpendMoney(total);
        buyer.AddItem(item, quantity);

        // seller
        seller.ReceiveMoney(total);
        seller.RemoveItem(itemId, quantity);


        //isso aqui deveria ser uma função aparte que cuidava se tudo desse certo, assim como eu precisava de uma pra se desse errado mais aqui é só estudos de interfaces
        Console.WriteLine($"Você comprou {quantity} unidade(s) do item {item.Name}");

        return true;
    }

}

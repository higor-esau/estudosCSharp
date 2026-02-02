class Reserve
{
    struct ReserveLocal
    {
        public int id{get; private set;}
        public Item item{get; private set;}
        public int quantity{get; private set;}


    }

    private List<ReserveLocal> reserves = new List<ReserveLocal>();



}
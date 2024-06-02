namespace Store.Core.Entities
{
    public class Branch
    {
        public int id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int CountOfSalers { get; set; }
        public List<Saler> Salers { get; set; }
        public List<Book> Books { get; set; }

    }
}

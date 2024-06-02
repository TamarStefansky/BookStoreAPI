namespace Store.Core.Entities
{
    public enum Type { Adult, Teen, Kids, Comix };
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public double Price { get; set; }
        public Type Type { get; set; }
        public List<Branch> Branches { get; set; }
 
    }
}

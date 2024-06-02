namespace Store.Core.Entities
{
    public class Saler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

    }
}

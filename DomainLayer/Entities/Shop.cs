namespace DomainLayer.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public DateTime CreationDate {get; set; }
        public DateTime ChangeDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
namespace Fridge.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Item(int id, string name, DateTime expirationDate)
        {
            Id = id;
            Name = name;
            ExpirationDate = expirationDate;
        }

        public Item() { }

    }
}

namespace Domain
{
    public class Inventory
    {
        protected Inventory() { }

        public Inventory(int quantity, Guid bookId)
        {
            Quantity = quantity;
            BookId = bookId;
        }

        public Guid Id { get; private set; }
        public int Quantity { get; private set; }
        public Guid BookId { get; private set; }
        public Book Book { get; private set; }
        public List<Inventory> Inventories { get; private set; } = new();

        public void EmprestarLivro(int quantidade)
        {
            Quantity -= quantidade;
        }

        public void Add(int quantidade)
        {
            Quantity +=quantidade;
        }
    }
}

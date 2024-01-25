using Domain;

namespace Application.Interfaces
{
    public interface IInventoryPersistence
    {
        Task Create(Inventory inventory);
        Task<Inventory?> GetByBookId(Guid bookId);
        Task Update(Inventory inventory);
    }
}

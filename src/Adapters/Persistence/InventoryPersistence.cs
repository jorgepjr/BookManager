using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Persistence
{
    public class InventoryPersistence : IInventoryPersistence
    {
        private readonly BookManagerContext _context;

        public InventoryPersistence(BookManagerContext context)
        {
            _context = context;
        }

        public async Task Create(Inventory inventory)
        {
            await _context.Iventories.AddAsync(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task<Inventory?> GetByBookId(Guid bookId)
        {
            var inventory = await _context.Iventories.FirstOrDefaultAsync(x=>x.BookId == bookId);

            return inventory;
        }
    }
}

using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Adapters.Persistence
{
    public class ClientPersistence : IClientPersistence
    {
        private readonly BookManagerContext _context;

        public ClientPersistence(BookManagerContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return true;
        }

        
    }
}

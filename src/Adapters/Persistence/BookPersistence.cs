
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Persistence
{
    public class BookPersistence : IBookPersistence
    {
        private readonly BookManagerContext _context;

        public BookPersistence(BookManagerContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Book>> Filter()
        {
            throw new NotImplementedException();
        }

        public async Task<Book?> GetByCode(string code)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x=>x.Code == code);
            return book;
        }

        public async Task<bool> Inactivate()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update()
        {
            throw new NotImplementedException();
        }
    }
}

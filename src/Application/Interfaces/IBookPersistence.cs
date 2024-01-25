using Domain;

namespace Application.Interfaces
{
    public interface IBookPersistence
    {
        Task <bool> Create(Book book);
        Task <bool> Update();
        Task <Book?> GetByCode(string code);
        Task <IEnumerable<Book>> Filter(int page, int itemByPage);
        Task <bool> Inactivate();
        Task<Book>GetById(Guid bookId);
    }
}

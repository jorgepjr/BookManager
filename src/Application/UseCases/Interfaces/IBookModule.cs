using Application.Dtos;
using Domain;

namespace Application.UseCases.Interfaces
{
    public interface IBookModule
    {
        Task<BookDto> Create(BookDto bookDto);
        Task<BookDto> GetByCode(string code);
        Task<IEnumerable<BookDto>> Filter(int page, int itemByPage);
        Task<Book>GetById(Guid bookId);

        ResponseDto Response { get; set; }
    }
}

using Application.Dtos;

namespace Application.UseCases.Interfaces
{
    public interface IBookModule
    {
        Task Create(BookDto bookDto);
        Task<BookDto> GetByCode(string code);
        Task<IEnumerable<BookDto>> Filter(int page, int itemByPage);
        ResponseDto Response { get; set; }
    }
}

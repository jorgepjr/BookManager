using Application.Dtos;

namespace Application.UseCases.Interfaces
{
    public interface IBookModule
    {
        Task Create(BookDto bookDto);
        Task<BookDto> GetByCode(string code);
        ResponseDto Response { get; set; }
    }
}

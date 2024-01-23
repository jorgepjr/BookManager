using Application.Dtos;

namespace Application.UseCases.Interfaces
{
    public interface IBookModule
    {
        Task Create(BookDto bookDto);
        ResponseDto Response { get; set; }
    }
}

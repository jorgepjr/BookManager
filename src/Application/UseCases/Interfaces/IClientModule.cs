using Application.Dtos;

namespace Application.UseCases.Interfaces
{
    public interface IClientModule
    {
        Task Create(ClientDto clientDto);
        ResponseDto Response { get; set; }
    }
}

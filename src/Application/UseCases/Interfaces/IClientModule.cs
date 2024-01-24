using Application.Dtos;

namespace Application.UseCases.Interfaces
{
    public interface IClientModule
    {
        Task<Guid?> Create(ClientDto clientDto);
        Task<ClientDto> GetById(Guid clientId);
        ResponseDto Response { get; set; }
    }
}

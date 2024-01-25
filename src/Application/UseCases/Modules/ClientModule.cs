using Application.Dtos;
using Application.Interfaces;
using Application.UseCases.Interfaces;
using Domain;

namespace Application.UseCases.Modules
{
    public class ClientModule : IClientModule
    {
        private readonly IClientPersistence _clientPersistence;

        public ResponseDto Response { get; set; } = new();

        public ClientModule(IClientPersistence clientPersistence)
        {
            _clientPersistence = clientPersistence;
        }

        public async Task<Guid?> Create(ClientDto clientDto)
        {
            var client = new Client(clientDto.Name, clientDto.Email);

            try
            {
                var successfulRequest = await _clientPersistence.Create(client);

                if (successfulRequest)
                {
                    Response = new ResponseDto { Type = ResponseType.Success, Message = "Client registered successfully" };
                    return client.Id;
                }
            }
            catch (Exception ex)
            {
                Response = new ResponseDto { Type = ResponseType.Error, Message = ex.Message };
            }

            return null;
        }

        public async Task<ClientDto> GetById(Guid clientId)
        {
            var client = await _clientPersistence.GetById(clientId);

            if (client is Client)
            {
                return new ClientDto { Id = client.Id, Name = client.Name, Email = client.Email };
            }

            return new ClientDto { };
        }
    }
}

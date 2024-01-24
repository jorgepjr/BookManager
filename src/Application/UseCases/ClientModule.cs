using Application.Dtos;
using Application.Interfaces;
using Domain;

namespace Application.UseCases
{
    public class ClientModule
    {
        private readonly IClientPersistence _clientPersistence;

        public ResponseDto Response { get; set; } = new();

        public ClientModule(IClientPersistence clientPersistence)
        {
            _clientPersistence = clientPersistence;
        }

        public async Task Create(ClientDto clientDto)
        {
            var client = new Client(clientDto.Name,clientDto.Email);

            try
            {
                var successfulRequest = await _clientPersistence.Create(client);

                if (successfulRequest)
                {
                    Response = new ResponseDto { Type = ResponseType.Success, Message = "Client registered successfully" };

                }
            }
            catch (Exception ex)
            {
                Response = new ResponseDto { Type = ResponseType.Error, Message = ex.Message };
            }
        }
    }
}

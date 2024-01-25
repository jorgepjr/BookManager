using Application.Dtos;
using Application.Interfaces;
using Application.UseCases.Modules;
using Domain;
using Moq;
using Xunit;

namespace Tests;

public class ClientModuleTests
{
    [Fact]
    public async Task MustReturnSuccessMessageOnCreateClient()
    {
        var responseMock = new ResponseDto { Message = "Client registered successfully", Type = ResponseType.Success };

        var clientPersistence = new Mock<IClientPersistence>();
        clientPersistence.Setup(x => x.Create(It.IsAny<Client>())).ReturnsAsync(true);

        var clientModule = new ClientModule(clientPersistence.Object);

        var client = new ClientDto { Name = "joao", Email = "teste@email.com" };

        await clientModule.Create(client);

        Assert.Equal(responseMock.Type, clientModule.Response.Type);
        Assert.Equal(responseMock.Message, clientModule.Response.Message);
    }
}
using Application.Dtos;
using Application.Interfaces;
using Application.UseCases;
using Application.UseCases.Interfaces;
using Application.UseCases.Modules;
using Domain;
using Moq;
using WebApi.Controllers;
using Xunit;

namespace Tests
{
    public class InventoryModuleTests
    {
        [Fact]
        public async Task DeveCriarInventarioDoLivro()
        {
            var clientId = Guid.NewGuid();
            var livroId = Guid.NewGuid();

            var clientModule = new Mock<IClientModule>();
            var bookModule = new Mock<IBookModule>();
            var inventoryPersistence = new Mock<IInventoryPersistence>();

            var inventoryModule = new InventoryModule(clientModule.Object, bookModule.Object, inventoryPersistence.Object);

            await inventoryModule.Create(new InventoryDto { BookId = Guid.NewGuid(), Quantity = 4 });

            inventoryPersistence.Verify(x => x.Create(It.IsAny<Inventory>()), Times.Once());
        }
    }
}

using Application.Dtos;
using Application.Interfaces;
using Application.UseCases.Interfaces;
using Domain;

namespace Application.UseCases.Modules
{
    public class InventoryModule
    {
        private readonly IClientModule _clientModule;
        private readonly IBookModule _bookModule;
        private readonly IInventoryPersistence _inventoryPersistence;

        public InventoryModule(IClientModule clientModule, IBookModule bookModule, IInventoryPersistence inventoryPersistence)
        {
            _clientModule = clientModule;
            _bookModule = bookModule;
            _inventoryPersistence = inventoryPersistence;
        }

        public async Task Create(InventoryDto iventoryDto)
        {
            var inventory = new Inventory(iventoryDto.Quantity, iventoryDto.BookId.Value);

            await _inventoryPersistence.Create(inventory);
        }

        public async Task CheckIn(CheckOutDto checkOutDto)
        {
            var client = await _clientModule.GetById(checkOutDto.ClientId);
            var book = await _bookModule.GetByCode(checkOutDto.BookCode);

            if (client != null && _bookModule.Response.Type is Dtos.ResponseType.Success)
            {
                var checkout = new CheckOut(client.Id, book.Id, checkOutDto.Quantity); ;

                var inventory = await _inventoryPersistence.GetByBookId(book.Id);

                inventory?.CheckIn(checkout.Quantity);
            }
        }

        public async Task CheckOut(CheckOutDto checkOutDto)
        {
            var client = await _clientModule.GetById(checkOutDto.ClientId);
            var book = await _bookModule.GetByCode(checkOutDto.BookCode);

            if (client != null && _bookModule.Response.Type is Dtos.ResponseType.Success)
            {
                var checkout = new CheckOut(client.Id, book.Id, checkOutDto.Quantity); ;

                var inventory = await _inventoryPersistence.GetByBookId(book.Id);

                inventory?.CheckOut(checkout.Quantity);
            }
        }
    }
}

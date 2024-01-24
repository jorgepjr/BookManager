using Application.Dtos;
using Application.Interfaces;
using Application.UseCases.Interfaces;
using Domain;

namespace Application.UseCases
{
    public class CheckOutBook
    {
        private readonly IClientModule _clientModule;
        private readonly IBookModule _bookModule;
        private readonly IInventoryPersistence inventoryPersistence;
        public CheckOutBook(IClientModule clientModule, IBookModule bookModule, IInventoryPersistence inventoryPersistence)
        {
            _clientModule = clientModule;
            _bookModule = bookModule;
            this.inventoryPersistence = inventoryPersistence;
        }

        public async Task Execute(CheckOutDto checkOutDto)
        {
            var client = await _clientModule.GetById(checkOutDto.ClientId);
            var book = await _bookModule.GetByCode(checkOutDto.BookCode);

            if (client != null && _bookModule.Response.Type is Dtos.ResponseType.Success)
            {
                var checkout = new CheckOut(client.Id, book.Id, checkOutDto.Quantity); ;

                var inventory = await inventoryPersistence.GetByBookId(book.Id);
                
               inventory?.EmprestarLivro(checkout.Quantity);
            }
        }
    }
}

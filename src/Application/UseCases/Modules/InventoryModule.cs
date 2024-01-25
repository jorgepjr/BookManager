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
            if (!iventoryDto.BookId.HasValue)
            {
                throw new Exception($"{iventoryDto.BookId} invalid");
            }

            var book = await _bookModule.GetById(iventoryDto.BookId.Value);

            var inventory = new Inventory(iventoryDto.Quantity, book.Id);
            await _inventoryPersistence.Create(inventory);
        }

        public async Task CheckIn(LoanDto LoanDto)
        {
            var client = await _clientModule.GetById(LoanDto.ClientId);
            var book = await _bookModule.GetByCode(LoanDto.BookCode);

            if (client != null && _bookModule.Response.Type is Dtos.ResponseType.Success)
            {
                var Loan = new Loan(client.Id, book.Id, LoanDto.Quantity); ;

                var inventory = await _inventoryPersistence.GetByBookId(book.Id);

                if (inventory != null && Loan.Quantity <= inventory.Quantity)
                {
                    inventory?.CheckIn(Loan.Quantity);
                    await _inventoryPersistence.Update(inventory);
                }
            }
        }

        public async Task Loan(LoanDto LoanDto)
        {
            var client = await _clientModule.GetById(LoanDto.ClientId);
            var book = await _bookModule.GetByCode(LoanDto.BookCode);

            if (client != null && _bookModule.Response.Type is Dtos.ResponseType.Success)
            {
                var loan = new Loan(client.Id, book.Id, LoanDto.Quantity); ;

                var inventory = await _inventoryPersistence.GetByBookId(book.Id);

                if (inventory != null && inventory.Quantity >= loan.Quantity)
                {
                    inventory?.CheckOut(loan.Quantity);
                    await _inventoryPersistence.Update(inventory);
                }
            }
        }
    }
}

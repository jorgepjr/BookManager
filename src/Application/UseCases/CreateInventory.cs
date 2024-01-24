using Application.Dtos;
using Application.Interfaces;
using Domain;

namespace Application.UseCases
{
    public class CreateInventory
    {
        private readonly IInventoryPersistence _inventoryPersistence;

        public CreateInventory(IInventoryPersistence inventoryPersistence)
        {
            _inventoryPersistence = inventoryPersistence;
        }

        public async Task Execute(InventoryDto iventoryDto)
        {
            var inventory = new Inventory(iventoryDto.Quantity, iventoryDto.BookId.Value);

            await _inventoryPersistence.Create(inventory);
        }
    }
}

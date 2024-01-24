using Application.Dtos;
using Application.Interfaces;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/inventory/")]
    public class InventoryController : Controller
    {
        private readonly CreateInventory _createInventory;

        public InventoryController(IInventoryPersistence inventoryPersistence)
        {
            _createInventory = new CreateInventory(inventoryPersistence);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] InventoryDto inventoryDto)
        {
            await _createInventory.Execute(inventoryDto);
            return Ok();
        }
    }
}

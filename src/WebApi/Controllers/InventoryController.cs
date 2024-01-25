using Application.Dtos;
using Application.Interfaces;
using Application.UseCases.Interfaces;
using Application.UseCases.Modules;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/inventory/")]
    public class InventoryController : Controller
    {
        private readonly InventoryModule _inventoryModule;

        public InventoryController(IClientModule clientModule, IBookModule bookModule, IInventoryPersistence inventoryPersistence)
        {
            _inventoryModule = new InventoryModule(clientModule, bookModule, inventoryPersistence);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] InventoryDto inventoryDto)
        {
            await _inventoryModule.Create(inventoryDto);
            return Ok();
        }

        [HttpPost("checkOut")]
        public async Task<IActionResult> Post([FromBody] CheckOutDto checkOutDto)
        {
            await _inventoryModule.CheckOut(checkOutDto);
            return Ok();
        }

        [HttpPatch("checkIn")]
        public async Task<IActionResult> Patch([FromBody] CheckOutDto checkOutDto)
        {
            await _inventoryModule.CheckIn(checkOutDto);
            return Ok();
        }
    }
}

using Application.Dtos;
using Application.Interfaces;
using Application.UseCases;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/books/")]
    public class BooksController : Controller
    {
        private readonly IBookModule _bookModule;
        private readonly CheckOutBook _checkoutBook;

        public BooksController(IClientModule clientModule, IBookModule bookModule, IInventoryPersistence inventoryPersistence)
        {
            _bookModule = bookModule;
            _checkoutBook = new CheckOutBook(clientModule, bookModule, inventoryPersistence);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _bookModule.Create(bookDto);

            if (_bookModule.Response.Type is ResponseType.Error)
            {
                return BadRequest(_bookModule.Response.Message);
            }

            return Ok(new { response.Id, response.Code, message = _bookModule.Response.Message });
        }

        [HttpGet("getByCode/{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var bookResponse = await _bookModule.GetByCode(code);

            if (_bookModule.Response.Type is ResponseType.Error)
            {
                return BadRequest(_bookModule.Response.Message);
            }

            return Ok(new { bookResponse, _bookModule.Response });
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Get(int page, int itemByPage)
        {
            var booksResponse = await _bookModule.Filter(page, itemByPage);
            return Ok(booksResponse);
        }

        [HttpPost("retun")]
        public async Task<IActionResult> Post([FromBody] CheckOutDto checkOutDto)
        {
            await _checkoutBook.Execute(checkOutDto);
            return Ok();
        }

        [HttpPatch("checkout")]
        public async Task<IActionResult> Patch([FromBody] CheckOutDto checkOutDto)
        {
            await _checkoutBook.Execute(checkOutDto);
            return Ok();
        }
    }
}

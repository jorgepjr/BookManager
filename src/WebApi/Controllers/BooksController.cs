using Application.Dtos;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookModule _bookModule;
        public BooksController(IBookModule bookModule)
        {
            _bookModule = bookModule;
        }

        [HttpPost("/Create")]
        public async Task<IActionResult> Post([FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest(ModelState);
            }

           await _bookModule.Create(bookDto);

            if(_bookModule.Response.Type == ResponseType.Error)
            {
                return BadRequest(_bookModule.Response.Message);
            }

            return Ok(_bookModule.Response.Message);
        }
    }
}

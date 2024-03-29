﻿using Application.Dtos;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/books/")]
    public class BooksController : Controller
    {
        private readonly IBookModule _bookModule;

        public BooksController(IBookModule bookModule)
        {
            _bookModule = bookModule;
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

            return Ok(bookResponse);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Get(int page, int itemByPage)
        {
            var booksResponse = await _bookModule.Filter(page, itemByPage);
            return Ok(booksResponse);
        }
    }
}

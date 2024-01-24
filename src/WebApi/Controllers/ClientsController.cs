using Application.Dtos;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/clients/")]
    public class ClientsController : Controller
    {
        private readonly IClientModule _clientModule;
        public ClientsController(IClientModule clientModule)
        {
            _clientModule = clientModule;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientId = await _clientModule.Create(clientDto);

            if (_clientModule.Response.Type is ResponseType.Error)
            {
                return BadRequest(_clientModule.Response.Message);
            }

            return Ok(new { clientId });
        }

        [HttpGet("getById/{clientId}")]
        public async Task<IActionResult> Get(Guid clientId)
        {
            var response = await _clientModule.GetById(clientId);
            return Ok(response);
        }
    }
}

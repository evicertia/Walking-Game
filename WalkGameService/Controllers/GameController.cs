using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalkGameService.Application.UsesCases;

namespace WalkGameService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<InfoPlayerResponse>> GetGameStatus()
        {
            GameStatusRequest request = new();
            GameStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<NewGameResponse>> NewGame([FromBody] NewGameRequest request)
        {
            NewGameResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
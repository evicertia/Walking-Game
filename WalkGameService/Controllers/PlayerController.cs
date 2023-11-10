using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WalkGameService.Application.UsesCases;
using WalkGameService.Domain;

namespace WalkGameService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AddPlayerResponse>> AddPlayer([FromBody] AddPlayerRequest request)
        {
            AddPlayerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<DeletePlayerResponse>> DeletePlayer([FromBody] DeletePlayerRequest request)
        {
            DeletePlayerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<InfoPlayerResponse>> InfoPlayer(string username)
        {
            InfoPlayerRequest request = new(username);
            InfoPlayerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch("{username}")]
        public async Task<ActionResult<MovPlayerResponse>> Patch(string username, [FromBody] JsonPatchDocument<Player> playerPatch)
        {
            MovPlayerRequest request = new(username, playerPatch);
            MovPlayerResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
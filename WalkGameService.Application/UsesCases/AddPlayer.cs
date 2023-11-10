using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkGameService.Domain;

namespace WalkGameService.Application.UsesCases
{
    public record AddPlayerResponse(Position Position);
    public record AddPlayerRequest(string Username) : IRequest<AddPlayerResponse>;
    public class AddPlayerHandler : IRequestHandler<AddPlayerRequest, AddPlayerResponse>
    {

        private readonly ILogger<AddPlayerHandler> _logger;
        private readonly IMapService _map;

        public AddPlayerHandler(ILogger<AddPlayerHandler> logger, IMapService map)
        {
            _logger = logger;
            _map = map;
        }

        public Task<AddPlayerResponse> Handle(AddPlayerRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request for a new player {request.Username}");
            Player player = new(request.Username);
            Position position = _map.AddPlayer(player);

            _logger.LogInformation($"New player {request.Username} created in position {player.Position}");
            return Task.FromResult(new AddPlayerResponse(position));
        }
    }
}

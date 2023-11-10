using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using WalkGameService.Domain;
using WalkGameService.Domain.Exceptions;

namespace WalkGameService.Application.UsesCases
{
    public record MovPlayerResponse(Position position);
    public record MovPlayerRequest(string Username, JsonPatchDocument<Player> JsonPacthDocument) : IRequest<MovPlayerResponse>;
    public class MovPlayerHandler : IRequestHandler<MovPlayerRequest, MovPlayerResponse>
    {

        private readonly ILogger<MovPlayerHandler> _logger;
        private readonly IMapService _map;

        public MovPlayerHandler(ILogger<MovPlayerHandler> logger, IMapService map)
        {
            _logger = logger;
            _map = map;
        }

        public Task<MovPlayerResponse> Handle(MovPlayerRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request for a move player {request.Username}");
            Player player = _map.GetPlayer(request.Username) ?? throw new PlayerNotExistException();

            // Clone for not modify the original object
            Player playerUpdated = (Player)player.Clone();
            request.JsonPacthDocument.ApplyTo(playerUpdated);

            Position position = _map.MovPlayer(playerUpdated) ?? throw new PositionException();

            _logger.LogInformation($"New position {player.Position} for player {request.Username}");

            return Task.FromResult(new MovPlayerResponse(position));
        }
    }
}

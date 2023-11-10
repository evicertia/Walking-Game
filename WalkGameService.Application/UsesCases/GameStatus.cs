using MediatR;
using Microsoft.Extensions.Logging;
using WalkGameService.Domain;

namespace WalkGameService.Application.UsesCases
{
    public record GameStatusResponse(int currentPlayers, IEnumerable<Player> Players);
    public record GameStatusRequest() : IRequest<GameStatusResponse>;
    public class GameStatusHandler : IRequestHandler<GameStatusRequest, GameStatusResponse>
    {

        private readonly ILogger<GameStatusHandler> _logger;
        private readonly IMapService _map;

        public GameStatusHandler(ILogger<GameStatusHandler> logger, IMapService map)
        {
            _logger = logger;
            _map = map;
        }

        public Task<GameStatusResponse> Handle(GameStatusRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request for game status");
            IEnumerable<Player> players = _map.GetPlayers();

            GameStatusResponse status = new(players.Count(), players);
            _logger.LogInformation($"Current players: {status.currentPlayers}");
            return Task.FromResult(status);
        }
    }
}

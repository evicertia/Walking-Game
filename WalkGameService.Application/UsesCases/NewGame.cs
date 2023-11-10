using MediatR;
using Microsoft.Extensions.Logging;
using WalkGameService.Domain;

namespace WalkGameService.Application.UsesCases
{
    public record NewGameResponse(string message);
    public record NewGameRequest(int width, int height) : IRequest<NewGameResponse>;
    public class NewGameHandler : IRequestHandler<NewGameRequest, NewGameResponse>
    {

        private readonly ILogger<NewGameHandler> _logger;
        private readonly IMapService _map;

        public NewGameHandler(ILogger<NewGameHandler> logger, IMapService map)
        {
            _logger = logger;
            _map = map;
        }

        public Task<NewGameResponse> Handle(NewGameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request for a new game ({request.width}x{request.height})");

            if (request.width < 1 || request.height < 1)
                throw new InvalidOperationException("Invalid map size. Widht and height should be bigger than 0.");

            _map.NewGame(request.width, request.height);

            _logger.LogInformation($"New game ({request.width}x{request.height}) was created.");

            return Task.FromResult(new NewGameResponse($"New game was created ({request.width}x{request.height})."));
        }


    }
}

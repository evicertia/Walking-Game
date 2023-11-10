using MediatR;
using Microsoft.Extensions.Logging;
using WalkGameService.Domain;
using WalkGameService.Domain.Exceptions;

namespace WalkGameService.Application.UsesCases
{
    public record DeletePlayerResponse(string message);
    public record DeletePlayerRequest(string Username) : IRequest<DeletePlayerResponse>;
    public class DeletePlayerHandler : IRequestHandler<DeletePlayerRequest, DeletePlayerResponse>
    {

        private readonly ILogger<DeletePlayerHandler> _logger;
        private readonly IMapService _map;

        public DeletePlayerHandler(ILogger<DeletePlayerHandler> logger, IMapService map)
        {
            _logger = logger;
            _map = map;
        }

        public Task<DeletePlayerResponse> Handle(DeletePlayerRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request for delete player {request.Username}");
            bool result = _map.DeletePlayer(request.Username);
            if (!result)
                throw new PlayerNotExistException();

            _logger.LogInformation($"Player {request.Username} was deteled.");
            return Task.FromResult(new DeletePlayerResponse($"Player {request.Username} was deleted."));
            
        }
    }
}

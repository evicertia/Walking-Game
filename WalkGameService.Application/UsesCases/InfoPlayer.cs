using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkGameService.Domain;
using WalkGameService.Domain.Exceptions;

namespace WalkGameService.Application.UsesCases
{
    public record InfoPlayerResponse(Player Player);
    public record InfoPlayerRequest(string Username) : IRequest<InfoPlayerResponse>;
    public class InfoPlayerHandler : IRequestHandler<InfoPlayerRequest, InfoPlayerResponse>
    {

        private readonly ILogger<InfoPlayerHandler> _logger;
        private readonly IMapService _map;

        public InfoPlayerHandler(ILogger<InfoPlayerHandler> logger, IMapService map)
        {
            _logger = logger;
            _map = map;
        }

        public Task<InfoPlayerResponse> Handle(InfoPlayerRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request for info player {request.Username}");
            Player player = _map.GetPlayer(request.Username) ?? throw new PlayerNotExistException();

            return Task.FromResult(new InfoPlayerResponse(player));
        }
    }
}

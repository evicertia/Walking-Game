using WalkGameService.Domain;
using WalkGameService.Domain.Exceptions;

namespace WalkGameService.Infrastructure
{
    public class MapService : IMapService
    {
        private IMap? _map = null;

        public void NewGame(int width, int height)
        {
            _map = new MapDictionary(0, 0, width - 1, height - 1);
        }

        public Position AddPlayer(Player player)
        {
            if (_map == null) throw new GameNotStartedException();
            return _map.AddPlayer(player);
        }

        public bool DeletePlayer(string username)
        {
            if (_map == null) throw new GameNotStartedException();
            return _map.DeletePlayer(username);
        }

        public Player? GetPlayer(string username)
        {
            if (_map == null) throw new GameNotStartedException();
            return _map.GetPlayer(username);
        }

        public IEnumerable<Player> GetPlayers()
        {
            if (_map == null) throw new GameNotStartedException();
            return _map.GetPlayers();
        }

        public Position? MovPlayer(Player player)
        {
            if (_map == null) throw new GameNotStartedException();
            return _map.MovPlayer(player);
        }
    }
}
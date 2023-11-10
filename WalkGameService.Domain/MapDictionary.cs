using System.Collections.Concurrent;
using WalkGameService.Domain.Exceptions;

namespace WalkGameService.Domain
{
    public class MapDictionary : IMap
    {
        private readonly int _maxTop = 0;
        private readonly int _maxLeft = 0;
        private readonly int _maxRight = 2;
        private readonly int _maxBottom = 2;

        public MapDictionary(int maxTop, int maxLeft, int maxRight, int maxBottom)
        {
            _maxTop = maxTop;
            _maxLeft = maxLeft;
            _maxRight = maxRight;
            _maxBottom = maxBottom;
        }

        private ConcurrentDictionary<string, Player> _map = new();

        public Position AddPlayer(Player player)
        {
            if (CheckIfUserExist(player)) throw new UsernameInUseException();

            Position position = GetNewPosition();
            player.SetPosition(position);
            _map.GetOrAdd(player.Username, player);
            return position;
        }

        private bool CheckIfUserExist(Player player)
        {
            _map.TryGetValue(player.Username, out Player? playerInGame);
            return playerInGame != null;
        }

        public bool DeletePlayer(string username)
        {
            _map.Remove(username, out Player? player);
            return player != null;
        }

        public Player? GetPlayer(string username)
        {
            _map.TryGetValue(username, out Player? player);
            return player;
        }

        public Position? MovPlayer(Player player)
        {
            if (!CanPlayerMoveToPosition(player))
                throw new PositionException();

            _map.TryGetValue(player.Username, out Player? currentPlayer);
            if (currentPlayer == null) throw new PlayerNotExistException();

            player.SetPosition(player.Position!);
            _map.TryUpdate(player.Username, player, currentPlayer);

            return player.Position;
        }

        public bool CanPlayerMoveToPosition(Player player)
        {

            //isNextTo
            _map.TryGetValue(player.Username, out Player? currentPlayer);
            if (currentPlayer == null) throw new PlayerNotExistException();


            if (!currentPlayer.CanMoveTo(player.Position!))
                return false;


            if (!IsValidPosition(player.Position)) return false;


            return true;
        }

        public bool IsValidPosition(Position? position)
        {
            if (position == null) return false;

            //out of range
            if (position.Row < _maxTop || position.Row > _maxBottom) return false;
            if (position.Column > _maxRight || position.Column < _maxLeft) return false;

            //is fill
            if (_map.Values.Where(m => m.Position == position).Any()) return false;

            return true;
        }

        public Position GetNewPosition()
        {
            List<Position> emptyPositions = GetEmptyPositions();
            if (emptyPositions.Count == 0)
                throw new MapFullException();

            Random random = new();
            int index = random.Next(0, emptyPositions.Count);

            return emptyPositions[index];
        }

        public List<Position> GetEmptyPositions()
        {
            List<Position> positions = new List<Position>();
            for (int row = _maxLeft; row <= _maxRight; row++)
            {
                for (int col = _maxLeft; col <= _maxRight; col++)
                {
                    Position position = new Position(row, col);
                    if (IsValidPosition(position))
                        positions.Add(position);
                }
            }

            return positions;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _map.Values;
        }
    }
}

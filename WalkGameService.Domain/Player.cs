using WalkGameService.Domain.Exceptions;

namespace WalkGameService.Domain
{
    public class Player : ICloneable
    {
        public Player(string username)
        {
            Username = username;
        }

        private List<Position> _positions { get; set; } = new();
        public IEnumerable<Position> Positions => _positions;
        public Position? Position { get; set; } = null;

        public string Username { get; }

        public void SetPosition(Position position)
        {
            _positions.Add(position);
            Position = position;
        }

        public bool CanMoveTo(Position position)
        {
            if (Position == null) return false;
            return Position!.CanMoveTo(position); 
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
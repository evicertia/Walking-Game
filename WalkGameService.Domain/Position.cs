namespace WalkGameService.Domain
{
    public class Position
    {
        public Position() : this(0, 0)
        {
        }
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }

        public bool CanMoveTo(Position position)
        {
            List<Position> valids = GetPaths();

            return valids.Contains(position);
        }

        public List<Position> GetPaths()
        {
            return new List<Position>()
            {
                new Position(Row-1, Column),
                new Position(Row+1, Column),
                new Position(Row, Column-1),
                new Position(Row, Column+1),
            };
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override string? ToString()
        {
            return $"[{Row},{Column}]";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Position? left, Position? right)
        {
            return EqualityComparer<Position>.Default.Equals(left!, right!);
        }
        public static bool operator !=(Position? left, Position? right)
        {
            return !(left == right);
        }
    }
}
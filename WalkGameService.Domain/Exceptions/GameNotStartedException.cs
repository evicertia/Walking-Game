namespace WalkGameService.Domain.Exceptions
{
    public class GameNotStartedException : Exception
    {
        public GameNotStartedException() : this("Game not started")
        {
        }

        public GameNotStartedException(string? message) : base(message)
        {
        }

        public GameNotStartedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

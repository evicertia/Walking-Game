using System.Runtime.Serialization;

namespace WalkGameService.Domain.Exceptions
{
    [Serializable]
    public class PlayerNotExistException : Exception
    {
        public PlayerNotExistException() : this("Player not exist")
        {
        }

        public PlayerNotExistException(string? message) : base(message)
        {
        }

        public PlayerNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PlayerNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
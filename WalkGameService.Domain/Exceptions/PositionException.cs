using System.Runtime.Serialization;

namespace WalkGameService.Domain.Exceptions
{
    [Serializable]
    public class PositionException : Exception
    {
        public PositionException() : this("Invalid position")
        {
        }

        public PositionException(string? message) : base(message)
        {
        }

        public PositionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
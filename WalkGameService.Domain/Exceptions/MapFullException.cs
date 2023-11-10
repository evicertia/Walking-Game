using System.Runtime.Serialization;

namespace WalkGameService.Domain.Exceptions
{
    [Serializable]
    internal class MapFullException : Exception
    {
        public MapFullException() : this("Map is full")
        {
        }

        public MapFullException(string? message) : base(message)
        {
        }

        public MapFullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MapFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
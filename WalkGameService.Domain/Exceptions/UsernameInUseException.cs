using System.Runtime.Serialization;

namespace WalkGameService.Domain.Exceptions
{
    [Serializable]
    internal class UsernameInUseException : Exception
    {
        public UsernameInUseException()
        {
        }

        public UsernameInUseException(string? message) : base(message)
        {
        }

        public UsernameInUseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsernameInUseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
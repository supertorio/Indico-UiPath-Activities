using System;
using System.Runtime.Serialization;

namespace Indico.Tools
{
    class IndicoAPIException : Exception
    {
        public IndicoAPIException()
        { }

        public IndicoAPIException(string message) : base(message)
        { }

        public IndicoAPIException(string message, Exception inner) : base(message, inner)
        { }

        public IndicoAPIException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
        { }
    }
}

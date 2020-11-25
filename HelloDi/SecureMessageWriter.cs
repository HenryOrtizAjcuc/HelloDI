using System;
using System.Security.Principal;

namespace HelloDi
{
    // Implements the IMessageWriter interface while also consuming it.
    public class SecureMessageWriter : IMessageWriter
    {
        private readonly IMessageWriter writer;
        private readonly IIdentity identity;


        // Constructor injection that request an instance of IMessageWriter.
        public SecureMessageWriter(IMessageWriter writer, IIdentity identity)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            this.writer = writer;
            this.identity = identity;

        }
        public void Write(string message)
        {
            // Verifies wheteher the user is authenticated.
            if (identity.IsAuthenticated)
            {
                // If authenticated, writes the message 
                // using the injected message writer.
                writer.Write(message);
            }
        }
    }
}

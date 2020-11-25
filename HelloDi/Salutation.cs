using System;

namespace HelloDi
{
    public class Salutation
    {
        private readonly IMessageWriter writer;

        // Provides the salutation class with the IMessageWriter Dependency
        // using constructor injection
        public Salutation(IMessageWriter writer)
        {

            // Guard Clause verifies that the supplied IMessageWriter isn't null.
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            this.writer = writer;
        }

        public void Exclaim()
        {
            // Sends the Hello DI! message to the IMessageWriter Dependency
            this.writer.Write("Hello DI");
        }
    }
}

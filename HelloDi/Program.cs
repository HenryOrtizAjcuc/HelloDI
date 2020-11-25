using System.Security.Principal;

namespace HelloDi
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageWriter writer = new SecureMessageWriter(new ConsoleMessageWriter(),
                                                            WindowsIdentity.GetCurrent());
            var salutation = new Salutation(writer);
            salutation.Exclaim();
        }
    }
}

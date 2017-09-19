using Ninject;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Ninject;

namespace Traveller
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            // Singleton design pattern
            // Ensures that there is only one instance of Engine in existance
            // Yo are already familiar with it, right?

            IKernel kernel = new StandardKernel(new Module());
            var engine = kernel.Get<IEngine>();

            engine.Start();
        }
    }
}

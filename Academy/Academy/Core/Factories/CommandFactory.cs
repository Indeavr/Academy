using Academy.Commands.Contracts;
using Ninject;

namespace Academy.Core.Factories
{
    class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand CreateCommand(string commandName)
        {
            ICommand command = this.kernel.Get<ICommand>(commandName);

            return command;
        }
    }
}

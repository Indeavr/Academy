using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public abstract class Command : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IDatabase database;

        public Command(ITravellerFactory factory, IDatabase database)
        {
            this.factory = factory;
            this.database = database;
        }
        protected ITravellerFactory Factory
        {
            get
            {
                return this.factory;
            }
        }
        protected IDatabase Database
        {
            get
            {
                return this.database;
            }
        }
        public abstract string Execute(IList<string> parameters);
    }
}

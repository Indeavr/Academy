using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public abstract class CreateVehicleCommand : Command,ICommand
    {       
        public CreateVehicleCommand(ITravellerFactory factory, IDatabase database)
            :base(factory,database)
        {
           
        }
       
        public override string Execute(IList<string> parameters)
        {
            return $"Vehicle with ID {base.Database.Vehicles.Count - 1} was created.";
        }
    }
}

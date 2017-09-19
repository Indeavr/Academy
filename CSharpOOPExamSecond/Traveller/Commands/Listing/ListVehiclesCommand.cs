using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    // TODO
    public class ListVehiclesCommand : Command, ICommand
    {     
        public ListVehiclesCommand(ITravellerFactory factory, IDatabase database)
            :base(factory,database)
        {
            
        }

        public  override string Execute(IList<string> parameters)
        {
            var vehicles = this.Database.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, 
                vehicles);
        }
    }
}

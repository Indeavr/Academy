using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand :CreateVehicleCommand, ICommand
    {       
        public CreateBusCommand(ITravellerFactory factory, IDatabase database)
            :base(factory,database)
        {
            
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = this.Factory.CreateBus(passengerCapacity, pricePerKilometer);
            this.Database.Vehicles.Add(bus);

             return base.Execute(parameters);
        }

    }
}

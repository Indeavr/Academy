using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateAirplaneCommand : CreateVehicleCommand, ICommand
    {
        public CreateAirplaneCommand(ITravellerFactory factory, IDatabase database):
            base(factory,database)
        {
            
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            bool hasFreeFood;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = Boolean.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var plane = this.Factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            this.Database.Vehicles.Add(plane);

            return base.Execute(parameters);
        }
    }
}

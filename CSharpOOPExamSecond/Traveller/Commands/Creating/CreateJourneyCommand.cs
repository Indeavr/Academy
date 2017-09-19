using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateJourneyCommand : Command, ICommand
    {

        public CreateJourneyCommand(ITravellerFactory factory, IDatabase database)
            : base(factory, database)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                vehicle = this.Database.Vehicles[int.Parse(parameters[3])];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }

            var journey = this.Factory.CreateJourney(startLocation, destination, distance, vehicle);
            this.Database.Journeys.Add(journey);

            return $"Journey with ID {Database.Journeys.Count - 1} was created.";
        }

    }
}

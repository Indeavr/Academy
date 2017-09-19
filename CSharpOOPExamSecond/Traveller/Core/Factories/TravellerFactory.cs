using Traveller.Core.Contracts;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Models.Vehicles.Models;

namespace Traveller.Core.Factories
{
    public class TravellerFactory : ITravellerFactory
    {
        public IVehicle CreateBus(int passengerCapacity, decimal pricePerKilometer)
        {
            return new Bus(passengerCapacity, pricePerKilometer);
        }

        public IVehicle CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood)
        {
            return new Airplane(passengerCapacity, pricePerKilometer,hasFreeFood);
        }

        public IVehicle CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts)
        {
            return new Train(passengerCapacity, pricePerKilometer,carts);
        }
        
        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            return new Journey(destination, distance, startLocation, vehicle);
        }

        public ITicket CreateTicket(IJourney journey, decimal administrativeCosts)
        {
            return new Ticket(administrativeCosts, journey);
        }
    }
}

using Traveller.Models.Vehicles.Models;

namespace Traveller.Models.Vehicles.Contracts
{
    public interface IVehicle
    {       
        VehicleType Type { get; }
        decimal PricePerKilometer { get; }
        int PassangerCapacity { get; }
    }
}
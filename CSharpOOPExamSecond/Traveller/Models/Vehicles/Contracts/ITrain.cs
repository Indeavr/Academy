using Traveller.Models.Vehicles.Models;

namespace Traveller.Models.Vehicles.Contracts
{
    public interface ITrain : IVehicle
    {
        
        // Please, please, please implement me
        VehicleType Type { get;}

        int Carts { get; }
    }
}
using System;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Vehicles.Models
{
    public class Airplane : Vehicle, IVehicle, IAirplane
    {
        private bool hasFreeFood;

        public Airplane(int passangerCapacity, decimal pricePerKilometer,bool hasFreeFood)
            :base(passangerCapacity,pricePerKilometer)
        {
            this.Type = VehicleType.Air;
            this.HasFreeFood = hasFreeFood;
            
        }
        public bool HasFreeFood
        {
            get
            {
                return this.hasFreeFood;
            }
            private set
            {
                this.hasFreeFood = value;
            }
        }

        public override string AdditionalInformation()
        {
            return Environment.NewLine + $"Has free food: {this.HasFreeFood}";
        }
        public override string ToString()
        {
            return string.Concat("Airplane", base.ToString());
        }
    }
}

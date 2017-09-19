using System;
using Traveller.Models.Vehicles.Contracts;
namespace Traveller.Models.Vehicles.Models
{
    public class Bus: Vehicle, IVehicle, IBus
    {
        public Bus(int passangerCapacity, decimal pricePerKilometer)
            :base(passangerCapacity,pricePerKilometer)
        {
            this.Type = VehicleType.Land;
        }
        public override int PassangerCapacity
        {
            get
            {
                return base.PassangerCapacity;
            }

            set
            {
                if (value < 10 || value > 50)
                {
                    throw new ArgumentOutOfRangeException("A bus cannot have less than 10 passengers or more than 50 passengers.");
                }
                base.PassangerCapacity = value;
            }
        }

        public override string AdditionalInformation()
        {
            return string.Empty;
        }
        public override string ToString()
        {
            return string.Concat("Bus",base.ToString());
        }
    }
}

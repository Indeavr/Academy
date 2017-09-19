using System;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Vehicles.Models
{
    public class Train : Vehicle, IVehicle, ITrain
    {
        private int carts;
        public Train(int passangerCapacity, decimal pricePerKilometer,int carts)
            :base(passangerCapacity,pricePerKilometer)
        {
            this.Type = VehicleType.Land;
            this.Carts = carts;
        }
        public int Carts
        {
            get
            {
                return this.carts;
            }
            private set
            {
                if (value > 15 || value < 1)
                {
                    throw new ArgumentOutOfRangeException("A train cannot have less than 1 cart or more than 15 carts.");
                }
                    this.carts = value;
            }
        }

        public override int PassangerCapacity
        {
            get
            {               
                return base.PassangerCapacity;
            }
            set
            {
                if (value < 30 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("A train cannot have less than 30 passengers or more than 150 passengers.");
                }
                base.PassangerCapacity=value;
            }
        }

        public override string AdditionalInformation()
        {
            return Environment.NewLine + $"Carts amount: {this.Carts}";
        }
        public override string ToString()
        {
            return string.Concat("Train", base.ToString());
        }
    }
}

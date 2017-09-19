using System;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private int passangerCapacity;
        private decimal pricePerKilometer;
        private VehicleType type;

        public Vehicle(int passangerCapacity, decimal pricePerKilometer)
        {
            this.PassangerCapacity = passangerCapacity;
            this.PricePerKilometer = pricePerKilometer;
        }
        public virtual int PassangerCapacity
        {
            get
            {
                return this.passangerCapacity;
            }
            set
            {
                if (value < 1 || value > 800)
                {
                    throw new ArgumentOutOfRangeException("A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");
                }
                this.passangerCapacity = value;
            }
        }

        public virtual decimal PricePerKilometer
        {
            get
            {
                return this.pricePerKilometer;
            }
            private set
            {
                if (value < 0.10m || value > 2.50m)
                {
                    throw new ArgumentOutOfRangeException("A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!");
                }
                this.pricePerKilometer = value;
            }
        }
        public abstract string AdditionalInformation();
        public virtual VehicleType Type
        {
            get
            {
                return this.type;
            }
            protected set
            {
                this.type = value;
            }
        }
        public override string ToString()
        {
            return string.Concat(
                $" ----",
                Environment.NewLine,
                $"Passenger capacity: {this.PassangerCapacity}",
                Environment.NewLine,
                $"Price per kilometer: {this.PricePerKilometer}",
                Environment.NewLine,
                $"Vehicle type: {this.Type}",
                this.AdditionalInformation());
        }
    }
}

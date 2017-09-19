using System;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Vehicles.Models
{
    public class Journey : IJourney
    {
        private string destination;
        private int distance;
        private string startLocation;
        private IVehicle vehicle;

        public Journey(string destination, int distance, string startLocation, IVehicle vehicle)
        {
            this.Destination = destination;
            this.Distance = distance;
            this.StartLocation = startLocation;
            this.Vehicle = vehicle;
        }
        public string Destination
        {
            get
            {
                return this.destination;
            }
            private set
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("The Destination's length cannot be less than 5 or more than 25 symbols long.");
                }
                this.destination = value;
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            private set
            {
                if (value < 5 || value > 5000)
                {
                    throw new ArgumentOutOfRangeException("The Distance cannot be less than 5 or more than 5000 kilometers.");
                }
                this.distance = value;
            }
        }

        public string StartLocation
        {
            get
            {
                return this.startLocation;
            }
            private set
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("The StartingLocation's length cannot be less than 5 or more than 25 symbols long.");
                }
                this.startLocation = value;
            }

        }

        public IVehicle Vehicle
        {
            get
            {
                return this.vehicle;
            }
            private set
            {
                this.vehicle = value;
            }
        }

        public decimal CalculateTravelCosts()
        {
            return this.Distance * this.Vehicle.PricePerKilometer;
        }
        public override string ToString()
        {
            return string.Concat("Journey ----",
                Environment.NewLine,
                $"Start location: { this.StartLocation}",
                Environment.NewLine,
                $"Destination: {this.Destination}",
                Environment.NewLine,
                $"Distance: {this.Distance}",
                Environment.NewLine,
                $"Vehicle type: {this.Vehicle.Type}",
                Environment.NewLine,
                $"Travel costs: {this.CalculateTravelCosts()}");
        }
    }
}

using System;
using Traveller.Models.Contracts;

namespace Traveller.Models.Vehicles.Models
{
    public class Ticket : ITicket
    {
        private decimal administrativeCosts;
        private IJourney journey;
        public Ticket(decimal administrativeCosts,IJourney journey)
        {
            this.AdministrativeCosts = administrativeCosts;
            this.Journey = journey;
        }
        public decimal AdministrativeCosts
        {
            get
            {
                return this.administrativeCosts;
            }
            private set
            {
                this.administrativeCosts = value;
            }
        }

        public IJourney Journey
        {
            get
            {
                return this.journey;
            }
            private set
            {
                this.journey = value;
            }

        }

        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts + this.Journey.CalculateTravelCosts();
        }
        public override string ToString()
        {
            return string.Concat("Ticket ----",
                Environment.NewLine,
                $"Destination: {this.Journey.Destination}",
                Environment.NewLine,
                $"Price: {this.CalculatePrice()}");
        }
    }
}

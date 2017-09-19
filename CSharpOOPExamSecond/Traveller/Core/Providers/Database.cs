using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Core.Providers
{
    public class Database : IDatabase
    {
        private readonly IList<IVehicle> vehicles;

        private readonly IList<IJourney> journeys;

        private readonly IList<ITicket> tickets;

        public Database()
        {
            this.vehicles = new List<IVehicle>();
            this.journeys = new List<IJourney>();
            this.tickets = new List<ITicket>();
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public IList<IJourney> Journeys
        {
            get
            {
                return this.journeys;
            }
        }

        public IList<ITicket> Tickets
        {
            get
            {
                return this.tickets;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Core.Contracts
{
    public interface IDatabase
    {
        IList<IVehicle> Vehicles { get; }

        IList<IJourney> Journeys { get; }

        IList<ITicket> Tickets { get; }
    }
}

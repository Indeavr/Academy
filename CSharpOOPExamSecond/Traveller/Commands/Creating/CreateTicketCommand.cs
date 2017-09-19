using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Models.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : Command, ICommand
    {
       
        public CreateTicketCommand(ITravellerFactory factory, IDatabase database)
            :base(factory,database)
        {           
        }

        public override string Execute(IList<string> parameters)
        {
            decimal administrativeCosts;
            IJourney journey;
            
            try
            {
                journey=this.Database.Journeys[int.Parse(parameters[0])];      
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this.Factory.CreateTicket(journey,administrativeCosts);
            this.Database.Tickets.Add(ticket);

            return $"Ticket with ID {Database.Tickets.Count - 1} was created.";
        }
    }
}

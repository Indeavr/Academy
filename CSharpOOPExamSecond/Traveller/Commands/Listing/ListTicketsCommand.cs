using System;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : Command, ICommand
    {
      
        public ListTicketsCommand(ITravellerFactory factory, IDatabase database)
            :base(factory,database)
        {
           
        }

        public override string Execute(IList<string> parameters)
        {
            var tickets = this.Database.Tickets;

            if (tickets.Count == 0)
            {
                return "There are no registered tickets.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}

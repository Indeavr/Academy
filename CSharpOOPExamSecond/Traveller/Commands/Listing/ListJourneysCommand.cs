﻿using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : Command, ICommand
    {
       
        public ListJourneysCommand(ITravellerFactory factory, IDatabase database)
            :base(factory,database)
        {
           
        }

        public override string Execute(IList<string> parameters)
        {
            var journeys = this.Database.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}

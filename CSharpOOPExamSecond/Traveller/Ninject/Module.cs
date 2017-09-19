using Ninject.Modules;
using System;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;
using Traveller.Core;
using Traveller.Core.Factories;
using Traveller.Core.Providers;
using Traveller.Commands.Creating;
using Traveller.Commands.Contracts;

namespace Traveller.Ninject
{
    class Module : NinjectModule
    {
        private const string createAirplane = "createairplane";
        private const string createBus = "createbus";
        private const string createJourney = "createjourney";
        private const string createTicket = "createticket";
        private const string createTrain = "createtrain";
        private const string createVehicle = "createvehicle";

        private const string listJourneys = "listjourneys";
        private const string listTickets = "listtickets";
        private const string listVehicles = "listvehicles";

        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<ITravellerFactory>().To<TravellerFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IDatabase>().To<Database>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>();

            //creating
            this.Bind<ICommand>().To<CreateAirplaneCommand>().Named(createAirplane);
            this.Bind<ICommand>().To<CreateBusCommand>().Named(createBus);
            this.Bind<ICommand>().To<CreateJourneyCommand>().Named(createJourney);
            this.Bind<ICommand>().To<CreateTicketCommand>().Named(createTicket);
            this.Bind<ICommand>().To<CreateTrainCommand>().Named(createTrain);
            this.Bind<ICommand>().To<CreateVehicleCommand>().Named(createVehicle);

            //listing
            this.Bind<ICommand>().To<ListJourneysCommand>().Named(listJourneys);
            this.Bind<ICommand>().To<ListTicketsCommand>().Named(listTickets);
            this.Bind<ICommand>().To<ListVehiclesCommand>().Named(listVehicles);

        }
    }
}

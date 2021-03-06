﻿using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Traveller.Core.Providers
{
    public class CommandParser : IParser
    {
        private readonly ICommandFactory factory;

        public CommandParser(ICommandFactory factory)
        {
            this.factory = factory;
        }

        // Magic, do not touch!
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];

            //var commandTypeInfo = this.FindCommand(commandName);
            //var command = Activator.CreateInstance(commandTypeInfo, TravellerFactory.Instance, Engine.Instance) as ICommand;
            var command = this.factory.CreateCommand(commandName);

            return command;
        }

        // Magic, do not touch!
        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }

        // Very magic, do not even think about touching!!!
        //private TypeInfo FindCommand(string commandName)
        //{
        //    Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
        //    var commandTypeInfo = currentAssembly.DefinedTypes
        //        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
        //        .Where(type => type.Name.ToLower() == (commandName.ToLower() + "command"))
        //        .SingleOrDefault();

        //    if (commandTypeInfo == null)
        //    {
        //        throw new ArgumentException("The passed command is not found!");
        //    }

        //    return commandTypeInfo;
        //}
    }
}

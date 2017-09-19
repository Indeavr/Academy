using Academy.Commands.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Decorators
{
    class DateCommandDecorator : ICommand
    {
        private readonly ICommand command;

        public DateCommandDecorator(ICommand command)
        {
            Guard.WhenArgument(command, "command").IsNull().Throw();

            this.command = command;
        }

        public string Execute(IList<string> parameters)
        {
            return command.Execute(parameters) + Environment.NewLine +
                $"Command is called at {DateTime.Now}!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

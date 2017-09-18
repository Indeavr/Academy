using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Contracts
{
    public interface IEngine
    {
        IDatabase Database { get; }

        void Start();
    }
}

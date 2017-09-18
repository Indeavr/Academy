using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Contracts
{
    public interface IDatabase
    {
        IList<ISeason> Seasons { get; set; }

        IList<IStudent> Students { get; set; }

        IList<ITrainer> Trainers { get; set; }
    }
}

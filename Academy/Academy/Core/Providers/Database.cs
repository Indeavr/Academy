using Academy.Core.Contracts;
using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Providers
{
    public class Database : IDatabase
    {
        private IList<ISeason> seasons;

        private IList<IStudent> students;

        private IList<ITrainer> trainers;

        public Database()
        {
            this.seasons = new List<ISeason>();
            this.students = new List<IStudent>();
            this.trainers = new List<ITrainer>();
        }

        public IList<ISeason> Seasons
        {
            get
            {
                return this.seasons;
            }
            set
            {
                this.seasons = value;
            }
        }

        public IList<IStudent> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public IList<ITrainer> Trainers
        {
            get
            {
                return this.trainers;
            }
            set
            {
                this.trainers = value;
            }
        }
    }
}

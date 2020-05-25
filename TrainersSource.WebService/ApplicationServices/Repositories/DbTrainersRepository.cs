using TrainersSource.ApplicationServices.Ports.Gateways.Database;
using TrainersSource.DomainObjects;
using TrainersSource.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrainersSource.ApplicationServices.Repositories
{
    public class DbTrainersRepository : IReadOnlyTrainersRepository,
                                     ITrainersRepository
    {
        private readonly ITrainersDatabaseGateway _databaseGateway;

        public DbTrainersRepository(ITrainersDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<Trainers> GetTrainers(long id)
            => await _databaseGateway.GetTrainers(id);

        public async Task<IEnumerable<Trainers>> GetAllTrainerss()
            => await _databaseGateway.GetAllTrainerss();

        public async Task<IEnumerable<Trainers>> QueryTrainerss(ICriteria<Trainers> criteria)
            => await _databaseGateway.QueryTrainerss(criteria.Filter);

        public async Task AddTrainers(Trainers trainers)
            => await _databaseGateway.AddTrainers(trainers);

        public async Task RemoveTrainers(Trainers trainers)
            => await _databaseGateway.RemoveTrainers(trainers);

        public async Task UpdateTrainers(Trainers trainers)
            => await _databaseGateway.UpdateTrainers(trainers);
    }
}

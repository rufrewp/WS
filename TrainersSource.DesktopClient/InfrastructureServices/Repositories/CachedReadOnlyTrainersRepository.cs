using TrainersSource.ApplicationServices.Ports.Cache;
using TrainersSource.DomainObjects;
using TrainersSource.DomainObjects.Ports;
using TrainersSource.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainersSource.InfrastructureServices.Repositories
{
    public class CachedReadOnlyTrainersRepository : ReadOnlyTrainersRepositoryDecorator
    {
        private readonly IDomainObjectsCache<Trainers> _trainerssCache;

        public CachedReadOnlyTrainersRepository(IReadOnlyTrainersRepository trainersRepository, 
                                             IDomainObjectsCache<Trainers> trainerssCache)
            : base(trainersRepository)
            => _trainerssCache = trainerssCache;

        public async override Task<Trainers> GetTrainers(long id)
            => _trainerssCache.GetObject(id) ?? await base.GetTrainers(id);

        public async override Task<IEnumerable<Trainers>> GetAllTrainerss()
            => _trainerssCache.GetObjects() ?? await base.GetAllTrainerss();

        public async override Task<IEnumerable<Trainers>> QueryTrainerss(ICriteria<Trainers> criteria)
            => _trainerssCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryTrainerss(criteria);

    }
}

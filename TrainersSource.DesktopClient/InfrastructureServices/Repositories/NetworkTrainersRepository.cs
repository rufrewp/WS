using TrainersSource.ApplicationServices.Ports.Cache;
using TrainersSource.DomainObjects;
using TrainersSource.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrainersSource.InfrastructureServices.Repositories
{
    public class NetworkTrainersRepository : NetworkRepositoryBase, IReadOnlyTrainersRepository
    {
        private readonly IDomainObjectsCache<Trainers> _trainersCache;

        public NetworkTrainersRepository(string host, ushort port, bool useTls, IDomainObjectsCache<Trainers> trainersCache)
            : base(host, port, useTls)
            => _trainersCache = trainersCache;

        public async Task<Trainers> GetTrainers(long id)
            => CacheAndReturn(await ExecuteHttpRequest<Trainers>($"trainerss/{id}"));

        public async Task<IEnumerable<Trainers>> GetAllTrainerss()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Trainers>>($"trainerss"), allObjects: true);

        public async Task<IEnumerable<Trainers>> QueryTrainerss(ICriteria<Trainers> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Trainers>>($"trainerss"), allObjects: true)
               .Where(criteria.Filter.Compile());


        private IEnumerable<Trainers> CacheAndReturn(IEnumerable<Trainers> trainerss, bool allObjects = false)
        {
            if (allObjects)
            {
                _trainersCache.ClearCache();
            }
            _trainersCache.UpdateObjects(trainerss, DateTime.Now.AddDays(1), allObjects);
            return trainerss;
        }

        private Trainers CacheAndReturn(Trainers trainers)
        {
            _trainersCache.UpdateObject(trainers, DateTime.Now.AddDays(1));
            return trainers;
        }
    }
}

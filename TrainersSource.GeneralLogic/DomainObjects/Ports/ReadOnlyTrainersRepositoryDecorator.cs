using TrainersSource.DomainObjects;
using TrainersSource.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainersSource.DomainObjects.Repositories
{
    public abstract class ReadOnlyTrainersRepositoryDecorator : IReadOnlyTrainersRepository
    {
        private readonly IReadOnlyTrainersRepository _trainersRepository;

        public ReadOnlyTrainersRepositoryDecorator(IReadOnlyTrainersRepository trainersRepository)
        {
            _trainersRepository = trainersRepository;
        }

        public virtual async Task<IEnumerable<Trainers>> GetAllTrainerss()
        {
            return await _trainersRepository?.GetAllTrainerss();
        }

        public virtual async Task<Trainers> GetTrainers(long id)
        {
            return await _trainersRepository?.GetTrainers(id);
        }

        public virtual async Task<IEnumerable<Trainers>> QueryTrainerss(ICriteria<Trainers> criteria)
        {
            return await _trainersRepository?.QueryTrainerss(criteria);
        }
    }
}

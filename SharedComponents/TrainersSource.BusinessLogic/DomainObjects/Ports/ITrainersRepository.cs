using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TrainersSource.DomainObjects.Ports
{
    public interface IReadOnlyTrainersRepository
    {
        Task<Trainers> GetTrainers(long id);

        Task<IEnumerable<Trainers>> GetAllTrainerss();

        Task<IEnumerable<Trainers>> QueryTrainerss(ICriteria<Trainers> criteria);

    }

    public interface ITrainersRepository
    {
        Task AddTrainers(Trainers trainers);

        Task RemoveTrainers(Trainers trainers);

        Task UpdateTrainers(Trainers trainers);
    }
}

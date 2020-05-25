using TrainersSource.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainersSource.ApplicationServices.Ports.Gateways.Database
{
    public interface ITrainersDatabaseGateway
    {
        Task AddTrainers(Trainers trainers);

        Task RemoveTrainers(Trainers trainers);

        Task UpdateTrainers(Trainers trainers);

        Task<Trainers> GetTrainers(long id);

        Task<IEnumerable<Trainers>> GetAllTrainerss();

        Task<IEnumerable<Trainers>> QueryTrainerss(Expression<Func<Trainers, bool>> filter);

    }
}

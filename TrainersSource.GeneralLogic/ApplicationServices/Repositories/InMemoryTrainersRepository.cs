using TrainersSource.DomainObjects;
using TrainersSource.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainersSource.ApplicationServices.Repositories
{
    public class InMemoryTrainersRepository : IReadOnlyTrainersRepository,
                                           ITrainersRepository
    {
        private readonly List<Trainers> _trainerss = new List<Trainers>();

        public InMemoryTrainersRepository(IEnumerable<Trainers> trainerss = null)
        {
            if (trainerss != null)
            {
                _trainerss.AddRange(trainerss);
            }
        }

        public Task AddTrainers(Trainers trainers)
        {
            _trainerss.Add(trainers);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Trainers>> GetAllTrainerss()
        {
            return Task.FromResult(_trainerss.AsEnumerable());
        }

        public Task<Trainers> GetTrainers(long id)
        {
            return Task.FromResult(_trainerss.Where(Tr =>Tr.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Trainers>> QueryTrainerss(ICriteria<Trainers> criteria)
        {
            return Task.FromResult(_trainerss.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveTrainers(Trainers trainers)
        {
            _trainerss.Remove(trainers);
            return Task.CompletedTask;
        }

        public Task UpdateTrainers(Trainers trainers)
        {
            var foundTrainers = GetTrainers(trainers.Id).Result;
            if (foundTrainers == null)
            {
                AddTrainers(trainers);
            }
            else
            {
                if (foundTrainers != trainers)
                {
                    _trainerss.Remove(foundTrainers);
                    _trainerss.Add(trainers);
                }
            }
            return Task.CompletedTask;
        }
    }
}

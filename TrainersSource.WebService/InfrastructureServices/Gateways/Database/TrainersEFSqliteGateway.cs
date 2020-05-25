using TrainersSource.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TrainersSource.ApplicationServices.Ports.Gateways.Database;

namespace TrainersSource.InfrastructureServices.Gateways.Database
{
    public class TrainersEFSqliteGateway : ITrainersDatabaseGateway
    {
        private readonly TrainersContext _trainersContext;

        public TrainersEFSqliteGateway(TrainersContext TrainersContext)
            => _trainersContext = TrainersContext;

        public async Task<Trainers> GetTrainers(long id)
           => await _trainersContext.Trainerss.Where(Tr => Tr.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Trainers>> GetAllTrainerss()
            => await _trainersContext.Trainerss.ToListAsync();

        public async Task<IEnumerable<Trainers>> QueryTrainerss(Expression<Func<Trainers, bool>> filter)
            => await _trainersContext.Trainerss.Where(filter).ToListAsync();

        public async Task AddTrainers(Trainers trainers)
        {
            _trainersContext.Trainerss.Add(trainers);
            await _trainersContext.SaveChangesAsync();
        }

        public async Task UpdateTrainers(Trainers trainers)
        {
            _trainersContext.Entry(trainers).State = EntityState.Modified;
            await _trainersContext.SaveChangesAsync();
        }

        public async Task RemoveTrainers(Trainers trainers)
        {
            _trainersContext.Trainerss.Remove(trainers);
            await _trainersContext.SaveChangesAsync();
        }

    }
}

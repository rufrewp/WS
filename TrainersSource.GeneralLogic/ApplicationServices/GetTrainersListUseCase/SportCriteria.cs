using TrainersSource.DomainObjects;
using TrainersSource.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TrainersSource.ApplicationServices.GetTrainersListUseCase
{
    public class SportCriteria : ICriteria<Trainers>
    {
        public string Sport { get; }

        public SportCriteria(string sport)
            => Sport = sport;

        public Expression<Func<Trainers, bool>> Filter
            => (Tr => Tr.Sport == Sport);
    }
}

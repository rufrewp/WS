using TrainersSource.DomainObjects;
using TrainersSource.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainersSource.ApplicationServices.GetTrainersListUseCase
{
    public class GetTrainersListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Trainers> Trainerss { get; }

        public GetTrainersListUseCaseResponse(IEnumerable<Trainers> trainerss) => Trainerss = trainerss;
    }
}

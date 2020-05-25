using System;
using System.Collections.Generic;
using System.Text;
using TrainersSource.ApplicationServices.Interfaces;

namespace TrainersSource.ApplicationServices.GetTrainersListUseCase
{
    public interface IGetTrainersListUseCase : IUseCase<GetTrainersListUseCaseRequest, GetTrainersListUseCaseResponse>
    {
    }
}

using TrainersSource.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainersSource.ApplicationServices.GetTrainersListUseCase
{
    public class GetTrainersListUseCaseRequest : IUseCaseRequest<GetTrainersListUseCaseResponse>
    {
        public string Sport { get; private set; }
        public long? TrainersId { get; private set; }

        private GetTrainersListUseCaseRequest()
        { }

        public static GetTrainersListUseCaseRequest CreateAllTrainerssRequest()
        {
            return new GetTrainersListUseCaseRequest();
        }

        public static GetTrainersListUseCaseRequest CreateTrainersRequest(long trainersId)
        {
            return new GetTrainersListUseCaseRequest() { TrainersId = trainersId };
        }
        public static GetTrainersListUseCaseRequest CreateSportTrainerssRequest(string sport)
        {
            return new GetTrainersListUseCaseRequest() { Sport = sport };
        }
    }
}

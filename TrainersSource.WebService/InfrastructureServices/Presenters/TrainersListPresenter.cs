using TrainersSource.ApplicationServices.GetTrainersListUseCase;
using System.Net;
using Newtonsoft.Json;
using TrainersSource.ApplicationServices.Ports;

namespace TrainersSource.InfrastructureServices.Presenters
{
    public class TrainersListPresenter : IOutputPort<GetTrainersListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public TrainersListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetTrainersListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Trainerss) : JsonConvert.SerializeObject(response.Message);
        }
    }
}

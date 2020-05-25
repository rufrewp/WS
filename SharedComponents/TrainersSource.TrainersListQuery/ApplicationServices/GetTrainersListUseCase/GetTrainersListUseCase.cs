using System.Threading.Tasks;
using System.Collections.Generic;
using TrainersSource.DomainObjects;
using TrainersSource.DomainObjects.Ports;
using TrainersSource.ApplicationServices.Ports;

namespace TrainersSource.ApplicationServices.GetTrainersListUseCase
{
    public class GetTrainersListUseCase : IGetTrainersListUseCase
    {
        private readonly IReadOnlyTrainersRepository _readOnlyTrainersRepository;

        public GetTrainersListUseCase(IReadOnlyTrainersRepository readOnlyTrainersRepository)
            => _readOnlyTrainersRepository = readOnlyTrainersRepository;

        public async Task<bool> Handle(GetTrainersListUseCaseRequest request, IOutputPort<GetTrainersListUseCaseResponse> outputPort)
        {
            IEnumerable<Trainers> trainerss = null;
            if (request.TrainersId != null)
            {
                var trainers = await _readOnlyTrainersRepository.GetTrainers(request.TrainersId.Value);
                trainerss = (trainers != null) ? new List<Trainers>() { trainers } : new List<Trainers>();

            }
            else if (request.Sport != null)
            {
                trainerss = await _readOnlyTrainersRepository.QueryTrainerss(new SportCriteria(request.Sport));
            }
            else
            {
                trainerss = await _readOnlyTrainersRepository.GetAllTrainerss();
            }
            outputPort.Handle(new GetTrainersListUseCaseResponse(trainerss));
            return true;
        }
    }
}

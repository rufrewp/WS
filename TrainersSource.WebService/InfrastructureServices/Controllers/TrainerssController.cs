using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainersSource.DomainObjects;
using TrainersSource.ApplicationServices.GetTrainersListUseCase;
using TrainersSource.InfrastructureServices.Presenters;

namespace TrainersSource.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainerssController : ControllerBase
    {
        private readonly ILogger<TrainerssController> _logger;
        private readonly IGetTrainersListUseCase _getTrainersListUseCase;

        public TrainerssController(ILogger<TrainerssController> logger,
                                IGetTrainersListUseCase getTrainersListUseCase)
        {
            _logger = logger;
            _getTrainersListUseCase = getTrainersListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTrainerss()
        {
            var presenter = new TrainersListPresenter();
            await _getTrainersListUseCase.Handle(GetTrainersListUseCaseRequest.CreateAllTrainerssRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{trainersId}")]
        public async Task<ActionResult> GetTrainers(long trainersId)
        {
            var presenter = new TrainersListPresenter();
            await _getTrainersListUseCase.Handle(GetTrainersListUseCaseRequest.CreateTrainersRequest(trainersId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("sport/{sport}")]
        public async Task<ActionResult> GetSportTrainerss(string sport)
        {
            var presenter = new TrainersListPresenter();
            await _getTrainersListUseCase.Handle(GetTrainersListUseCaseRequest.CreateSportTrainerssRequest(sport), presenter);
            return presenter.ContentResult;
        }
    }
}

using TrainersSource.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using TrainersSource.ApplicationServices.GetTrainersListUseCase;
using System.Linq.Expressions;
using TrainersSource.ApplicationServices.Ports;
using TrainersSource.DomainObjects.Ports;
using TrainersSource.ApplicationServices.Repositories;

namespace TrainersSource.WebService.Core.Tests
{
    public class GetTrainersListUseCaseTest
    {
        private InMemoryTrainersRepository CreateTrainerstRepository()
        {

            var repo = new InMemoryTrainersRepository(new List<Trainers> {
                new Trainers { Id = 1, Surname = "Абызова", Name = "Надежда", Patronymic = "Викторовна",Gender = "женский",Birthday = "19.01.1973",Sport = "Большой спорт"},
                new Trainers { Id = 2, Surname = "Алешина", Name = "Лариса", Patronymic = "Владимировна",Gender = "женский",Birthday = "01.02.1960",Sport = "Большой спорт"},
                new Trainers { Id = 3, Surname = "Андрюхин", Name = "Алексей", Patronymic = "Михайлович",Gender = "мужской",Birthday = "21.11.1973",Sport = "Спортивный резерв"},
                new Trainers { Id = 4,Surname = "Ануров", Name = "Александр", Patronymic = "Львович",Gender = "мужской",Birthday = "10.11.1957",Sport = "Большой спорт"}

    });
            return repo;
        }

        [Fact]
        public void TestGetAllTrainerss()
        {
            var useCase = new GetTrainersListUseCase(CreateTrainerstRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetTrainersListUseCaseRequest.CreateAllTrainerssRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.Trainerss.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.Trainerss.Select(Tr => Tr.Id));
        }

        [Fact]
        public void TestGetAllTrainerssFromEmptyRepository()
        {
            var useCase = new GetTrainersListUseCase(new InMemoryTrainersRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetTrainersListUseCaseRequest.CreateAllTrainerssRequest(), outputPort).Result);
            Assert.Empty(outputPort.Trainerss);
        }

        [Fact]
        public void TestGetTrainers()
        {
            var useCase = new GetTrainersListUseCase(CreateTrainerstRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetTrainersListUseCaseRequest.CreateTrainersRequest(2), outputPort).Result);
            Assert.Single(outputPort.Trainerss, Tr => 2 == Tr.Id);
        }

        [Fact]
        public void TestTryGetNotExistingTrainers()
        {
            var useCase = new GetTrainersListUseCase(CreateTrainerstRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetTrainersListUseCaseRequest.CreateTrainersRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Trainerss);
        }




    }

    class OutputPort : IOutputPort<GetTrainersListUseCaseResponse>
    {
        public IEnumerable<Trainers> Trainerss { get; private set; }

        public void Handle(GetTrainersListUseCaseResponse response)
        {
            Trainerss = response.Trainerss;
        }
    }
}

using TrainersSource.ApplicationServices.GetTrainersListUseCase;
using TrainersSource.ApplicationServices.Ports;
using TrainersSource.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace TrainersSource.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetTrainersListUseCase _getTrainersListUseCase;

        public MainViewModel(IGetTrainersListUseCase getTrainersListUseCase)
            => _getTrainersListUseCase = getTrainersListUseCase;

        private Task<bool> _loadingTask;
        private Trainers _currentTrainers;
        private ObservableCollection<Trainers> _trainerss;

        public event PropertyChangedEventHandler PropertyChanged;

        public Trainers CurrentTrainers
        {
            get => _currentTrainers; 
            set
            {
                if (_currentTrainers != value)
                {
                    _currentTrainers = value;
                    OnPropertyChanged(nameof(CurrentTrainers));
                }
            }
        }

        private async Task<bool> LoadTrainerss()
        {
            var outputPort = new OutputPort();
            bool result = await _getTrainersListUseCase.Handle(GetTrainersListUseCaseRequest.CreateAllTrainerssRequest(), outputPort);
            if (result)
            {
                Trainerss = new ObservableCollection<Trainers>(outputPort.Trainerss);
            }
            return result;
        }

        public ObservableCollection<Trainers> Trainerss
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadTrainerss();
                }
                
                return _trainerss; 
            }
            set
            {
                if (_trainerss != value)
                {
                    _trainerss = value;
                    OnPropertyChanged(nameof(Trainerss));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetTrainersListUseCaseResponse>
        {
            public IEnumerable<Trainers> Trainerss { get; private set; }

            public void Handle(GetTrainersListUseCaseResponse response)
            {
                if (response.Success)
                {
                    Trainerss = new ObservableCollection<Trainers>(response.Trainerss);
                }
            }
        }
    }
}

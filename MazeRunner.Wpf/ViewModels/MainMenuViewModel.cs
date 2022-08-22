using MazeRunner.Wpf.Commands;
using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MazeRunner.Wpf.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ICommand PlayCommand { get; }

        public ICommand LoadGameCommand { get; }

        public ICommand ExitGameCommand { get; }

        private bool _isScoreUpdated;

        public bool IsScoreUpdated
        {
            get => _isScoreUpdated; set
            {
                _isScoreUpdated = value;
                OnPropertyChanged(nameof(IsScoreUpdated));
            }
        }

        private int _totalScore;

        public int TotalScore
        {
            get => _totalScore; set
            {
                _totalScore = value;
                OnPropertyChanged(nameof(TotalScore));
            }
        }

        public MainMenuViewModel(NavigationStore navigationStore, GameObject gameObjectLocation, bool isScoreUpdated, int totalScore)
        {
            PlayCommand = new PlayCommand(navigationStore, gameObjectLocation);
            LoadGameCommand = new LoadGameCommand(navigationStore, gameObjectLocation);
            ExitGameCommand = new ExitGameCommand();
            this._isScoreUpdated = isScoreUpdated;
            _totalScore = totalScore;
        }
    }
}

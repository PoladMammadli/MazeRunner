using MazeRunner.Wpf.Commands;
using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.Stores;
using MazeRunnerr.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;

namespace MazeRunner.Wpf.ViewModels
{
    public class GameAreaViewModel : ViewModelBase
    {
        public GameAreaViewModel(GameObject gameObjectLocation, ObservableCollection<ObjectPositionViewModel> gameObject, NavigationStore navigationStore, int point, int gameSize)
        {
            _point = point;
            _gameSize = gameSize;
            this._gameObjectLocation = gameObjectLocation;
            this._gameObjects = gameObject;
            RightCommand = new MoveCommand(this, gameObjectLocation, Direction.RightArrow);
            LeftCommand = new MoveCommand(this, gameObjectLocation, Direction.LeftArrow);
            DownCommand = new MoveCommand(this, gameObjectLocation, Direction.DownArrow);
            UpCommand = new MoveCommand(this, gameObjectLocation, Direction.UpArrow);
            SaveCommand = new SaveGameCommand(navigationStore, gameObjectLocation);
        }

        private readonly GameObject _gameObjectLocation;
        public GameObject GameObjectLocation { get => _gameObjectLocation; }

        private ObservableCollection<ObjectPositionViewModel> _gameObjects;
        public ObservableCollection<ObjectPositionViewModel> GameObjects
        {
            get => _gameObjects; set
            {
                _gameObjects = value;
                OnPropertyChanged(nameof(GameObjects));
            }
        }

        private int _point;

        public int Point
        {
            get => _point;
            set
            {
                _point = value;
                OnPropertyChanged(nameof(Point));
            }
        }
        
        private int _gameSize;

        public int ColumnCount
        {
            get => _gameSize; set
            {
                _gameSize = value;
                OnPropertyChanged(nameof(ColumnCount));
            }
        }

        public int RowCount
        {
            get => _gameSize; set
            {
                _gameSize = value;
                OnPropertyChanged(nameof(RowCount));
            }
        }

        public ICommand RightCommand { get; }
        public ICommand LeftCommand { get; }
        public ICommand UpCommand { get; }
        public ICommand DownCommand { get; }
        public ICommand SaveCommand { get; }
    }
}

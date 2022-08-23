using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.ViewModels;
using MazeRunnerr.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;

namespace MazeRunner.Wpf.Commands
{
    public class MoveCommand : CommandBase
    {
        private readonly GameAreaViewModel _gameAreaViewModel;
        private readonly GameObject _gameObject;
        private readonly Direction _direction;
        public MoveCommand(GameAreaViewModel gameAreaViewModel, GameObject gameObject, Direction direction)
        {
            this._gameAreaViewModel = gameAreaViewModel;
            this._gameObject = gameObject;
            _direction = direction;
        }

        public override void Execute(object parameter)
        {
            _gameObject.playTimer.Start();
            _gameObject.PlayerDirection = _direction;
            _gameObject.Play();
            _gameAreaViewModel.Point = _gameObject.playerSpawn.Point;
        }
    }
}

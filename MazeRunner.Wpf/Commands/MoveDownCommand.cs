using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.ViewModels;
using MazeRunnerr.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;
using System.Windows.Threading;

namespace MazeRunner.Wpf.Commands
{
    public class MoveDownCommand : CommandBase
    {
        private readonly GameAreaViewModel _gameAreaViewModel;
        private readonly GameObject _gameObject;

        public MoveDownCommand(GameAreaViewModel gameAreaViewModel, GameObject gameObject)
        {
            this._gameAreaViewModel = gameAreaViewModel;
            this._gameObject = gameObject;
        }

        public override void Execute(object parameter)
        {
            _gameObject.playTimer.Start();
            _gameObject.PlayerDirection = Direction.DownArrow;
            //_gameObject.UpdateObjects(_gameAreaViewModel.GameObject);
            _gameObject.Play();
            _gameAreaViewModel.Point = _gameObject.playerSpawn.Point;
        }
    }
}

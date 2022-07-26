﻿using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.SetTimer;
using MazeRunner.Wpf.Stores;
using MazeRunner.Wpf.ViewModels;
using MazeRunnerr.GameStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace MazeRunner.Wpf.Commands
{
    public class StartCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly GameObject _gameObject;
        private readonly NewGameViewModel _newGameVM;
        private GameTimer _gameTimer;

        public StartCommand(NavigationStore navigationStore, GameObject gameObject, NewGameViewModel newGameVM)
        {
            this._navigationStore = navigationStore;
            this._gameObject = gameObject;
            this._newGameVM = newGameVM;
        }

        public override void Execute(object parameter)
        {
            if (int.TryParse(_newGameVM.GameSize, out var gameSize))
            {
                if (gameSize < 10)
                {
                    MessageBox.Show("Size must be greater than 10");
                    return;
                }

                this._gameObject.size = gameSize;
                
                _gameObject.GenerateGameobjects();
                _gameObject.Start();

                var updatedObjects = _gameObject.GetUpdatableObjects();

                var objects = new ObservableCollection<ObjectPositionViewModel>();

                foreach (var updatedObject in updatedObjects)
                {
                    objects.Add(updatedObject);
                }

                _gameTimer = new GameTimer(_gameObject, objects);
                _gameTimer.SetPlayTimer();
                _gameTimer.SetUpdateTimer();
                
                GameState.Clear();
                _navigationStore.CurrentViewModel = new GameAreaViewModel(_gameObject, objects, _navigationStore, 0, gameSize);
            }
            else
            {
                MessageBox.Show("Invalid input.");
                return;
            }
        }
    }
}

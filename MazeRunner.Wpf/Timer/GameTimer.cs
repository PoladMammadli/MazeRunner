using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Threading;

namespace MazeRunner.Wpf.SetTimer
{
    public class GameTimer
    {
        private readonly GameObject _gameObject;
        private readonly ObservableCollection<ObjectPositionViewModel> _objects;

        public GameTimer(GameObject gameObject, ObservableCollection<ObjectPositionViewModel> objects)
        {
            this._gameObject = gameObject;
            this._objects = objects;
        }

        public void SetPlayTimer()
        {
            _gameObject.playTimer = new DispatcherTimer();
            _gameObject.playTimer.Tick += Play;
            _gameObject.playTimer.Interval = TimeSpan.FromMilliseconds(200);
        }

        private void Play(object sender, EventArgs e)
        {
            _gameObject.MoveOnlyEnemy();
        }

        public void SetUpdateTimer()
        {
            _gameObject.updateTimer = new DispatcherTimer();
            _gameObject.updateTimer.Tick += Update;
            _gameObject.updateTimer.Interval = TimeSpan.FromMilliseconds(20);
            _gameObject.updateTimer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            _gameObject.UpdateObjects(_objects);
        }
    }
}

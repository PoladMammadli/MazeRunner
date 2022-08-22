using MazeRunner.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunner.Wpf.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            { 
                _currentViewModel = value; 
                OnCurrentViewModelChanged();
            }
            
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }


        public event Action CurrentViewModelChanged;
    }
}

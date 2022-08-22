using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.Stores;
using MazeRunner.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MazeRunner.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly GameObject _gameObject;

        public App()
        {
            _navigationStore = new NavigationStore();
            _gameObject = new GameObject(_navigationStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, _gameObject, false, 0);
            
            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();
            
            base.OnStartup(e);
        }

    }
}

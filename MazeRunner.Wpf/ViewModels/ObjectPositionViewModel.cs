using MazeRunner.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;

namespace MazeRunner.Wpf.ViewModels
{
    public class ObjectPositionViewModel : ViewModelBase
    {
        private int _column;
        private int _row;
        private Brush _fill;

        public int Column
        {
            get => _column; set
            {
                _column = value;
                OnPropertyChanged(nameof(Column));
            }
        }
        public Brush Fill
        {
            get => _fill;
            set
            {
                _fill = value;
                OnPropertyChanged(nameof(_fill));
            }
        }
        public int Row
        {
            get => _row;
            set
            {
                _row = value;
                OnPropertyChanged(nameof(Row));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunner.Wpf.ViewModels
{
    public class GameSizeViewModel : ViewModelBase
    {
        private int _columnCount;
        private int _rowCount;

        public int ColumnCount
        {
            get => _columnCount; set
            {
                _columnCount = value;
                OnPropertyChanged(nameof(ColumnCount));
            }
        }

        public int RowCount
        {
            get => _rowCount; set
            {
                _rowCount = value;
                OnPropertyChanged(nameof(RowCount));
            }
        }
    }
}

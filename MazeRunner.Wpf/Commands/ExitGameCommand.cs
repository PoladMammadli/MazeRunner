using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunner.Wpf.Commands
{
    public class ExitGameCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

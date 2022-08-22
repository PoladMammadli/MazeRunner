using MazeRunnerr.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.GameCoins
{
    public class GameCoin : IGameCoin
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ObjectColor Color => ObjectColor.Cyan;
    }
}

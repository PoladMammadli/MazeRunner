using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface IPlayerWallSpawnManager : ISpawnManager
    {
        public List<IGameWall> GameWalls { get; }
        public IPlayer Player { get; }
        public int Size { get; }
    }
}

using MazeRunnerr.GameWallObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface IWallSpawnManager : ISpawnManager
    {
        public List<IGameWall> GameWalls { get; }
        public int Size { get; }

    }
}

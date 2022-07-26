﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface ISpawnManager
    {
        bool CheckSpawn();
        void ChangePosition();
        void UpdatePosition();
    }
}

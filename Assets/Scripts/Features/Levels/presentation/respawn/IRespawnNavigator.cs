using System;
using UnityEngine;

namespace Features.Levels.presentation.respawn
{
    public interface IRespawnNavigator
    {
        void RespawnPlayer(bool resetSpawn = false);
        void RespawnPlayerAtPoint(Transform spawnPoint, bool resetLook = false);

        public Action OnRespawn
        {
            get;
            set;
        }
    }
}
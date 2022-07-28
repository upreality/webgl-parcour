using System;
using UnityEngine;

namespace Features.Levels.presentation.respawn
{
    public interface IRespawnNavigator
    {
        void RespawnPlayer();
        void RespawnPlayerAtPoint(Transform spawnPoint);
        public Action OnRespawn
        {
            get;
            set;
        }
    }
}
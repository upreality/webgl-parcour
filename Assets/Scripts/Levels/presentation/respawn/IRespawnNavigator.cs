using System;

namespace Levels.presentation.respawn
{
    public interface IRespawnNavigator
    {
        void Respawn();
        public Action OnRespawn
        {
            get;
            set;
        }
    }
}
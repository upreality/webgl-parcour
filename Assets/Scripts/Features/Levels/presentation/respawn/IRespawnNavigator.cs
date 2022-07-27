using System;

namespace Features.Levels.presentation.respawn
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
using Zenject;

namespace Gameplay.Death
{
    public class DeathNavigator
    {
        [Inject] private DeathUseCase deathUseCase;

        public void handleDeath()
        {
            
        }
    }
}
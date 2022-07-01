using Doozy.Engine;
using UnityEngine;
using Zenject;

namespace Gameplay.Death
{
    public class DeathFallTrigger: MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float fallHeight;
        [Inject] private DeathNavigator deathNavigator;
        
        private bool fallen;
        
        private void Update()
        {
            if (target.position.y <= fallHeight == fallen)
                return;

            fallen = !fallen;
            if (fallen)
                deathNavigator.handleDeath();
        }
    }
}
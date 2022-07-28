using Features.Interaction.presentation;
using UnityEngine;
using Zenject;

namespace Features.Respawn.presentation
{
    public class LevelSpawnInteractable : BaseInteractable
    {
        [SerializeField] private AnimatedSpawn spawn;
        [Inject] private SpawnNavigator spawnNavigator;

        protected override void Interaction()
        {
            base.Interaction();
            spawnNavigator.UpdateSpawn(spawn);
        }
    }
}
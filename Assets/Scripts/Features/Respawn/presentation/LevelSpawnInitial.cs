using UnityEngine;
using Zenject;

namespace Features.Respawn.presentation
{
    public class LevelSpawnInitial : MonoBehaviour
    {
        [SerializeField] private AnimatedSpawn spawn;
        [Inject] private SpawnNavigator spawnNavigator;

        private void Start() => spawnNavigator.UpdateSpawn(spawn);
    }
}
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Features.Respawn.presentation.Spawns
{
    public class SpawnNavigator : MonoBehaviour
    {
        [SerializeField] private Transform spawnMarker;
        [SerializeField] private Transform defaultSpawnPoint;
        [CanBeNull] private ISpawn currentSpawn = null;

        public void ActivateSpawnPoint(Action<Transform> onSpawnPointActivated)
        {
            currentSpawn?.Activate();
            onSpawnPointActivated(currentSpawn?.GetPoint() ?? defaultSpawnPoint);
        }

        public void UpdateSpawn(ISpawn spawn)
        {
            currentSpawn?.SetSelected(false);
            currentSpawn = spawn;
            currentSpawn?.SetSelected(true);
            spawnMarker.position = spawn.GetPoint().position;
        }

        public void DropCurrentSpawn() => currentSpawn = null;

        public interface ISpawn
        {
            Transform GetPoint();
            void SetSelected(bool state);
            void Activate();
        }
    }
}
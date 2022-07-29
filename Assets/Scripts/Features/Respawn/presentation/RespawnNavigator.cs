using System;
using Core.PlayerInput;
using Core.SDK.GameState;
using Features.Levels.presentation.respawn;
using Features.Respawn.presentation.Spawns;
using FPSController;
using UnityEngine;
using Zenject;

namespace Features.Respawn.presentation
{
    public class RespawnNavigator : MonoBehaviour, IRespawnNavigator
    {
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private Transform camTransform;
        [Inject] private SpawnNavigator spawnNavigator;
        [Inject] private InputHandler handler;
        [Inject] private GameStateNavigator gameStateNavigator;

        private Action onRespawn;

        void IRespawnNavigator.RespawnPlayer() => spawnNavigator.ActivateSpawnPoint(RespawnPlayerAtPoint);

        public void RespawnPlayerAtPoint(Transform spawnPoint)
        {
            playerRigidbody.velocity = Vector3.zero;
            var playerObject = playerRigidbody.transform;
            playerObject.position = spawnPoint.position;
            playerObject.rotation = spawnPoint.rotation;
            camTransform.localRotation = Quaternion.identity;
            camTransform.GetComponent<FirstPersonLook>().ResetLook();
            handler.Reset();
            gameStateNavigator.SetLevelPlayingState(true);
            onRespawn?.Invoke();
        }

        public Action OnRespawn
        {
            get => onRespawn;
            set => onRespawn = value;
        }
    }
}
using System;
using Core.PlayerInput;
using Core.SDK.GameState;
using Features.Levels.presentation.respawn;
using UnityEngine;
using Zenject;

namespace Features.Respawn.presentation
{
    public class RespawnNavigator : MonoBehaviour, IRespawnNavigator
    {
        [SerializeField] private Transform spawn;
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private Transform camTransform;
        [Inject] private InputHandler handler;
        [Inject] private GameStateNavigator gameStateNavigator;

        private Action onRespawn;

        public Action OnRespawn
        {
            get => onRespawn;
            set => onRespawn = value;
        }

        void IRespawnNavigator.Respawn()
        {
            playerRigidbody.velocity = Vector3.zero;
            var playerObject = playerRigidbody.transform;
            playerObject.position = spawn.position;
            playerObject.rotation = spawn.rotation;
            camTransform.localRotation = Quaternion.identity;
            camTransform.GetComponent<FirstPersonLook>().ResetLook();
            handler.Reset();
            gameStateNavigator.SetLevelPlayingState(true);
            onRespawn?.Invoke();
        }
    }
}
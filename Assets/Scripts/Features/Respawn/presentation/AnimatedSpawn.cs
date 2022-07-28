using System;
using UnityEngine;

namespace Features.Respawn.presentation
{
    [Serializable]
    public class AnimatedSpawn: SpawnNavigator.ISpawn
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Animator spawnAnimator;
        [SerializeField] private string spawnTrigger = "spawn";
        [SerializeField] private string selectedFlag = "selected";

        public Transform GetPoint() => spawnPoint;

        public void SetSelected(bool state) => spawnAnimator.SetBool(selectedFlag, state);

        public void Activate() => spawnAnimator.SetTrigger(spawnTrigger);
    }
}
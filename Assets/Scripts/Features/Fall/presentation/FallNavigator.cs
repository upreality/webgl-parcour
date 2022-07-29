using System;
using System.Collections;
using Core.Sound.presentation;
using Features.Death;
using FPSController;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.Fall.presentation
{
    public class FallNavigator : MonoBehaviour, IFallNavigator
    {
        [SerializeField] private Transform catcher;
        [SerializeField] private float catcherDistance = 100f;
        [SerializeField] private Animator dieAnimator;
        [SerializeField] private AudioClip startFallSound;
        [SerializeField] private string fallAnimatorTrigger = "fall";

        [Inject] private FirstPersonLook look;
        [Inject] private FirstPersonMovement movement;

        [Inject] private FallSettings fallSettings;
        [Inject] private PlaySoundNavigator playSoundNavigator;
        [Inject] private DeathNavigator deathNavigator;

        private void Start() => catcher.gameObject.SetActive(false);

        public void StartFall()
        {
            dieAnimator.SetTrigger(fallAnimatorTrigger);
            playSoundNavigator.Play(startFallSound);
            StartCoroutine(FallCoroutine());
        }

        private IEnumerator FallCoroutine()
        {
            look.enabled = false;
            movement.enabled = false;
            catcher.gameObject.SetActive(true);

            var lookTransform = look.transform;
            var initialRotation = lookTransform.localRotation;
            var lookRotation = Quaternion.LookRotation(Vector3.down);
            var timer = fallSettings.turnUpDuration;

            while (timer > 0)
            {
                timer -= Time.deltaTime;
                var progress = 1f - timer / fallSettings.turnUpDuration;
                lookTransform.localRotation = Quaternion.Lerp(initialRotation, lookRotation, progress);
                var lookPosition = lookTransform.position;
                catcher.position = new Vector3(
                    x: lookPosition.x,
                    y: Mathf.Lerp(lookPosition.y - catcherDistance, lookPosition.y, progress),
                    z: lookPosition.z
                );
                yield return null;
            }

            movement.enabled = true;
            look.enabled = true;
            deathNavigator.HandleDeath().Subscribe().AddTo(this);
            catcher.gameObject.SetActive(false);
        }
    }
}
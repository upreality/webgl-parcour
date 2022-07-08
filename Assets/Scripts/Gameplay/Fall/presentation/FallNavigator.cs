using System.Collections;
using Doozy.Engine.UI;
using Gameplay.Death;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.Fall.presentation
{
    public class FallNavigator : MonoBehaviour, IFallNavigator
    {
        [SerializeField] private FirstPersonLook look;
        [SerializeField] private UIView dieFade;
        [SerializeField] private Animator dieAnimator;
        [SerializeField] private string fallAnimatorTrigger = "fall";

        [Inject] private FallSettings fallSettings;
        [Inject] private DeathNavigator deathNavigator;

        public void StartFall()
        {
            dieFade.Show();
            fallAnimatorTrigger = "fall";
            dieAnimator.SetTrigger(fallAnimatorTrigger);
            StartCoroutine(FallCoroutine());
        }

        private IEnumerator FallCoroutine()
        {
            look.enabled = false;
            var lookTransform = look.transform;
            var initialRotation = lookTransform.localRotation;
            var lookRotation = Quaternion.LookRotation(Vector3.up);

            var timer = fallSettings.turnUpDuration;

            while (timer > 0)
            {
                timer -= Time.deltaTime;
                var progress = 1f - timer / fallSettings.turnUpDuration;
                lookTransform.localRotation = Quaternion.Lerp(initialRotation, lookRotation, progress);
                yield return null;
            }

            look.enabled = true;
            deathNavigator.HandleDeath().Subscribe().AddTo(this);
        }
    }
}
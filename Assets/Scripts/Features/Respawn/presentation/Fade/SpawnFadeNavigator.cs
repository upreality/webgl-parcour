using System;
using System.Collections;
using UnityEngine;

namespace Features.Respawn.presentation.Fade
{
    public class SpawnFadeNavigator : MonoBehaviour
    {
        [SerializeField] private AnimationCurve fadeCurve;
        [SerializeField] private CanvasGroup fade;

        private float pos = 0f;

        public void SetFadeState(bool shown, float duration)
        {
            Debug.Log("SetFadeState: " + shown);
            StopAllCoroutines();
            StartCoroutine(FadeCoroutine(shown ? 1f : 0f, duration));
        }

        private IEnumerator FadeCoroutine(float targetPos, float duration)
        {
            if (duration == 0)
            {
                UpdatePosition(targetPos);
                yield break;
            }

            var positiveDirection = targetPos > pos; 
            var stepMultiplier = positiveDirection ? 1f / duration : -1f / duration;
            bool PositionReached() => positiveDirection ? pos >= targetPos : pos <= targetPos;
            while (!PositionReached())
            {
                UpdatePosition(pos + Time.deltaTime * stepMultiplier);
                yield return null;
            }
            UpdatePosition(targetPos);
        }

        private void UpdatePosition(float position)
        {
            fade.alpha = fadeCurve.Evaluate(position);
            pos = position;
        }

        private void OnDisable() => StopAllCoroutines();
    }
}
using System;
using Features.LevelsProgression.LevelTime.domain;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.LevelsProgression.LevelTime.presentation
{
    public class LevelTimerResultText: MonoBehaviour
    {
        [SerializeField] private Text text;
        [Inject] private ILevelTimerRepository levelTimerRepository;

        private void Awake()
        {
            if (text == null)
                text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            var timer = levelTimerRepository.GetTimerResult();
            text.text = TimeSpan.FromMilliseconds(timer).ToString(@"mm\:ss");
        }
    }
}
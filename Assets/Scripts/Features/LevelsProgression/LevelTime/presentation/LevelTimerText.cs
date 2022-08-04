using System;
using Features.Balance.domain;
using Features.Balance.domain.repositories;
using Features.LevelsProgression.LevelTime.domain;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Features.LevelsProgression.LevelTime.presentation
{
    public class LevelTimerText: MonoBehaviour
    {
        [SerializeField] private Text text;
        [Inject] private ILevelTimerRepository levelTimerRepository;

        private void Awake()
        {
            if (text == null)
                text = GetComponent<Text>();
        }

        private void Start() => levelTimerRepository.GetTimerFlow().Subscribe(UpdateTimer).AddTo(this);

        private void UpdateTimer(long timer)
        {
            text.text = TimeSpan.FromMilliseconds(timer).ToString(@"mm\:ss");
        }
    }
}
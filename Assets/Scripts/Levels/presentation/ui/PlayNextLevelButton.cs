﻿using Levels.domain.repositories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Levels.presentation.ui
{
    [RequireComponent(typeof(Button))]
    public class PlayNextLevelButton : MonoBehaviour
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private LevelLoadingNavigator levelLoadingNavigator;

        private void Start() => GetComponent<Button>().onClick.AddListener(OnClick);

        private void OnClick()
        {
            var currentLevel = currentLevelRepository.GetCurrentLevel();
            levelLoadingNavigator.LoadLevel(currentLevel.ID);
        }
    }
}
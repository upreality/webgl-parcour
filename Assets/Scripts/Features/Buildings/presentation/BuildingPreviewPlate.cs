using System;
using Data.BuildingsData;
using Features.Buildings.domain;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;
using static Features.Buildings.domain.BuildingProgressStateUseCase;

namespace Features.Buildings.presentation
{
    public class BuildingPreviewPlate : MonoBehaviour
    {
        [Inject] private BuildingProgressStateUseCase stateUseCase;
        [Inject] private IBuildingDataRepository dataRepository;

        [SerializeField] private BuildingType buildingType;
        [SerializeField] private TextMeshPro buildingNameText;
        [SerializeField] private TextMeshPro buildingDescriptionText;
        [SerializeField] private TextMeshPro buildingLevelText;
        [SerializeField] private SpriteRenderer buildingIcon;
        [SerializeField] private SpriteRenderer levelTextBackground;
        [SerializeField] private Color levelTextNotBuiltBackground;
        [SerializeField] private Color levelTextUpdateableBackground;
        [SerializeField] private Color levelTextFullBackground;

        private int BuildingId => buildingType.ToId();

        private void Start()
        {
            var buildingData = dataRepository.GetBuilding(BuildingId);
            buildingNameText.text = buildingData.Name;
            buildingDescriptionText.text = buildingData.Description;
            buildingIcon.sprite = buildingData.Image;
            stateUseCase.GetStateFlow(BuildingId).Subscribe(UpdateProgressState).AddTo(this);
        }

        private void UpdateProgressState(BuildingProgressState state)
        {
            levelTextBackground.color = GetBackgroundColor(state.Progress);
            buildingLevelText.text = state.Level.ToString();
        }

        private Color GetBackgroundColor(BuildingProgress progress) => progress switch
        {
            BuildingProgress.NotBuilt => levelTextNotBuiltBackground,
            BuildingProgress.UpgradeAvailable => levelTextUpdateableBackground,
            BuildingProgress.CompletelyUpgraded => levelTextFullBackground,
            _ => throw new ArgumentOutOfRangeException(nameof(progress), progress, null)
        };
    }
}
using System.Collections;
using Data.BuildingsData;
using Features.Buildings.domain;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;
using static Features.Buildings.domain.BuildingProgressStateUseCase;
using static Features.Buildings.domain.UpdateBuildingUseCase;

namespace Features.Buildings.presentation
{
    public class DebugBuilding : MonoBehaviour
    {
        [Inject] private BuildingProgressStateUseCase progressStateUseCase;
        [Inject] private UpdateBuildingUseCase updateBuildingUseCase;

        [SerializeField] private TextMeshPro levelText;
        [SerializeField] private TextMeshPro progressText;
        [SerializeField] private TextMeshPro resultText;
        [SerializeField] private BuildingType buildingType;

        private string BuildingId => buildingType.ToId();

        private void Start()
        {
            resultText.enabled = false;
            progressStateUseCase.GetStateFlow(BuildingId).Subscribe(ApplyState).AddTo(this);
        }

        private void ApplyState(BuildingProgressState state)
        {
            levelText.text = state.Level.ToString();
            progressText.text = state.Progress.ToString();
            transform.localScale = (state.Level * 0.1f + 1f) * Vector3.one;
        }

        public void Upgrade() => updateBuildingUseCase
            .UpdateBuilding(BuildingId)
            .Subscribe(HandleUpgradeResult)
            .AddTo(this);

        private void HandleUpgradeResult(UpdateResult result)
        {
            StopAllCoroutines();
            StartCoroutine(ShowRes(result));
        }

        private IEnumerator ShowRes(UpdateResult result)
        {
            resultText.enabled = true;
            resultText.text = result.ToString();
            yield return new WaitForSeconds(1.5f);
            resultText.enabled = false;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            resultText.enabled = false;
        }
    }
}
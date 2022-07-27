using Features.Levels.domain.repositories;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Features.Levels.presentation
{
    public class CurrentLevelFilter : MonoBehaviour
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [SerializeField] private int passEveryLevels = 5;
        [SerializeField] private UnityEvent onFilterPass;

        public void PushEvent()
        {
            var levelIndex = currentLevelRepository.GetCurrentLevel().Number - 1;
            if(levelIndex%passEveryLevels != 0)
                return;
            
            onFilterPass.Invoke();
        }
    }
}

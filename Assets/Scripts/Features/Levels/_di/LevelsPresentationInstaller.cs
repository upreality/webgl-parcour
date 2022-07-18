using Features.Levels.presentation;
using Features.Levels.presentation.loader;
using Features.Levels.presentation.ui;
using UnityEngine;
using Zenject;

namespace Features.Levels._di
{
    public class LevelsPresentationInstaller : MonoInstaller
    {
        [SerializeField] private LevelSceneLoader loader;
        [SerializeField] private LevelItem levelItemPrefab;
        [SerializeField] private CurrentLevelLoadingNavigator currentLevelLoadingNavigator;

        public override void InstallBindings()
        {
            //Presentation
            Container.Bind<LevelSceneLoader.ILevelLoadingTransition>().To<EmptySceneLoadingTransition>().AsSingle();
            Container.Bind<LevelSceneLoader>().FromInstance(loader).AsSingle();
            Container.Bind<LevelLoadingNavigator>().AsSingle();
            Container.Bind<CurrentLevelLoadingNavigator>().FromInstance(currentLevelLoadingNavigator).AsSingle();
            //UI
            Container.Bind<LevelItem.ILevelItemController>().To<DefaultLevelItemController>().AsSingle();
            Container.Decorate<LevelItem.ILevelItemController>().With<LevelItemControllerAnalyticsDecorator>();
            Container.BindFactory<LevelItem, LevelItem.Factory>().FromComponentInNewPrefab(levelItemPrefab);
        }
    }
}
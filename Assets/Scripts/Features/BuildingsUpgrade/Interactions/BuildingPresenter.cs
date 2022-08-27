using Features.BuildingsUpgrade.Interactions.Interfaces;
using Features.BuildingsUpgrade.Data;
using System;

namespace Features.BuildingsUpgrade.Interactions
{
    public class BuildingPresenter : IBuildingPresenter, IDisposable
    {
        public BuildingPresenter(IBuildingView view, IBuildingModel model, UpgradeRepository upgradeRepository)
        {
            _view = view;
            _model = model;
            _upgradeRepository = upgradeRepository;
            
            Initialize();
        }

        private readonly IBuildingView _view;
        private readonly IBuildingModel _model;
        private readonly UpgradeRepository _upgradeRepository;

        private void Initialize()
        {
            _view.OnSkillsOpen += _model.GetInfo;
            _view.OnBuyUpgrade += _model.ChangeUpgrade;
            _model.OnDataCallback += _view.UpdateSkillLevel;
            _model.OnModelInitialized += _view.Initialize;
            _model.Initialize(_upgradeRepository);
            _model.OnModelChanged += _view.UpdateView;
        }

        public void Dispose()
        {
            _view.OnSkillsOpen -= _model.GetInfo;
            _view.OnBuyUpgrade -= _model.ChangeUpgrade;
            _model.OnDataCallback -= _view.UpdateSkillLevel;
            _model.OnModelInitialized -= _view.Initialize;
        }
    }
}

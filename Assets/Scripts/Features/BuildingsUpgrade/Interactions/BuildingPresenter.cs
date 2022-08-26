using Features.BuildingsUpgrade.Interactions.Interfaces;
using Features.BuildingsUpgrade.Data;

namespace Features.BuildingsUpgrade.Interactions
{
    public class BuildingPresenter : IBuildingPresenter
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
            _model.OnDataCallback += _view.UpdateSkillLevel;
            _view.Initialize(_upgradeRepository);
        }
    }
}

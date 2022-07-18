using Utils.PlayerTrigger;
using Zenject;

namespace Features.Gameplay.AttackAreas
{
    public class AttackAreaTrigger: PlayerTriggerBase
    {
        [Inject] private AttackAreaNavigator attackAreaNavigator;
        protected override void OnPlayerEntersTrigger()
        {
            attackAreaNavigator.SetAttackArea(transform);
        }

        protected override void OnPlayerExitTrigger()
        {
            //Do nothing
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Features.BuildingsUpgrade.Data
{
    [CreateAssetMenu(menuName = "BuildingsUpgrade/UpgradeRepository")]
    public class UpgradeRepository : ScriptableObject
    {
        [field: SerializeField, NonReorderable]
        public List<UpgradeData> UpgradeList
        {
            get;
            private set;
        }
    }
}

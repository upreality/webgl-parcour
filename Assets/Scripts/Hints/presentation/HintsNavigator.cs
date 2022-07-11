using Doozy.Engine.UI;
using UnityEngine;

namespace Hints.presentation
{
    public class HintsNavigator: MonoBehaviour
    {
        [SerializeField] private UIView hintView;

        public void Show() => hintView.Show();
        
        public void Hide() => hintView.Hide();
    }
}
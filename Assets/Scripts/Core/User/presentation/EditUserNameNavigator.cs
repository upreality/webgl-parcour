using Doozy.Engine.UI;
using UnityEngine;

namespace Core.User.presentation
{
    public class EditUserNameNavigator: MonoBehaviour
    {
        [SerializeField] private UIView editorPanelView;

        public void OpenUserNameEditing() => editorPanelView.Show();
    }
}
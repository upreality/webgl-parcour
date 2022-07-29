using System;
using Doozy.Engine.UI;
using UnityEngine;

namespace Core.User.presentation
{
    public class EditUserNameNavigator: MonoBehaviour
    {
        [SerializeField] private UIView editorPanelView;

        public void OpenUserNameEditing() => editorPanelView.Show();

        private void Update()
        {
            if(!Input.GetKeyDown(KeyCode.Escape))
                return;
            
            if(!editorPanelView.IsVisible)
                return;
            
            editorPanelView.Hide();
        }
    }
}
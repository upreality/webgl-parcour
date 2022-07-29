using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.User.presentation
{
    public class EditUserNameButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [Inject] private EditUserNameNavigator editUserNameNavigator;

        private void Start() => button.onClick.AddListener(() => editUserNameNavigator.OpenUserNameEditing());
    }
}
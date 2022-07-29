using System;
using Plugins.FileIO;
using UniRx;
using Zenject;

namespace Core.User.data
{
    public class UserNameLocalDataSource
    {
        private readonly ReactiveProperty<string> userNameFlow;

        private const string UserNameKey = "USER_NAME_KEY";
        private string defaultUserName = "New Traveller";

        private string UserName
        {
            get
            {
                if (LocalStorageIO.HasKey(UserNameKey))
                    return LocalStorageIO.GetString(UserNameKey);

                LocalStorageIO.SetString(UserNameKey, defaultUserName);
                LocalStorageIO.Save();

                return defaultUserName;
            }
            set
            {
                LocalStorageIO.SetString(UserNameKey, value);
                userNameFlow.Value = value;
            }
        }

        [Inject]
        public UserNameLocalDataSource()
        {
            userNameFlow = new ReactiveProperty<string>(UserName);
        }

        public IObservable<string> GetUserNameFlow() => userNameFlow;

        public void UpdateUserName(string newName) => UserName = newName;
    }
}
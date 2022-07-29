using System;

namespace Core.User.domain
{
    public interface ICurrentUserNameRepository
    {
        IObservable<string> GetUserNameFlow();
        IObservable<bool> UpdateUserName(string newName);
    }
}
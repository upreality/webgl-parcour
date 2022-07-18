using Core.Analytics.session.domain;
using Plugins.FileIO;

namespace Core.Analytics.session.data
{
    public class LocalStorageFirstOpenEventSentRepository: IFirstOpenEventSentRepository
    {
        private const string PrefsKeyPrefix = "FirstOpenEventSent";
        public bool IsFirstOpen() => !LocalStorageIO.HasKey(PrefsKeyPrefix); 
        public void SetFirstOpenAppeared() => LocalStorageIO.SetString(PrefsKeyPrefix, "true");
    }
}
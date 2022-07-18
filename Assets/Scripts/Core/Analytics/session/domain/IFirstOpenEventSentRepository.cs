namespace Core.Analytics.session.domain
{
    public interface IFirstOpenEventSentRepository
    {
        public bool IsFirstOpen();
        public void SetFirstOpenAppeared();
    }
}
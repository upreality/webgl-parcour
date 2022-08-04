using Zenject;

namespace Features.GlobalScore.domain
{
    public class CalculateGlobalScoreUseCase
    {
        [Inject] private IGlobalScoreRepository globalScoreRepository;

        public int CalculateScore()
        {
            //TODO: implement calc
            return 0;
        }
    }
}
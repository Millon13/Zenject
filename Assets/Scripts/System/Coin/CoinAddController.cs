using Modules;

namespace System.Coin
{
    public class CoinAddController:IDisposable
    { 
        private readonly IScore _score;
        private readonly CoinManager _coinManager;

        public CoinAddController(IScore score,CoinManager coinManager)
        {
            _score = score;
            _coinManager=coinManager;
            _coinManager.OnLevelCompleted += Add;
        }

        public void Add()
        {
            _score.Add(1);
        }
        public void Dispose()
        {
            _coinManager.OnLevelCompleted += Add;
        }
     
    }
}
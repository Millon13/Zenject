using Modules;

namespace System.Coin
{
    public class ScoreAddController : IDisposable
    {
        private readonly IScore _score;
        
        private readonly CoinManager _coinManager;

        public ScoreAddController(IScore score, CoinManager coinManager)
        {
            _score = score;
            _coinManager = coinManager;
            _coinManager.OnCollectedCoin += Add;
        }

        private void Add()
        {
            _score.Add(1);
        }

        public void Dispose()
        {
            _coinManager.OnCollectedCoin -= Add;
        }
    }
}
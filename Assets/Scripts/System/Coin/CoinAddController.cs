using Modules;

namespace System.Coin
{
    public class CoinAddController : IDisposable
    {
        private IScore _score;
        private CoinManager _coinManager;

        public CoinAddController(IScore score, CoinManager coinManager)
        {
            _score = score;
            _coinManager = coinManager;
            _coinManager.OnLevelCompleted += Add;
        }

        private void Add()
        {
            _score.Add(1);
        }

        public void Dispose()
        {
            _coinManager.OnLevelCompleted -= Add;
        }
    }
}
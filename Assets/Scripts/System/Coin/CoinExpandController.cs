using Modules;

namespace System.Coin
{
    public class CoinExpandController : IDisposable
    {
        private Snake _snake;
        private CoinManager _coinManager;

        public CoinExpandController(Snake snake, CoinManager coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
            _coinManager.OnLevelCompleted += Expand;
        }

        public void Expand()
        {
            _snake.Expand(1);
        }

        public void Dispose()
        {
            _coinManager.OnLevelCompleted -= Expand;
        }
    }
}
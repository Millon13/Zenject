using System.Coin;

namespace System.Snake
{
    public class SnakeExpandController : IDisposable
    {
        private Modules.Snake _snake;
        
        private CoinManager _coinManager;

        public SnakeExpandController(Modules.Snake snake, CoinManager coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
            _coinManager.OnCollectedCoin += Expand;
        }

        private void Expand()
        {
            _snake.Expand(1);
        }

        public void Dispose()
        {
            _coinManager.OnCollectedCoin -= Expand;
        }
    }
}
using UnityEngine;
using Modules;

namespace System.Coin
{
    public class CoinCollectController : IDisposable
    {
        private CoinManager _coinManager;

        private Modules.Snake _snake;

        private Pool _pool;

        public CoinCollectController(Modules.Snake snake, CoinManager coinManager, Pool pool)
        {
            _snake = snake;
            _snake.OnMoved += this.OnMoved;
            _coinManager = coinManager;
            _pool = pool;
        }

        private void OnMoved(Vector2Int obj)
        {
            if (_pool.NumTotal > 0)
            {
                _coinManager.TryCollectCoin(_snake.HeadPosition);
            }
        }


        public void Dispose()
        {
            _snake.OnMoved -= this.OnMoved;
        }
    }
}
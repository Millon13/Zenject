using Zenject;

namespace System.Coin
{
    public class CoinSpawnerController : ITickable
    {
        private readonly Pool _pool;
        
        private readonly CoinManager _coinManager;

        public CoinSpawnerController(Pool pool, CoinManager coinManager)
        {
            _pool = pool;
            _coinManager = coinManager;
        }

        public void Tick()
        {
            if (_pool.NumTotal == 0)
            {
                _coinManager.SpawnCoin();
            }
        }
    }
}
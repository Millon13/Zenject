using System.Collections.Generic;
using UnityEngine;
using SnakeGame;

namespace System.Coin
{
    public class CoinManager
    {
        private readonly IWorldBounds _worldBounds;
        public event Action OnLevelCompleted;
        public event Action OnCollectedCoin;
        
        private List<Modules.Coin> _remainingCoins;
        
        private readonly Pool _pool;

        private int _coinsNeeded;

        public CoinManager(IWorldBounds worldBounds, Pool pool)
        {
            _worldBounds = worldBounds;
            _pool = pool;
            _coinsNeeded = 1;
            _remainingCoins = new List<Modules.Coin>();
            LevelSpawn(_coinsNeeded);
        }

        public Modules.Coin SpawnCoin()
        {
            if (_worldBounds == null) return null;

            Vector2 spawnPosition = _worldBounds.GetRandomPosition();
            Modules.Coin newCoin = _pool.Spawn();
            _remainingCoins.Add(newCoin);

            Vector2Int positionInt = new Vector2Int(
                Mathf.RoundToInt(spawnPosition.x),
                Mathf.RoundToInt(spawnPosition.y)
            );
            newCoin.Position = positionInt;
            newCoin.Generate();
            return newCoin;
        }


        private Modules.Coin GetCoinAtPosition(Vector2Int position)
        {
            foreach (Modules.Coin coin in _remainingCoins)
            {
                if (coin != null && coin.Position == position)
                {
                    return coin;
                }
            }

            return null;
        }

        public bool TryCollectCoin(Vector2Int headPosition)
        {
            Modules.Coin coin = GetCoinAtPosition(headPosition);
            if (coin != null)
            {
                _pool.Despawn(coin);
                _remainingCoins.Remove(coin);
                OnCollectedCoin?.Invoke();
                if (_remainingCoins.Count == 0)
                {
                    _coinsNeeded++;
                    LevelSpawn(_coinsNeeded);
                    OnLevelCompleted?.Invoke();
                }

                return true;
            }

            return false;
        }

        public void LevelSpawn(int coinsNeeded)
        {
            for (int i = 0; i < coinsNeeded; i++)
            {
                SpawnCoin();
            }
        }
    }
}
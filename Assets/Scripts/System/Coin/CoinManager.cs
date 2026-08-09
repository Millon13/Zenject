using System;
using System.Coin;
using Modules;
using UnityEngine;
using SnakeGame;
using System.Collections.Generic;

public class CoinManager : IDisposable
{
    private readonly CoinFactory _coinFactory;

    private readonly IWorldBounds _worldBounds;
    
    private readonly List<Coin> _spawnedCoins;
    
    private readonly CoinExpandController _expandController;
    
    private readonly CoinAddController _addController;
    public event Action OnLevelCompleted;
    
    private int _removedCoins;

    public CoinManager(CoinFactory coinFactory, IWorldBounds worldBounds)
    {
        _coinFactory = coinFactory;
        _worldBounds = worldBounds;
        _spawnedCoins = new List<Coin>();
    }

    public IReadOnlyList<Coin> SpawnedCoins => _spawnedCoins;

    public Coin SpawnCoin()
    {
        if (_worldBounds == null) return null;

        Vector2 spawnPosition = _worldBounds.GetRandomPosition();
        Coin newCoin = _coinFactory.Create();

        Vector2Int positionInt = new Vector2Int(
            Mathf.RoundToInt(spawnPosition.x),
            Mathf.RoundToInt(spawnPosition.y)
        );
        newCoin.Position = positionInt;
        newCoin.Generate();
        _spawnedCoins.Add(newCoin);
        return newCoin;
    }

    public void RemoveCoin(Coin coin)
    {
        if (_spawnedCoins.Remove(coin))
        {
            if (coin != null)
            {
                GameObject.Destroy(coin.gameObject);
                _removedCoins++;
            }
        }
    }

    public void ClearAllCoins()
    {
        foreach (Coin coin in _spawnedCoins)
        {
            if (coin != null)
            {
                GameObject.Destroy(coin.gameObject);
            }
        }

        _spawnedCoins.Clear();
    }

    public Coin GetCoinAtPosition(Vector2Int position)
    {
        foreach (Coin coin in _spawnedCoins)
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
        Coin coin = GetCoinAtPosition(headPosition);
        if (coin != null)
        {
            OnLevelCompleted?.Invoke();
            RemoveCoin(coin);
            return true;
        }

        return false;
    }
    public void LevelSpawn(int coinsNeeded)
    {
        ClearAllCoins();
        for (int i = 0; i < coinsNeeded; i++)
        {
            SpawnCoin();
        }
    }

    public void Dispose()
    {
        ClearAllCoins();
    }
}
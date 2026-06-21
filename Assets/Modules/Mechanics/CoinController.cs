using UnityEngine;
using Zenject;
using System.Collections.Generic;
using Modules;
using SnakeGame;

public class CoinController : ITickable
{
    public event System.Action OnCoinCollected;
    
    private Coin _coinPrefab;
    
    private readonly Snake _snake;
    
    private WorldBounds _worldBounds;
    
    private List<Coin> _spawnedCoins = new List<Coin>();

    private IScore _score;
    
    private IDifficulty _difficulty;
    
    private int _currentDifficulty;

    [Inject]
    public CoinController(Coin coinPrefab, Snake snake, WorldBounds worldBounds, IScore score, IDifficulty difficulty)
    {
        _coinPrefab = coinPrefab;
        _snake = snake;
        _worldBounds = worldBounds;
        _score = score;
        _difficulty = difficulty;
    }
    
    public void Tick()
    {
        CheckCollision(_snake.HeadPosition);

        if (_spawnedCoins.Count == 0)
        {
            SpawnCoin();
        }
    }

    private void CheckCollision(Vector2Int headPosition)
    {
        for (int i = _spawnedCoins.Count - 1; i >= 0; i--)
        {
            Coin coin = _spawnedCoins[i];
            if (coin != null && coin.Position == headPosition)
            {
                CollectCoin(coin, i);
                break;
            }
        }
    }

    private void CollectCoin(Coin coin, int index)
    {
        _snake.Expand(1);

        _score.Add(1);
        if (_difficulty.Next(out int newDifficulty))
        {
            float newSpeed = 2f + (newDifficulty - 1) * 0.5f;
            _snake.SetSpeed(newSpeed);
        }

        _spawnedCoins.RemoveAt(index);
        if (coin != null)
        {
            Object.Destroy(coin.gameObject);
        }

        OnCoinCollected?.Invoke();
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        Vector2 spawnPosition = _worldBounds.GetRandomPosition();

        if (_coinPrefab != null)
        {
            Coin newCoin = Object.Instantiate(_coinPrefab, new Vector2(spawnPosition.x, spawnPosition.y),
                Quaternion.identity);
            newCoin.Generate();
            _spawnedCoins.Add(newCoin);
        }
    }
}
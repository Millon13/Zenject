using System.Collections.Generic;
using Modules;
using UnityEngine;

public class Pool
{
    private readonly List<Coin> _coins;
    public IReadOnlyList<Coin> Coins => _coins;


    public Pool()
    {
        _coins = new List<Coin>();
    }

    public void AddInPool(Coin coin)
    {
        _coins.Add(coin);
    }

    public void RemoveCoin(Coin coin)
    {
        if (_coins.Remove(coin))
        {
            if (coin != null)
            {
                GameObject.Destroy(coin.gameObject);
            }
        }
    }


    public void ClearPool()
    {
        foreach (Coin coin in _coins)
        {
            if (coin != null)
            {
                GameObject.Destroy(coin.gameObject);
            }
        }

        _coins.Clear();
    }
}
using System;
using SnakeGame;
using Modules;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;


public class GameLoseController : IDisposable
{
    private readonly Snake _snake;

    private GameCycle _gameCycle;

    private IWorldBounds _worldBounds;

    public GameLoseController(Snake snake, GameCycle gameCycle, IWorldBounds worldBounds)
    {
        _snake = snake;
        _gameCycle = gameCycle;
        _worldBounds = worldBounds;
        _snake.OnSelfCollided += Dead;
        _snake.OnMoved += OnMoved;
    }

    private void OnMoved(Vector2Int obj)
    {
       
        if (IsWorldCollided())
        {
            Dead();
        } 
    }


    public void Dispose()
    {
        _snake.OnSelfCollided -= Dead;
        _snake.OnMoved -= OnMoved;
        
    }

 

    public bool IsWorldCollided()
    {
        if (!_worldBounds.IsInBounds(_snake.HeadPosition))
        {
            return true;
        }

        return false;
    }

    private void Dead()
    {
        _gameCycle.Lose();
    }
}

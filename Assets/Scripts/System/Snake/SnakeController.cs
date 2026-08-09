using UnityEngine;
using Zenject;
using System;
using Modules;

public class SnakeController : IDisposable
{
    private readonly Snake _snake;

    private readonly InputSystem _inputSystem;


    public SnakeController(Snake snake, InputSystem inputSystem)
    {
        _snake = snake;
        _inputSystem = inputSystem;
        _inputSystem.OnTurn += _snake.Turn;
    }



    public void Dispose()
    {
        _inputSystem.OnTurn -= _snake.Turn;
    }
}
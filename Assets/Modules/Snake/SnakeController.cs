using UnityEngine;
using Zenject;
using System;

namespace Modules
{
    public class SnakeController : ITickable
    {
        private readonly Snake _snake;
        private SnakeDirection _currentDirection;

        private readonly InputButtonSystem _inputButtonSystem;

        [Inject]
        public SnakeController(SnakeDirection currentDirection, Snake snake, InputButtonSystem inputButtonSystem)
        {
            _currentDirection = currentDirection;
            _snake = snake;
            _inputButtonSystem = inputButtonSystem;
            Debug.Log(
                $"[SnakeController] Initialized: Direction={_currentDirection}, Snake={_snake != null}, InputSystem={_inputButtonSystem != null}");
        }


        public void MoveKeyBoardProvider()
        {
            SnakeDirection newDirection = SnakeDirection.NONE;
            if (_inputButtonSystem.IsKeyDown("Up"))
                newDirection = SnakeDirection.UP;
            else if (_inputButtonSystem.IsKeyDown("Down"))
                newDirection = SnakeDirection.DOWN;
            else if (_inputButtonSystem.IsKeyDown("Left"))
                newDirection = SnakeDirection.LEFT;
            else if (_inputButtonSystem.IsKeyDown("Right"))
                newDirection = SnakeDirection.RIGHT;

            if (newDirection != SnakeDirection.NONE && IsValidTurn(newDirection))
            {
                _snake.Turn(newDirection);
                _currentDirection = newDirection;
            }
        }

        private bool IsValidTurn(SnakeDirection newDirection)
        {
            if (_currentDirection == SnakeDirection.UP && newDirection == SnakeDirection.DOWN)
                return false;
            if (_currentDirection == SnakeDirection.DOWN && newDirection == SnakeDirection.UP)
                return false;
            if (_currentDirection == SnakeDirection.LEFT && newDirection == SnakeDirection.RIGHT)
                return false;
            if (_currentDirection == SnakeDirection.RIGHT && newDirection == SnakeDirection.LEFT)
                return false;

            return true;
        }

        public void Tick()
        {
            MoveKeyBoardProvider();
        }
    }
}
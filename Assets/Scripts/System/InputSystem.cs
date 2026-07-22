using UnityEngine;
using System;
using Modules;


[CreateAssetMenu(fileName = "NewInputDictionary", menuName = "Input/Input Dictionary")]
[System.Serializable]
public class InputSystem : ScriptableObject
{
    public event Action<SnakeDirection> OnTurn;

    private SnakeDirection _currentDirection;

    [SerializeField] private KeyCode _up;

    [SerializeField] private KeyCode _down;

    [SerializeField] private KeyCode _left;

    [SerializeField] private KeyCode _right;

    private Snake _snake;

    public void MoveKeyBoardProvider()
    {
        SnakeDirection newDirection = SnakeDirection.NONE;

        if (Input.GetKeyDown(_up))
        {
            newDirection = SnakeDirection.UP;
        }

        if (Input.GetKeyDown(_down))
        {
            newDirection = SnakeDirection.DOWN;
        }

        if (Input.GetKeyDown(_left))
        {
            newDirection = SnakeDirection.LEFT;
        }

        if (Input.GetKeyDown(_right))
        {
            newDirection = SnakeDirection.RIGHT;
        }


        if (newDirection != SnakeDirection.NONE && IsValidTurn(newDirection))
        {
            OnTurn.Invoke(newDirection);
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
}
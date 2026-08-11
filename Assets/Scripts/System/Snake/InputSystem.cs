using UnityEngine;
using System;
using Modules;
using Zenject;


//[CreateAssetMenu(fileName = "NewInputDictionary", menuName = "Input/Input Dictionary")]
[System.Serializable]
public class InputSystem : MonoBehaviour,  ITickable
{
    public event Action<SnakeDirection> OnTurn;

    [SerializeField] private KeyCode _up;

    [SerializeField] private KeyCode _down;

    [SerializeField] private KeyCode _left;

    [SerializeField] private KeyCode _right;
    

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


        if (newDirection != SnakeDirection.NONE )
        {
            OnTurn?.Invoke(newDirection);
        }
    }
    public void Tick()
    {
        MoveKeyBoardProvider();
    }

   
}
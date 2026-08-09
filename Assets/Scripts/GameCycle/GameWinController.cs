using SnakeGame;
using Modules;
using UnityEngine;
using Zenject;

public class GameWinController 
{
    private readonly GameCycle _gameCycle;

    private readonly IDifficulty _difficulty;

    public GameWinController(GameCycle gameCycle, IDifficulty difficulty)
    {
        _gameCycle = gameCycle;
        _difficulty = difficulty;
        _difficulty.OnStateChanged += OnStateChanged;
    }

    private void OnStateChanged()
    {
        if (_difficulty.Current == _difficulty.Max)
                    _gameCycle.Win();
    }
   
}

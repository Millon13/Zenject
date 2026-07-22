using Zenject;
using Modules;
using SnakeGame;
using UI;

public class UIController : ITickable
{
    private readonly IGameUI _gameUI;

    private readonly GameCycle _gameCycle;

    private readonly IScore _score;

    private readonly IDifficulty _difficulty;


    public UIController(
        IGameUI gameUI,
        IScore score,
        IDifficulty difficulty, GameCycle gameCycle)
    {
        _gameUI = gameUI;
        _score = score;
        _difficulty = difficulty;
        _gameCycle = gameCycle;
        _gameCycle.OnLose += this.OnLose;
        _gameCycle.OnWin += this.OnWin;
    }

    private void OnLose()
    {
        _gameUI.GameOver(false);
    }

    private void OnWin()
    {
        _gameUI.GameOver(true);
    }

    private void OnDispose()
    {
        _gameCycle.OnLose -= this.OnLose;
        _gameCycle.OnWin -= this.OnWin;
    }

    public void Tick()
    {
        _gameUI.SetScore(_score.Current.ToString());
        _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        if (_difficulty.Current == _difficulty.Max)
            _gameUI.GameOver(true);
    }
}
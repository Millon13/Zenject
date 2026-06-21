using Zenject;
using Modules;
using SnakeGame;

public class UIController : ITickable
{
    private readonly IGameUI _gameUI;
    
    private readonly IScore _score;
    
    private readonly IDifficulty _difficulty;
    
    private readonly Snake _snake;
    
    private WorldBounds _worldBounds;

    public UIController(
        IGameUI gameUI,
        IScore score,
        IDifficulty difficulty,
        Snake snake,
        WorldBounds worldBounds)
    {
        _gameUI = gameUI;
        _score = score;
        _difficulty = difficulty;
        _snake = snake;
        
        _worldBounds = worldBounds;
    }

    private void Dead()
    {
        _gameUI.GameOver(false);
    }


    public void Tick()
    {
        _snake.OnSelfCollided += Dead;

        _gameUI.SetScore(_score.Current.ToString());
        _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        if (_difficulty.Current == _difficulty.Max)
            _gameUI.GameOver(true);
        if (!_worldBounds.IsInBounds(_snake.HeadPosition))
        {
            Dead();
        }
    }
}
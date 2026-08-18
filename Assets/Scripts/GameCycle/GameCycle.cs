using System;

namespace GameCycle
{
    public class GameCycle
    {
        public event Action OnLose;
        public event Action OnWin;

        public void Win()
        {
            OnWin?.Invoke();
        }

        public void Lose()
        {
            OnLose?.Invoke();
        }
    }
}
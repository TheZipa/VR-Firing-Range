using System;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.Timer;
using UniRx;

namespace FiringRange.Code.Logic.Common
{
    public class FiringRangeGame : IFactoryEntity
    {
        public event Action OnEnd;
        public readonly IntReactiveProperty Points = new(0);
        
        private readonly ITimer _timer;
        private readonly TimeSpan _gameTime;
        private readonly IDisposable _disposable;

        public FiringRangeGame(ITimer timer, GameStatsView gameStatsView, TimeSpan gameTime)
        {
            _gameTime = gameTime;
            _timer = timer;
            _timer.OnTimerComplete += Finish;
            _timer.OnTimerUpdate += gameStatsView.UpdateTimeText;
            _disposable = Points.Subscribe(gameStatsView.UpdatePointsText);
        }

        public void Start()
        {
            Points.Value = 0;
            _timer.Start(_gameTime);
        }

        private void Finish()
        {
            OnEnd?.Invoke();
        }

        ~FiringRangeGame() => _disposable.Dispose();
    }
}
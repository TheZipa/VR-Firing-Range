using System;
using FiringRange.Code.Logic.Common.TargetPlace;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.Timer;
using UniRx;

namespace FiringRange.Code.Logic.Common
{
    public class FiringRangeGame : IFactoryEntity
    {
        public event Action OnEnd;
        public readonly IntReactiveProperty Points = new(0);
        public bool IsPlaying => _timer.IsRunning;
        
        private readonly ITimer _timer;
        private readonly TimeSpan _gameTime;
        private readonly GameStatsView _gameStatsView;
        private readonly TargetPlacement[] _placements;
        private IDisposable _disposable;
        private int _placementIndex = 0;

        public FiringRangeGame(ITimer timer, GameStatsView gameStatsView, TargetPlacement[] placements, TimeSpan gameTime)
        {
            _gameStatsView = gameStatsView;
            _timer = timer;
            _gameTime = gameTime;
            _placements = placements;
            Subscribe(gameStatsView);
        }

        private void Subscribe(GameStatsView gameStatsView)
        {
            _timer.OnTimerComplete += Stop;
            _timer.OnTimerUpdate += gameStatsView.UpdateTimeText;
            _disposable = Points.Subscribe(gameStatsView.UpdatePointsText);
            foreach (TargetPlacement placement in _placements) 
                placement.OnTargetHit += () => Points.Value++;
        }

        public void SwitchTargetPlacement(int placementIndex) => _placementIndex = placementIndex;

        public void Start()
        {
            if (_timer.IsRunning) return;
            Points.Value = 0;
            CurrentPlacement().PlaceAll();
            _timer.Start(_gameTime);
        }

        public void Stop()
        {
            _timer.Stop();
            _gameStatsView.UpdateTimeText(TimeSpan.Zero);
            CurrentPlacement().Disable();
            OnEnd?.Invoke();
        }

        private TargetPlacement CurrentPlacement() => _placements[_placementIndex];

        ~FiringRangeGame() => _disposable.Dispose();
    }
}
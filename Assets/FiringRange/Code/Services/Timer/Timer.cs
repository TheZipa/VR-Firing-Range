using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace FiringRange.Code.Services.Timer
{
    public class Timer : ITimer
    {
        public event Action OnTimerComplete;
        public event Action<TimeSpan> OnTimerUpdate;
        public bool IsRunning { get; private set; }
        
        private TimeSpan _duration;
        private TimeSpan _elapsed;
        private bool _isPaused;
        private CancellationTokenSource _cts;

        public void Start(TimeSpan duration)
        {
            if (_cts is { Token: { IsCancellationRequested: false } }) return;
            
            _cts = new CancellationTokenSource();
            _elapsed = TimeSpan.Zero;
            _duration = duration;
            IsRunning = true;
            RunTimerAsync(_cts.Token).Forget();
        }

        public void Resume()
        {
            if (!_isPaused) return;
            _isPaused = false;
            _cts = new CancellationTokenSource();
            IsRunning = true;
            RunTimerAsync(_cts.Token).Forget();
        }
        
        public void Pause()
        {
            _isPaused = true;
            IsRunning = false;
            Stop();
        }

        public void Stop()
        {
            _cts?.Cancel();
            IsRunning = false;
        }

        private async UniTaskVoid RunTimerAsync(CancellationToken token)
        {
            try
            {
                TimeSpan updateInterval = TimeSpan.FromMilliseconds(100);

                while (_elapsed < _duration)
                {
                    await UniTask.Delay(updateInterval, cancellationToken: token);
                    _elapsed += updateInterval;
                    OnTimerUpdate?.Invoke(_duration - _elapsed);
                }

                OnTimerComplete?.Invoke();
            }
            catch (OperationCanceledException)
            {
                // Timer was cancelled
            }
        }
    }
}
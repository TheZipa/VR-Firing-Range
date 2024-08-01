using System;

namespace FiringRange.Code.Services.Timer
{
    public interface ITimer : IGlobalService
    {
        event Action OnTimerComplete;
        event Action<TimeSpan> OnTimerUpdate;
        void Start(TimeSpan duration);
        void Resume();
        void Pause();
        void Stop();
    }
}
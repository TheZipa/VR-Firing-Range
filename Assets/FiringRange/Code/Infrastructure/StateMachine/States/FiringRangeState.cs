using FiringRange.Code.Infrastructure.StateMachine.GameStateMachine;
using FiringRange.Code.Logic.Common;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.LoadingCurtain;
using FiringRange.Code.XRPlayer;

namespace FiringRange.Code.Infrastructure.StateMachine.States
{
    public class FiringRangeState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IEntityContainer _entityContainer;
        private readonly ILoadingCurtain _loadingCurtain;

        private FiringRangeGame _firingRangeGame;
        private XRButton _startButton;

        public FiringRangeState(IGameStateMachine gameStateMachine, IEntityContainer entityContainer, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _entityContainer = entityContainer;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            CacheEntities();
            _firingRangeGame.OnEnd += FinishFiringRange;
            _startButton.OnClick.AddListener(StartOrStopFiringRange);
            _loadingCurtain.Hide();
        }

        public void Exit()
        {
            _startButton.OnClick.RemoveListener(StartOrStopFiringRange);
            _firingRangeGame.OnEnd -= FinishFiringRange;
        }

        private void CacheEntities()
        {
            _firingRangeGame = _entityContainer.GetEntity<FiringRangeGame>();
            _startButton = _entityContainer.GetEntity<XRButton>();
        }

        private void StartOrStopFiringRange()
        {
            if(_firingRangeGame.IsPlaying) _firingRangeGame.Stop();
            else _firingRangeGame.Start();
        }

        private void FinishFiringRange()
        {
            
        }
    }
}
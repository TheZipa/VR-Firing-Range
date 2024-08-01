using FiringRange.Code.Infrastructure.StateMachine.GameStateMachine;
using FiringRange.Code.Logic.Common;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.LoadingCurtain;

namespace FiringRange.Code.Infrastructure.StateMachine.States
{
    public class FiringRangeState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IEntityContainer _entityContainer;
        private readonly ILoadingCurtain _loadingCurtain;

        private FiringRangeGame _firingRangeGame;

        public FiringRangeState(IGameStateMachine gameStateMachine, IEntityContainer entityContainer, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _entityContainer = entityContainer;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            CacheEntities();
            _loadingCurtain.Hide();
            _firingRangeGame.Start();
        }

        public void Exit()
        {
            
        }

        private void CacheEntities()
        {
            _firingRangeGame = _entityContainer.GetEntity<FiringRangeGame>();
        }
    }
}
using FiringRange.Code.Infrastructure.StateMachine.GameStateMachine;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.LoadingCurtain;

namespace FiringRange.Code.Infrastructure.StateMachine.States
{
    public class GameplayState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IEntityContainer _entityContainer;
        private readonly ILoadingCurtain _loadingCurtain;

        public GameplayState(IGameStateMachine gameStateMachine, IEntityContainer entityContainer, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _entityContainer = entityContainer;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            _loadingCurtain.Hide();
        }

        public void Exit()
        {
            
        }
    }
}
using FiringRange.Code.Infrastructure.StateMachine.GameStateMachine;
using FiringRange.Code.Services.Factories.GameFactory;
using FiringRange.Code.Services.LoadingCurtain;
using FiringRange.Code.Services.SaveLoad;
using FiringRange.Code.Services.StaticData;

namespace FiringRange.Code.Infrastructure.StateMachine.States
{
    public class LoadApplicationState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticData _staticData;
        private readonly ISaveLoad _saveLoad;
        private readonly IGameFactory _gameFactory;
        private readonly ILoadingCurtain _loadingCurtain;

        public LoadApplicationState(IGameStateMachine gameStateMachine, IStaticData staticData, ISaveLoad saveLoad,
            IGameFactory gameFactory, ILoadingCurtain loadingCurtain)
        {
            _staticData = staticData;
            _saveLoad = saveLoad;
            _gameFactory = gameFactory;
            _loadingCurtain = loadingCurtain;
            _gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
            _saveLoad.Load();
        }

        public void Exit()
        {
        }
    }
}
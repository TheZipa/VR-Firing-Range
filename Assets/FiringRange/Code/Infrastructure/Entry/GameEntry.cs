using FiringRange.Code.Infrastructure.StateMachine.GameStateMachine;
using FiringRange.Code.Infrastructure.StateMachine.States;
using FiringRange.Code.Services.Factories.StateFactory;
using VContainer.Unity;

namespace FiringRange.Code.Infrastructure.Entry
{
    public class GameEntry : IStartable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStateFactory _stateFactory;

        public GameEntry(IGameStateMachine gameStateMachine, IStateFactory stateFactory)
        {
            _gameStateMachine = gameStateMachine;
            _stateFactory = stateFactory;
        }
        
        public void Start()
        {
            _stateFactory.CreateAllStates();
            _gameStateMachine.Enter<LoadApplicationState>(); 
        }
    }
}
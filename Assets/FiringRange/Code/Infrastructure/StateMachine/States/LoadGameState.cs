using Cysharp.Threading.Tasks;
using FiringRange.Code.Infrastructure.StateMachine.GameStateMachine;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.Factories.GameFactory;
using FiringRange.Code.Services.LoadingCurtain;
using FiringRange.Code.Services.SceneLoader;

namespace FiringRange.Code.Infrastructure.StateMachine.States
{
    public class LoadGameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IEntityContainer _entityContainer;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private const string GameScene = "Game";

        public LoadGameState(IGameStateMachine gameStateMachine, IGameFactory gameFactory,
            IEntityContainer entityContainer, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _entityContainer = entityContainer;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(GameScene, CreateGame);
        }

        public void Exit()
        {
        }

        private async void CreateGame()
        {
            await InitializeGameplay();
            FinishLoad();
        }
        private async UniTask InitializeGameplay()
        {
            await _gameFactory.WarmUp();
        }

        private void FinishLoad() => _gameStateMachine.Enter<GameplayState>();
    }
}
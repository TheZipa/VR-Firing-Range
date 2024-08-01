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
        private readonly IEntityContainer _entityContainer;
        private readonly IGameFactory _gameFactory;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private const string GameScene = "FiringRange";

        public LoadGameState(IGameStateMachine gameStateMachine, IGameFactory gameFactory,
            IEntityContainer entityContainer, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _entityContainer = entityContainer;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
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
            await _gameFactory.CreateXRPlayer();
            _gameFactory.CreateDecalPlacement();
            await _gameFactory.CreatePistol();
            await _gameFactory.CreateFiringRangeGame();
        }

        private void FinishLoad() => _gameStateMachine.Enter<FiringRangeState>();
    }
}
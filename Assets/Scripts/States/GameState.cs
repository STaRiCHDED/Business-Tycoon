using System;
using Events;
using IngameStateMachine;
using Services;
using Views;

namespace States
{
    public class GameState : IState
    {
        private readonly GameScreen _gameScreen;
        private readonly BusinessesSpawner _businessesSpawner;
        private StateMachine _stateMachine;
        private IDisposable _subscription;

        public GameState(GameScreen gameScreen, BusinessesSpawner businessesSpawner)
        {
            _gameScreen = gameScreen;
            _businessesSpawner = businessesSpawner;
        }

        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            StartGame();
            _gameScreen.Show();
            _subscription = EventStreams.Game.Subscribe<ExitToMainMenuEvent>(OnExitToMainMenu);
        }

        public void OnExit()
        {
            _businessesSpawner.DeleteControllers();
            _gameScreen.Hide();
            Dispose();
        }

        public void Dispose()
        {
            _subscription?.Dispose();
        }

        private void OnExitToMainMenu(ExitToMainMenuEvent obj)
        {
            var fileService = ServiceLocator.Instance.GetSingle<IFileService>();
            var gameDataProvider = ServiceLocator.Instance.GetSingle<IGameDataProvider>();

            var saveData = gameDataProvider.GetCurrentData();
            fileService.Save(saveData);

            _stateMachine.Enter<StartState>();
        }

        private void StartGame()
        {
            var fileService = ServiceLocator.Instance.GetSingle<IFileService>();
            var configService = ServiceLocator.Instance.GetSingle<IConfigService>();
            var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();

            var saveDataModel = fileService.Load();
            if (saveDataModel != null)
            {
                var businessModels = configService.GetBusinessModels(saveDataModel.BusinessModels);
                balanceService.PlayerBalanceModel = saveDataModel.PlayerBalanceModel;
                _businessesSpawner.Spawn(businessModels);
            }
            else
            {
                var businessModels = configService.GetBusinessModels();
                balanceService.PlayerBalanceModel = configService.CreatePlayerBalanceModel(0);
                _businessesSpawner.Spawn(businessModels);
            }
        }
    }
}
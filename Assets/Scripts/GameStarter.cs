using IngameStateMachine;
using Services;
using States;
using UnityEngine;
using Views;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private GameScreen _gameScreen;

    [SerializeField]
    private StartScreen _startScreen;

    [SerializeField]
    private BusinessesSpawner _businessesSpawner;

    private StateMachine _stateMachine;

    private void Awake()
    {
        var initializationState = new InitializationState();
        initializationState.RegisterServices();

        var startState = new StartState(_startScreen);
        var gameState = new GameState(_gameScreen, _businessesSpawner);

        _stateMachine = new StateMachine(initializationState, startState, gameState);
        _stateMachine.Initialize();
        _stateMachine.Enter<InitializationState>();
    }

    private void SaveGame()
    {
        var fileService = ServiceLocator.Instance.GetSingle<IFileService>();
        var gameDataProvider = ServiceLocator.Instance.GetSingle<IGameDataProvider>();
        var saveData = gameDataProvider.GetCurrentData();
        fileService.Save(saveData);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Dispose();
        SaveGame();
    }
}
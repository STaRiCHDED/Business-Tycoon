using System;
using Events;
using IngameStateMachine;
using Services;
using SimpleEventBus.Disposables;
using UnityEditor;
using Views;

public class StartState : IState
{
    private readonly StartScreen _startScreen;
    private StateMachine _stateMachine;

    private CompositeDisposable _subscription;

    public StartState(StartScreen startScreen)
    {
        _startScreen = startScreen;
    }

    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        _startScreen.Show();
        _subscription = new CompositeDisposable
        {
            EventStreams.Game.Subscribe<ExitGameEvent>(OnExitGame),
            EventStreams.Game.Subscribe<StartNewGameEvent>(OnStartNewGame),
            EventStreams.Game.Subscribe<ContinueGameEvent>(OnContinueGame),
        };
    }
    
    public void OnExit()
    {
        _startScreen.Hide();
        Dispose();
    }

    public void Dispose()
    {
        _subscription?.Dispose();
    }

    private void OnStartNewGame(StartNewGameEvent obj)
    {
        var fileService = ServiceLocator.Instance.GetSingle<IFileService>();
        var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
        
        balanceService.ResetBalance();
        fileService.Delete();
        _stateMachine.Enter<GameState>();
    }
    
    private void OnContinueGame(ContinueGameEvent obj)
    {
        _stateMachine.Enter<GameState>();
    }

    
    private void OnExitGame(ExitGameEvent obj)
    {
        var fileService = ServiceLocator.Instance.GetSingle<IFileService>();
        var gameDataProvider = ServiceLocator.Instance.GetSingle<IGameDataProvider>();

        var saveData = gameDataProvider.GetCurrentData();
        fileService.Save(saveData);

        EditorApplication.isPlaying = false;
    }
}
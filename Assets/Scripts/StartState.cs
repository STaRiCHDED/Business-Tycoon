using Events;
using IngameStateMachine;
using Models;
using Services;
using SimpleEventBus.Disposables;
using UnityEditor;
using Views;

public class StartState : IState
{
    private readonly StartScreen _startScreen;
    private readonly SaveDataModel _saveDataModel;
    private CompositeDisposable _subscriptions;
    private StateMachine _stateMachine;
    
    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public StartState(StartScreen startScreen, SaveDataModel saveDataModel)
    {
        _startScreen = startScreen;
        _saveDataModel = saveDataModel;
    }

    public void OnEnter()
    {
        _startScreen.Show();
        _subscriptions = new CompositeDisposable
        {
            EventStreams.Game.Subscribe<StartNewGameEvent>(OnStartNewGame),
            EventStreams.Game.Subscribe<ContinueGameEvent>(OnContinueGame),
            EventStreams.Game.Subscribe<ExitGameEvent>(OnExitGame)
        };

    }

    private void OnExitGame(ExitGameEvent obj)
    {
        ServiceLocator.Instance.GetSingle<IFileService>().Save(_saveDataModel);
        EditorApplication.isPlaying = false;
    }

    private void OnContinueGame(ContinueGameEvent obj)
    {
        _stateMachine.Enter<GameState>();
    }

    private void OnStartNewGame(StartNewGameEvent obj)
    {
        var fileService = ServiceLocator.Instance.GetSingle<IFileService>();
        fileService.Delete();
        _stateMachine.Enter<GameState>();
    }

    public void OnExit()
    {
        _startScreen.Hide();
    }
    
    public void Dispose()
    {
        _subscriptions?.Dispose();
    }

}
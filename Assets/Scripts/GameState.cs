using System;
using System.Runtime.Serialization.Formatters;
using Events;
using IngameStateMachine;
using Models;
using Services;
using Views;

public class GameState : IState
{
    private readonly BusinessesSpawner _businessesSpawner;
    private SaveDataModel _saveDataModel;
    private readonly GameScreen _gameScreen;
    private IDisposable _subscription;

    private StateMachine _stateMachine;

    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public GameState(BusinessesSpawner businessesSpawner, SaveDataModel saveDataModel, GameScreen gameScreen)
    {
        _businessesSpawner = businessesSpawner;
        _saveDataModel = saveDataModel;
        _gameScreen = gameScreen;
    }

    public void OnEnter()
    {
        _gameScreen.Show();
        _saveDataModel = ServiceLocator.Instance.GetSingle<IFileService>().Load();
        _businessesSpawner.Spawn(_saveDataModel.BusinessModels);

        _subscription = EventStreams.Game.Subscribe<ExitToMainMenuEvent>(OnExitToMainMenu);
    }

    
    public void OnExit()
    {
        _gameScreen.Hide();
        
    }

    public void Dispose()
    {
        _subscription?.Dispose();
    }
    
    private void OnExitToMainMenu(ExitToMainMenuEvent obj)
    {
        var fileService = ServiceLocator.Instance.GetSingle<IFileService>();
        fileService.Save(_saveDataModel);
        _stateMachine.Enter<StartState>();
    }

}
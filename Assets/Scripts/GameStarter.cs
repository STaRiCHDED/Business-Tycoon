using System;
using IngameStateMachine;
using Models;
using Services;
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
        var serviceLocator = initializationState.RegisterServices();

        var fileService = serviceLocator.GetSingle<IFileService>();
        
        var saveDataModel = fileService.Load();
        serviceLocator.RegisterSingle<IBalanceService>(new BalanceService(saveDataModel.PlayerBalanceModel));
        
        
        var startState = new StartState(_startScreen,saveDataModel);
        var gameState = new GameState(_businessesSpawner, saveDataModel,_gameScreen);
        _stateMachine = new StateMachine(initializationState,startState, gameState);
        _stateMachine.Initialize();
        _stateMachine.Enter<InitializationState>();
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Dispose();
    }
}
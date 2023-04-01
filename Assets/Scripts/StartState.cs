using IngameStateMachine;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : IState
{
    private StateMachine _stateMachine;


    public void Dispose()
    {
    }

    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        SceneManager.LoadSceneAsync("game_scene");
    }

    public void OnExit()
    {
    }
}
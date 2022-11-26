using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameStateType
{
    None,
    Prepare,
    Start,
    Play,
    End
}

public class GameStateParamsBase
{
    public EGameStateType StateType { get; set; }
}



public class GameStateBase
{
    protected GameStateParamsBase StateParams;
    public virtual void Start(GameStateParamsBase InParams)
    {
        StateParams = InParams;

#if UNITY_EDITOR
        KojeomLogger.DebugLog(string.Format("{0} State Start.", KojeomUtils.EnumToString(StateParams.StateType)));
#endif
    }

    public virtual void UpdateProcess(float InDeltaTime)
    {

    }

    public virtual void End()
    {
#if UNITY_EDITOR
        KojeomLogger.DebugLog(string.Format("{0} State End.", KojeomUtils.EnumToString(StateParams.StateType)));
#endif
    }

    public EGameStateType GetStateType() { return StateParams.StateType; }

    // 
    public GameStateManager GetStateManager() { return GameStateManager.Instance; }
}

public class GameStateManager
{
    public static GameStateManager Instance { get; private set; } = new GameStateManager();
    public GameStateBase CurrentGameState { get; private set; }

    private GameStateManager()
    {
        CurrentGameState = null;
    }

    public void ChangeState(GameStateParamsBase InParams)
    {
        if(CurrentGameState != null)
        {
            CurrentGameState.End();
        }

        switch (InParams.StateType)
        {
            case EGameStateType.None:
                break;
            case EGameStateType.Prepare:
                CurrentGameState = new GamePrepareState();
                break;
            case EGameStateType.Start:
                CurrentGameState = new GameStartState();
                break;
            case EGameStateType.Play:
                CurrentGameState = new GamePlayState();
                break;
            case EGameStateType.End:
                CurrentGameState = new GameEndState();
                break;
        }

        if (CurrentGameState != null)
        {
            CurrentGameState.Start(InParams);
        }
    }

    public void UpdateProcess(float InDeltaTime)
    {
        CurrentGameState.UpdateProcess(InDeltaTime);
    }
}
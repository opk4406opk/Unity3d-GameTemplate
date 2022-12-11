using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    public abstract void Initialize();
    public abstract void OnGamePrepare();
    public abstract void OnGameStart();
    public abstract void OnGamePlay();
    public abstract void OnGameEnd();
    public abstract void Release();
    public abstract void UpdateProcess(float InDeltaTime);
}


/// <summary>
/// 매니저 클래스 Base.
/// -> 게임 상태에 대한 OnEvent 함수를 정의한다.
/// </summary>
public abstract class ManagerBase : IManager
{
    public abstract void Initialize();
    public abstract void OnGameEnd();
    public abstract void OnGamePlay();
    public abstract void OnGamePrepare();
    public abstract void OnGameStart();
    public abstract void Release();
    public abstract void UpdateProcess(float InDeltaTime);
}

public abstract class MonoBehaviorManagerBase : MonoBehaviour, IManager
{
    public abstract void Initialize();
    public abstract void OnGameEnd();
    public abstract void OnGamePlay();
    public abstract void OnGamePrepare();
    public abstract void OnGameStart();
    public abstract void Release();
    public abstract void UpdateProcess(float InDeltaTime);
}

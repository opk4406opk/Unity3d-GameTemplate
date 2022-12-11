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
/// �Ŵ��� Ŭ���� Base.
/// -> ���� ���¿� ���� OnEvent �Լ��� �����Ѵ�.
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

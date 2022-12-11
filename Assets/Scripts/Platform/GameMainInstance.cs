using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagerHelper
{
    public static T Get<T>() where T : ManagerBase
    {
        return GameMainInstance.Instance.GetManager(typeof(T)) as T;
    }
}

/// <summary>
/// 게임 플랫폼에 대한 싱글턴 인스턴스.
/// </summary>
public class GameMainInstance
{
    public static GameMainInstance Instance { get; private set; } = new GameMainInstance();

    private Dictionary<System.Type, ManagerBase> ManagerMap;

    private GameMainInstance()
    {
        Initialize();
    }

    public ManagerBase GetManager(System.Type InClassType)
    {
        ManagerBase OutManager;
        ManagerMap.TryGetValue(InClassType, out OutManager);

        return OutManager;
    }

    public void Initialize()
    {
        ManagerMap = new Dictionary<System.Type, ManagerBase>();

        // 매니저 생성.


        // 매니저 초기화.
        foreach(var ManagerInst in ManagerMap.Values)
        {
            ManagerInst.Initialize();
        }
    }

    public void OnGameEnd()
    {
        foreach (var ManagerInst in ManagerMap.Values)
        {
            ManagerInst.OnGameEnd();
        }
    }

    public void OnGamePlay()
    {
        foreach (var ManagerInst in ManagerMap.Values)
        {
            ManagerInst.OnGamePlay();
        }
    }

    public void OnGamePrepare()
    {
        foreach (var ManagerInst in ManagerMap.Values)
        {
            ManagerInst.OnGamePrepare();
        }
    }

    public void OnGameStart()
    {
        foreach (var ManagerInst in ManagerMap.Values)
        {
            ManagerInst.OnGameStart();
        }
    }

    public void Release()
    {
        foreach (var ManagerInst in ManagerMap.Values)
        {
            ManagerInst.Release();
        }
    }

}

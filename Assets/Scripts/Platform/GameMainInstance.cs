using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플랫폼에 대한 싱글턴 인스턴스.
/// </summary>
public class GameMainInstance
{
    public static GameMainInstance Instance { get; private set; } = new GameMainInstance();

    private List<ManagerBase> ManagerList;

    private GameMainInstance()
    {
        Initialize();
    }

    public void Initialize()
    {
        ManagerList = new List<ManagerBase>();

        // 매니저 생성.


        // 매니저 초기화.
        foreach(var ManagerInst in ManagerList)
        {
            ManagerInst.Initialize();
        }
    }

}

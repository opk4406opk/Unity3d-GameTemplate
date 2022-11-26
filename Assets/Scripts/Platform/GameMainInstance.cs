using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �÷����� ���� �̱��� �ν��Ͻ�.
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

        // �Ŵ��� ����.


        // �Ŵ��� �ʱ�ȭ.
        foreach(var ManagerInst in ManagerList)
        {
            ManagerInst.Initialize();
        }
    }

}

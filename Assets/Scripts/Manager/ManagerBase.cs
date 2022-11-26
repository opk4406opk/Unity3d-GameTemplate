using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 매니저 클래스 Base.
/// -> 게임 상태에 대한 OnEvent 함수를 정의한다.
/// </summary>
public abstract class ManagerBase
{
    public virtual void Initialize()
    {

    }

    public virtual void OnGamePrepare()
    {

    }

    public virtual void OnGameStart()
    {

    }

    public virtual void OnGamePlay()
    {

    }

    public virtual void OnGameEnd()
    {

    }

    public virtual void Release()
    {

    }
}

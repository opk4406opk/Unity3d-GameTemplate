using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class UIManager : ManagerBase
{
    private Dictionary<System.Type, List<MethodInfo>> Events = new Dictionary<System.Type, List<MethodInfo>>();

    public override void Initialize()
    {
        Events.Clear();
    }

    public void SubscribeEvents(System.Type InType, List<MethodInfo> InEventMethods)
    {
        List<MethodInfo> OutEventMetohds;
        if(Events.TryGetValue( InType, out OutEventMetohds))
        {
            OutEventMetohds.AddRange(InEventMethods);
        }
    }

    public override void OnGameEnd()
    {
    }

    public override void OnGamePlay()
    {
    }

    public override void OnGamePrepare()
    {
    }

    public override void OnGameStart()
    {
    }

    public override void Release()
    {
        Events.Clear();
    }

    public override void UpdateProcess(float InDeltaTime)
    {
    }
}

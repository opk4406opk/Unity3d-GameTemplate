using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public struct UIEventData
{
    public object Owner;
    public MethodInfo Method;
}

public class UIManager : ManagerBase
{
    private Dictionary<System.Type, List<UIEventData>> EventMap = new Dictionary<System.Type, List<UIEventData>>();

    public override void Initialize()
    {
        EventMap.Clear();
    }

    public void SubscribeEvents(System.Type InType, Dictionary<MethodInfo, UIEventData> InEventMethodHandler)
    {
        List<UIEventData> OutEventDataList;
        if(EventMap.TryGetValue(InType, out OutEventDataList))
        {
            OutEventDataList.AddRange(InEventMethodHandler.Values);
        }
    }

    public void BroadcastEvent<T>(T InEventType, object[] InEvent) where T : System.Type
    {
        List<UIEventData> OutEventDataList;
        if (EventMap.TryGetValue(InEventType, out OutEventDataList))
        {
            foreach(var EventData in OutEventDataList)
            {
                EventData.Method.Invoke(EventData.Owner, InEvent);
            }
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
        EventMap.Clear();
    }

    public override void UpdateProcess(float InDeltaTime)
    {
    }
}

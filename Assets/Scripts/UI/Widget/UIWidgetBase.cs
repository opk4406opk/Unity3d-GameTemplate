using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class UIWidgetBase : MonoBehaviour
{
    protected RectTransform _RectTransform;

    public virtual void UpdateWidget()
    {

    }

    public void Activate(bool active)
    {
        gameObject.SetActive(active);
    }

    public virtual void Initialize()
    {
        Activate(false);
        SubscribeEvents();
    }

    public virtual void Open()
    {
        Activate(true);
    }

    public virtual void Close()
    {
        Activate(false);
        Release();
    }

    protected virtual void Release()
    {

    }

    protected void ResetRectTransform()
    {
        _RectTransform.sizeDelta = Vector2.zero;
        _RectTransform.rect.Set(0.0f, 0.0f, 0.0f, 0.0f);
        _RectTransform.offsetMin = Vector2.zero;
        _RectTransform.offsetMax = Vector2.zero;
        _RectTransform.localScale = Vector2.one;
        _RectTransform.ForceUpdateRectTransforms();
    }

    protected void SubscribeEvents()
    {
        System.Type ThisType = GetType();
        System.Type EventTargetType = null;

        Dictionary<MethodInfo, UIEventData> EventsHandlerMap = new Dictionary<MethodInfo, UIEventData>();

        var MethodInfos = ThisType.GetMethods();
        foreach(var Info in MethodInfos)
        {
            string MethodName = Info.Name;
            if(MethodName.Contains("Event_"))
            {
                ParameterInfo[] Parameters = Info.GetParameters();
                if(Parameters.Length > 0)
                {
                    ParameterInfo Parameter = Parameters[0];
                    if (Parameter != null)
                    {
                        if(Parameter.GetType().IsStruct())
                        {
                            EventTargetType = Parameter.GetType();
                        }
                    }

                    UIEventData EventData = new UIEventData()
                    {
                        Method = Info,
                        Owner = this
                    };
                    EventsHandlerMap.Add(Info, EventData);
                }
               
            }
        }

        if(EventsHandlerMap.Count > 0)
        {
            var UIManager = ManagerHelper.Get<UIManager>();
            UIManager.SubscribeEvents(EventTargetType, EventsHandlerMap);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

        List<MethodInfo> EventMethods = new List<MethodInfo>();

        var MethodInfos = ThisType.GetMethods();
        foreach(var Info in MethodInfos)
        {
            string MethodName = Info.Name;
            if(MethodName.Contains("Event_"))
            {
                EventMethods.Add(Info);
            }
        }

        var UIManager = ManagerHelper.Get<UIManager>();
        UIManager.SubscribeEvents(ThisType, EventMethods);
    }
}

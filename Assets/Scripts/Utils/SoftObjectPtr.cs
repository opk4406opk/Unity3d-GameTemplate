using System;
using UnityEngine;

public class SoftObjectPtr
{
    public string ObjectPath;
    private GameObject Obj;

    public SoftObjectPtr(string objectPath)
    {
        ObjectPath = objectPath;
    }

    public SoftObjectPtr()
    {
        ObjectPath = "";
    }

    public GameObject LoadSynchro()
    {
        if (Obj == null)
        {
            Obj = Resources.Load<GameObject>(ObjectPath);
        }
        return Obj;
    }

    public GameObject Get()
    {
        return Obj;
    }

    public void LoadAsynchro(Action<GameObject> completeCallback)
    {
        var req = Resources.LoadAsync<GameObject>(ObjectPath);
        req.completed += (AsyncOperation) =>
        {
            Obj = req.asset as GameObject;
            completeCallback.Invoke(Obj);
        };
    }

    public bool IsValid()
    {
        if (Obj == null)
        {
            return false;
        }
        return true;
    }

    public void Release()
    {
        ObjectPath = string.Empty;
        Resources.UnloadAsset(Obj);
        Obj = null;
    }
}

public class TSoftObjectPtr<T> where T : UnityEngine.Object
{
    public string ObjectPath;
    private T Obj;

    public TSoftObjectPtr(string objectPath)
    {
        ObjectPath = objectPath;
    }

    public TSoftObjectPtr()
    {
        ObjectPath = "";
    }

    public T LoadSynchro()
    {
        if (Obj == null)
        {
            Obj = Resources.Load<T>(ObjectPath);
        }
        return Obj;
    }

    public T Get()
    {
        return Obj;
    }

    public bool IsValid()
    {
        if (Obj == null)
        {
            return false;
        }
        return true;
    }

    public void Release()
    {
        ObjectPath = string.Empty;
        Resources.UnloadAsset(Obj);
        Obj = null;
    }
}
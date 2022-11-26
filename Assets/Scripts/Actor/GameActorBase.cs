using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActorBase : MonoBehaviour
{
    protected GameActorController ActorController;

#if UNITY_EDITOR
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        BeginPlay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProcess(Time.deltaTime);
    }
#endif

    protected virtual void Initialize()
    {
        ActorController = gameObject.AddComponent<GameActorController>();
        ActorController.Initialize(this);
    }

    public virtual void BeginPlay()
    {
        ActorController.BeginPlay();
    }

    public virtual void EndPlay()
    {
        ActorController.EndPlay();
    }

    public virtual void StopPlay()
    {
        ActorController.StopPlay();
    }

    public virtual void UpdateProcess(float InDeltaTime)
    {
        ActorController.UpdateProcess(InDeltaTime);
    }

}

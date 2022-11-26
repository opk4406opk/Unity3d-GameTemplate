using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameActorComponentBase
{
    protected GameActorBase Owner;
    protected bool bCanUpdate;
    public virtual void Initialize(GameActorBase InOwner)
    {
        Owner = InOwner;
        EnableTick(false);
    }

    public virtual void BeginPlay()
    {

    }

    public virtual void EndPlay()
    {

    }

    public virtual void StopPlay()
    {

    }

    public virtual void UpdateProcess(float InDeltaTime)
    {
        if(bCanUpdate == false)
        {
            return;
        }
    }

    public void EnableTick(bool InEnable)
    {
        bCanUpdate = InEnable;
    }
}

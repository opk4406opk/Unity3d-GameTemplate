using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputProcessorBase
{
    protected GameActorBase Owner;
    protected bool bActive;
  
    public virtual void Initialize(GameActorBase InOwner)
    {
        Owner = InOwner;
        Activate(false);
    }
    public virtual void Release()
    {

    }
    public abstract void UpdateProcess(float InDeltaTime);
    public virtual bool OnUpdateInput(UserInputData InInputData, float InDetalTime)
    {
        return bActive;
    }

    public void Activate(bool InActive)
    {
        bActive = InActive;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameActorController
{
    public abstract void Initialize(GameActorBase InOwner);

    public abstract void BeginPlay();

    public abstract void EndPlay();

    public abstract void StopPlay();

    public abstract void UpdateProcess(float InDeltaTime);
}

public class GameActorController : CharacterController, IGameActorController
{
    protected GameActorBase Owner;
    protected bool bCanUpdate;

    public void Initialize(GameActorBase InOwner)
    {
        Owner = InOwner;
        EnableTick(false);
    }

    public void BeginPlay()
    {
    }

    public void EndPlay()
    {
    }

    public void StopPlay()
    {
    }

    public void UpdateProcess(float InDeltaTime)
    {
        if (bCanUpdate == false)
        {
            return;
        }
    }

    public void EnableTick(bool InEnable)
    {
        bCanUpdate = InEnable;
    }
}

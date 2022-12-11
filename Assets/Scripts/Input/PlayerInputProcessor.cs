using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputProcessor : InputProcessorBase
{
    public override void Initialize(GameActorBase InOwner)
    {
        base.Initialize(InOwner);
    }

    public override bool OnUpdateInput(UserInputData InInputData, float InDetalTime)
    {
        return base.OnUpdateInput(InInputData, InDetalTime);
    }

    public override void Release()
    {
        base.Release();
    }

    public override void UpdateProcess(float InDeltaTime)
    {
        throw new System.NotImplementedException();
    }
}

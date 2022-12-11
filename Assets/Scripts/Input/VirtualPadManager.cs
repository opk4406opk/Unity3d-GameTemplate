using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct JoystickData
{
    public Vector2 StickDirection;
    public EJoystickState State;
}

public enum EJoystickState
{
    None,
    Moved,
}

public class VirtualPadManager : MonoBehaviorManagerBase
{
    [SerializeField]
    private Image Image_Back;
    [SerializeField]
    private Image Image_Front;
    [SerializeField]
    private BoxCollider2D StickClampArea;
    [SerializeField]
    private BoxCollider2D StickBoundary;

    public bool IsEnable { get; private set; }
    private JoystickData CurrentStickData;
    private float DeltaTime;
    public float TouchSpeed { get; private set; } = 5.0f;

    public override void Initialize()
    {
        StickClampArea.GetComponent<Image>().enabled = false;
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        StickClampArea.GetComponent<Image>().enabled = true; // for debug.
#endif 
        CurrentStickData = new JoystickData()
        {
            StickDirection = Vector2.zero,
            State = EJoystickState.None
        };
    }

    public override void Release()
    {
    }

    public void Activate()
    {
        IsEnable = true;
    }

    public void Deactivate()
    {
        IsEnable = false;
        ResetMoveStick();
    }

    public JoystickData GetStickData()
    {
        return CurrentStickData;
    }

    public override void UpdateProcess(float InDeltaTime)
    {
        if(IsEnable == false) { return; }

        DeltaTime = InDeltaTime;
        if (InputWrapper.Input.TouchCount > 0)
        {
            foreach(var Touch in InputWrapper.Input.Touches)
            {
                TouchProcess(Touch);
            }
        }
        else
        {
            ResetMoveStick();
        }
    }

    private void TouchProcess(Touch InTouch)
    {
        if (StickBoundary.bounds.Contains(InTouch.position) == false)
        {
            ResetMoveStick();
        }
        else
        {
            MoveStickProcess(InTouch);
        }
    }

    private void MoveStickProcess(Touch InTouch)
    {
        switch (InTouch.phase)
        {
            case TouchPhase.Began:
                ResetMoveStick();
                break;
            case TouchPhase.Moved:
                CalcStickPosition(InTouch);
                break;
            case TouchPhase.Stationary:
                CalcStickPosition(InTouch);
                break;
            case TouchPhase.Ended:
                ResetMoveStick();
                break;
            case TouchPhase.Canceled:
                ResetMoveStick();
                break;
        }
    }

    private void CalcStickPosition(Touch InTouch)
    {
        Vector2 Origin = Image_Front.rectTransform.position;
        Vector2 TouchDirection = Vector2.zero;

        Bounds Boundary = StickClampArea.bounds;
        
        Vector2 NewPos = Vector2.Lerp(Origin, InTouch.position, DeltaTime * TouchSpeed);
        // position clamp.
        NewPos.x = Mathf.Clamp(NewPos.x, Boundary.min.x, Boundary.max.x);
        NewPos.y = Mathf.Clamp(NewPos.y, Boundary.min.y, Boundary.max.y);

        Image_Front.rectTransform.position = NewPos;
        TouchDirection = InTouch.position - new Vector2(Image_Back.rectTransform.position.x, Image_Back.rectTransform.position.y);
        CurrentStickData.StickDirection = TouchDirection.normalized;
        CurrentStickData.State = EJoystickState.Moved;
    }

    private void ResetMoveStick()
    {
        Image_Front.rectTransform.position = Image_Back.rectTransform.position;
        CurrentStickData.StickDirection = Vector2.zero;
        CurrentStickData.State = EJoystickState.None;
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
}

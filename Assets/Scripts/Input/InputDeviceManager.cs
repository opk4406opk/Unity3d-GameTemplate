using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EDeviceInputType
{
    EditorOrPlayer,
    Mobile
}

public enum EInputState
{
    None,
    Valid,
}

public struct UserInputData
{
    public EInputState State;
    public Vector2 MoveDirection;

    public bool IsValid()
    {
        return State != EInputState.None;
    }
}


public class InputDeviceManager : ManagerBase
{
    public UserInputData LastestInputData { get; private set; }
    private class InputParser
    {
        private InputDeviceManager DeviceManager;
        public void Init(InputDeviceManager InDeviceManager)
        {
            DeviceManager = InDeviceManager;
        }
        public void UpdateProcess(float InDeltaTime, Action<UserInputData> InCallback)
        {
            if (DeviceManager.CurrentInputType == EDeviceInputType.EditorOrPlayer)
            {
                bool bKeyboard = false;
                UserInputData InputData = new UserInputData()
                {
                    State = EInputState.None,
                    MoveDirection = Vector2.zero
                };
                if (Input.GetKey(KeyCode.W))
                {
                    InputData.State = EInputState.Valid;
                    InputData.MoveDirection += new Vector2(0.0f, 1.0f);
                    bKeyboard = true;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    InputData.State = EInputState.Valid;
                    InputData.MoveDirection += new Vector2(0.0f, -1.0f);
                    bKeyboard = true;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    InputData.State = EInputState.Valid;
                    InputData.MoveDirection += new Vector2(-1.0f, 0.0f);
                    bKeyboard = true;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    InputData.State = EInputState.Valid;
                    InputData.MoveDirection += new Vector2(1.0f, 0.0f);
                    bKeyboard = true;
                }
                InputData.MoveDirection.Normalize();
#if UNITY_EDITOR
                if(bKeyboard == false)
                {
                    DeviceManager.VirtualPadManagerInst.UpdateProcess(InDeltaTime);
                    InputData.MoveDirection = DeviceManager.VirtualPadManagerInst.GetStickData().StickDirection.normalized;
                    InputData.State = DeviceManager.VirtualPadManagerInst.GetStickData().State == EJoystickState.Moved ? EInputState.Valid : EInputState.None;
                }
#endif
                InCallback(InputData);
            }
            else if(DeviceManager.CurrentInputType == EDeviceInputType.Mobile)
            {
                DeviceManager.VirtualPadManagerInst.UpdateProcess(InDeltaTime);

                UserInputData InputData = new UserInputData()
                {
                    State = EInputState.None,
                    MoveDirection = Vector2.zero
                };
                InputData.MoveDirection = DeviceManager.VirtualPadManagerInst.GetStickData().StickDirection.normalized;
                InputData.State = DeviceManager.VirtualPadManagerInst.GetStickData().State == EJoystickState.Moved ? EInputState.Valid : EInputState.None;
                InCallback(InputData);
            }
        }
    }
    public EDeviceInputType CurrentInputType { get; private set; }

    public delegate bool DelegateInputParam(UserInputData InInuputData, float InDeltaTime);

    public DelegateInputParam OnUpdateInput;

    public VirtualPadManager VirtualPadManagerInst { get; private set; }
    private InputParser Parser;

    public InputDeviceManager(VirtualPadManager joyStickManager)
    {
        VirtualPadManagerInst = joyStickManager;
        Parser = new InputParser();
    }

    public override void Initialize()
    {
        Parser.Init(this);
        VirtualPadManagerInst.Initialize();
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.Android:
                CurrentInputType = EDeviceInputType.Mobile;
                break;
            case RuntimePlatform.LinuxPlayer:
            case RuntimePlatform.LinuxEditor:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                CurrentInputType = EDeviceInputType.EditorOrPlayer;
                break;
        }
    }

    public override void Release()
    {
    }
    public override void UpdateProcess(float InDeltaTime)
    {
        Parser.UpdateProcess(InDeltaTime, (InInputData) => 
        {
            if (OnUpdateInput != null)
            {
                LastestInputData = InInputData;
                OnUpdateInput(InInputData, InDeltaTime); 
            }
        });
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

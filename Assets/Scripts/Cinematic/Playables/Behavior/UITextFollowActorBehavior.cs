using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[Serializable]
public class UITextFollowActorBehavior : CustomPlayableBehaviorBase
{
    private Text _uiInstance;
    private UITextFollowHelper _helper;
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);
        if(_helper == null)
        {
            _uiInstance = playerData as Text;
            _helper = _uiInstance.GetComponent<UITextFollowHelper>();
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(_helper._worldTarget.transform.position);
        screenPos.x += _helper._screenOffset.x;
        screenPos.y += _helper._screenOffset.y;
        _uiInstance.transform.position = screenPos;
    }

}

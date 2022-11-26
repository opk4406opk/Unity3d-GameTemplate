using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[Serializable]
public class UITextFaderBehavior : CustomPlayableBehaviorBase
{
    public Color _endColor = Color.white;

    private Color _startColor = Color.white;
    private Text _textInstance;
    private float _elapsedTimeSec = 0.0f;
    

    public override void OnGraphStart(Playable playable)
    {
        base.OnGraphStart(playable);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);

        if (_textInstance == null) 
        {
            _textInstance = playerData as Text;
            _startColor = _textInstance.color;
        }

        _elapsedTimeSec += info.deltaTime;
        _textInstance.color = Color.Lerp(_startColor, _endColor, (float)(_elapsedTimeSec / _playTimeSec));
    }
}

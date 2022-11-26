using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[Serializable]
public class UITextTypingBehavior : CustomPlayableBehaviorBase
{
    #region Property
    public Color _fontColor = Color.white;
    public int _fontSize = 32;
    public string _descriptionText;
    public bool _overrideSize = false;
    public bool _overrideColor = false;
    #endregion

    private Text _targetTextWidget;

    private float _intervalTimeSec = 0.0f;

    private int _charCount = 0;
    private float _elapsedTimeSec = 0.0f;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);

        _charCount = 1;
        // frame delta time 이 일정하지 않을 수 있으므로 여유분으로 1만큼 더 계산.
        _intervalTimeSec = (float)_playTimeSec / (_descriptionText.Length + 1);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);

        if (_targetTextWidget == null)
        {
            _targetTextWidget = playerData as Text;

            _targetTextWidget.text = "";

            if (_overrideColor)
            {
                _targetTextWidget.color = _fontColor;
            }

            if (_overrideSize)
            {
                _targetTextWidget.fontSize = _fontSize;
            }
        }

        float writingTimeSec = _intervalTimeSec * _charCount;

        _elapsedTimeSec += info.deltaTime;
        if (_elapsedTimeSec >= writingTimeSec)
        {
            if (_charCount <= _descriptionText.Length)
            {
                _targetTextWidget.text = _descriptionText.Substring(0, _charCount);
            }

            ++_charCount;
        }
    }
}

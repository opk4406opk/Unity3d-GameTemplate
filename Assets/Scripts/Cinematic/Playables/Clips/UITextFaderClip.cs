using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class UITextFaderClip : CustomPlayableAsset, ITimelineClipAsset
{
    public UITextFaderBehavior _behavior = new UITextFaderBehavior();
    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<UITextFaderBehavior>.Create(graph, _behavior);
        playable.GetBehaviour().SetPlayTime(_playTime);
        return playable;
    }
}

using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class UITextTypingClip : CustomPlayableAsset, ITimelineClipAsset
{
    public UITextTypingBehavior _behavior = new UITextTypingBehavior();
    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<UITextTypingBehavior>.Create(graph, _behavior);
        playable.GetBehaviour().SetPlayTime(_playTime);
        return playable;
    }
}

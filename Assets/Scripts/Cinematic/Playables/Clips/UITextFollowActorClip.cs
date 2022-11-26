using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class UITextFollowActorClip : CustomPlayableAsset, ITimelineClipAsset
{
    public UITextFollowActorBehavior _behavior = new UITextFollowActorBehavior();
    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<UITextFollowActorBehavior>.Create(graph, _behavior);
        playable.GetBehaviour().SetPlayTime(_playTime);
        return playable;
    }
}

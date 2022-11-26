using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CustomTrackAsset : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        foreach (var clip in GetClips())
        {
            var playableAsset = clip.asset as CustomPlayableAsset;
            if (playableAsset)
            {
                playableAsset.SetStartTime(clip.start);
                playableAsset.SetEndTime(clip.end);
                playableAsset.SetPlayTime(clip.duration);
            }
        }
        return base.CreateTrackMixer(graph, go, inputCount);
    }
}

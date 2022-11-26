using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CustomPlayableAsset : PlayableAsset
{
    protected double _start;
    protected double _end;
    protected double _playTime;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var p = ScriptPlayable<CustomPlayableBehaviorBase>.Create(graph);
        //var behavior = p.GetBehaviour();
        //behavior.SetPlayTime(_playTime);
        return p;
    }
    
    public void SetStartTime(double seconds)
    {
        _start = seconds;
    }
    public void SetEndTime(double seconds)
    {
        _end = seconds;
    }
    public void SetPlayTime(double seconds)
    {
        _playTime = seconds;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// https://blog.unity.com/technology/extending-timeline-a-practical-guide
public class CustomPlayableBehaviorBase : PlayableBehaviour
{
    protected double _playTimeSec = 0.0f;
    public void SetPlayTime(double seconds)
    {
        _playTimeSec = seconds;
    }
}

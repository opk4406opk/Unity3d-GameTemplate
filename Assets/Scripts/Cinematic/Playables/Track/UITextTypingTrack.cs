using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[TrackColor(0.1394896f, 0.4411765f, 0.3413077f)]
[TrackClipType(typeof(UITextTypingClip))]
[TrackBindingType(typeof(Text))]
public class UITextTypingTrack : CustomTrackAsset
{
    public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
    {
#if UNITY_EDITOR
        Text trackBinding = director.GetGenericBinding(this) as Text;
        if (trackBinding == null) { return; }
            

        var serializedObject = new UnityEditor.SerializedObject(trackBinding);
        var iterator = serializedObject.GetIterator();
        while (iterator.NextVisible(true))
        {
            if (iterator.hasVisibleChildren) { continue; }
                
            driver.AddFromName<Text>(trackBinding.gameObject, iterator.propertyPath);
        }
#endif
        base.GatherProperties(director, driver);
    }
}

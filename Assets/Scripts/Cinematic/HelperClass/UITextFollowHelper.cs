using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[Serializable]
public class UITextFollowHelper : MonoBehaviour
{
    public Transform _worldTarget;
    public Vector2 _screenOffset;
    public bool _autoFollow = false;

    private void Update()
    {
        if(_autoFollow == true)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(_worldTarget.position);
            screenPos.x += _screenOffset.x;
            screenPos.y += _screenOffset.y;
            transform.position = screenPos;
        }
    }
}

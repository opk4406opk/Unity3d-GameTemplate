using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTargetHelper : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Camera _camera;
    private float _zValue = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        _zValue = _camera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera == null) { return; }
        if (_target == null) { return; }

        Vector3 newPos = _target.position;
        newPos.z = _zValue;
        _camera.transform.position = newPos;
    }
}

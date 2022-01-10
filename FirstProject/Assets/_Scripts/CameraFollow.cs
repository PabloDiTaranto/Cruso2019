using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0.0f, 1.3f, -3.0f);

    private Transform _target;
    
    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = _target.TransformPoint(cameraOffset);
        transform.LookAt(_target);
    }
}

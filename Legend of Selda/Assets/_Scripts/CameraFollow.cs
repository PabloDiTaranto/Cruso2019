using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    private Vector3 targetPosition;

    public float cameraSpeed;

    private Camera theCamera;
    private Vector3 minLimits, maxLimits;
    public float halfHeight, halfWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeLimits(BoxCollider2D cameraLimits)
    {
        minLimits = cameraLimits.bounds.min;
        maxLimits = cameraLimits.bounds.max;
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight / Screen.height * Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.Clamp(target.transform.position.x,
            minLimits.x + halfWidth,
            maxLimits.x - halfWidth);

        float posY = Mathf.Clamp(target.transform.position.y,
            minLimits.y + halfHeight,
            maxLimits.y - halfHeight);
        
        targetPosition = new Vector3(posX,
                                    posY,
                                    transform.position.z);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}

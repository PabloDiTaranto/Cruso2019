using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private PlayerController _player;
    private CameraFollow _camera;
    public Vector2 facingDirection = Vector2.zero;
    public string uuid;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _camera = FindObjectOfType<CameraFollow>();

        if (!_player.nextUuid.Equals(uuid))
        {
            return;
        }

        _player.transform.position = transform.position;
        _camera.transform.position = new Vector3(transform.position.x,
                                    transform.position.y,
                                    _camera.transform.position.z);

        _player.lastMovement = facingDirection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

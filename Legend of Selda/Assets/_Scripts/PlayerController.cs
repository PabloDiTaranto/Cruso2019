using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical", WALK ="Walking",
                            LAST_H = "LastH", LAST_V = "LastV";

    private Animator _animator;

    private bool walking;
    
    private Vector2 lastMovement = Vector2.zero;

    private Rigidbody2D _rigidbody2D;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;
        
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
           // Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) 
                                              //* speed * Time.deltaTime, 0, 0);
            //transform.Translate(translation);

            _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw(AXIS_H) * speed, _rigidbody2D.velocity.y);

            walking = true;

            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }
        
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
           // Vector3 translation = new Vector3(0,Input.GetAxisRaw(AXIS_V) 
                                             // * speed * Time.deltaTime, 0);
           // transform.Translate(translation);
            
            walking = true;
            
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Input.GetAxisRaw(AXIS_V) * speed);


            lastMovement = new Vector2(0, Input.GetAxisRaw(AXIS_V));
        }
    }

    private void LateUpdate()
    {
        if (!walking)
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        _animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
        _animator.SetBool(WALK, walking);
        _animator.SetFloat(LAST_H, lastMovement.x);
        _animator.SetFloat(LAST_V, lastMovement.y);
    }
}

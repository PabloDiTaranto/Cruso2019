using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true, isTalking;
    
    public static bool playerCreated;
    
    public float speed = 5f;

    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical", WALK ="Walking",
                            LAST_H = "LastH", LAST_V = "LastV", ATT = "Attacking";

    private Animator _animator;

    private bool walking;
    private bool attacking;
    
    public Vector2 lastMovement = Vector2.zero;

    private Rigidbody2D _rigidbody2D;

    public string nextUuid;

    public float attackTime;
    private float attackTimeCounter;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        playerCreated = true;

        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            _rigidbody2D.velocity = Vector2.zero;
            return;
        }
        walking = false;

        if (!canMove)
        {
            return;
        }
        
        // _rigidbody2D.velocity = Vector2.zero;

        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter <= 0)
            {
                attacking = false;
                _animator.SetBool(ATT, false);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimeCounter = attackTime;
            _rigidbody2D.velocity = Vector2.zero;
            _animator.SetBool(ATT, true);
        }
        
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
           // Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) 
                                              //* speed * Time.deltaTime, 0, 0);
            //transform.Translate(translation);

            _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw(AXIS_H) , _rigidbody2D.velocity.y).normalized * speed;

            walking = true;

            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0,_rigidbody2D.velocity.y);
        }
        
        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
           // Vector3 translation = new Vector3(0,Input.GetAxisRaw(AXIS_V) 
                                             // * speed * Time.deltaTime, 0);
           // transform.Translate(translation);
            
            walking = true;
            
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Input.GetAxisRaw(AXIS_V)).normalized * speed;


            lastMovement = new Vector2(0, Input.GetAxisRaw(AXIS_V));
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);

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

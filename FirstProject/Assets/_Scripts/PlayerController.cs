using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 60f;

    private float _hInput, _vInput;

    private Rigidbody _rigidbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        
        /*
        transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        */
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rigidbody.MovePosition(transform.position + transform.forward * _vInput * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRot);
    }
}

using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 60f;
    public float jumpForce = 5f;

    private float _hInput, _vInput;

    private Rigidbody _rigidbody;

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    private CapsuleCollider _capsuleCollider;

    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootSpeed = 100f;

    private GameManager gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab,
                                shootPoint.position, 
                                shootPoint.rotation);

            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.velocity = shootPoint.forward * shootSpeed;

        }
        
        if (IsOnGround() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rigidbody.MovePosition(transform.position + transform.forward * _vInput * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRot);
        IsOnGround();
    }

    /// <summary>
    /// Chequea colision con el suelo
    /// </summary>
    /// <returns><c>true</c> Se esta tocando el suelo,
    /// <c>false</c> No se esta tocando el suelo
    /// </returns>
    private bool IsOnGround()
    {
        Bounds bounds = _capsuleCollider.bounds;
        Vector3 capsuleBottom = new Vector3(bounds.center.x,
                                            bounds.min.y,
                                            bounds.center.z);
        bool onTheGround = Physics.CheckCapsule(bounds.center,
                                                capsuleBottom,
                                                distanceToGround,
                                                groundLayer,
                                                QueryTriggerInteraction.Ignore);
        return onTheGround;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.PlayerHp--;
        }
    }
}

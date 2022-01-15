using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [Tooltip("Velocidad de movimiento del enemigo")]
    public float speed = 1f;

    private Rigidbody2D _rigidbody2D;

    public Vector2 directionToMove;

    private bool _bIsMoving;

    [Tooltip("Tiempo que tarda el enemigo entre pasos sucesivos")]
    public float timeBetweenSteps;
    private float _timeBetweenStepsCounter;

    [Tooltip("Tiempo que tarda el enemigo en dar un paso")]
    public float timeToMakeStep;
    private float _timeToMakeStepCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _timeBetweenStepsCounter = timeBetweenSteps * Random.Range(0.5f, 1.5f);
        _timeToMakeStepCounter = timeToMakeStep * Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_bIsMoving)
        {
            _timeToMakeStepCounter -= Time.deltaTime;
            _rigidbody2D.velocity = directionToMove * speed;

            if (_timeToMakeStepCounter < 0)
            {
                _bIsMoving = false;
                _timeBetweenStepsCounter = timeBetweenSteps;
                _rigidbody2D.velocity = Vector2.zero;
            }
        }
        else
        {
            _timeBetweenStepsCounter -= Time.deltaTime;
            if (_timeBetweenStepsCounter < 0)
            {
                _bIsMoving = true;
                _timeToMakeStepCounter = timeToMakeStep;
                directionToMove = new Vector2(Random.Range(-1,2), Random.Range(-1,2));
            }
        }
    }
}

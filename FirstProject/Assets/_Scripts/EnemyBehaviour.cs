using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;
    
    public Transform patrolRoute;

    [HideInInspector]
    public List<Transform> waypoints;

    [SerializeField]
    private int locationIndex = 0;

    private NavMeshAgent _navMeshAgent;

    private float _currentDelay = 0f;
    public float maxDelay = 0.5f;

    private int _lives = 3;

    public int EnemyLives
    {
        get
        {
            return _lives;
        }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Oh, me han matado");
            }
        }
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        InitializeWaypoints();
        MoveToNextWaypoint();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (_navMeshAgent.remainingDistance < 0.5f && !_navMeshAgent.pathPending)
        {
            _currentDelay += Time.deltaTime;
            if (_currentDelay > maxDelay)
            {
                _currentDelay = 0f;
                MoveToNextWaypoint();
            }
        }
    }


    private void InitializeWaypoints()
    {
        foreach (Transform wp in patrolRoute)
        {
            waypoints.Add(wp);
        }
    }

    private void MoveToNextWaypoint()
    {
        if (waypoints.Count == 0)
        {
            return;
        }
        _navMeshAgent.SetDestination(waypoints[locationIndex].position);
        locationIndex = (locationIndex + 1) % waypoints.Count;
        //locationIndex = Random.Range(0, waypoints.Count);
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log(("Jugador detectado"));
            _navMeshAgent.SetDestination(player.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log(("Jugador fuera de rango"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyLives--;
            Debug.Log("Daño recibido");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(NavMeshAgent))]
public class WayPointPatrol : MonoBehaviour
{

    public Transform[] waypoints;

    private NavMeshAgent _agent;

    private int _currIndex;

    public float speed;

    public float rotationSpeed = 120f;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        _agent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _currIndex++;
            _currIndex %= waypoints.Length;
            _agent.SetDestination(waypoints[_currIndex].position);
        }

        if (_agent.destination == waypoints[_currIndex].position)
        {
            _agent.speed = speed;
            _agent.angularSpeed = rotationSpeed;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dectection : MonoBehaviour
{
    public Transform player;

    private bool _isPlayerInRange;

    public GameEnd gameEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position;
            direction.y += 1f;
            
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform == player)
                {
                    gameEnd.CaughtPlayer();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInRange = false;
        }
    }
}

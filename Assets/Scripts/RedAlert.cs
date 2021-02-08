using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedAlert : MonoBehaviour
{
    public Transform player;

    public bool redAlert;

    public float range;

    public float fieldOfView;

    public UnityEvent RedAlert_event;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < range && Vector3.Dot(transform.position, player.position) > fieldOfView)
        {
            redAlert = true;
            RedAlert_event.Invoke();
        }

        else
        {
            redAlert = false;
        }
    }

    
}

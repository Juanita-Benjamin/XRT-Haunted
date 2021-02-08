using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AlertManager : MonoBehaviour
{
    public NavMeshAgent[] agents;

    private Light[] _lights;

    private Color _normalLight;

    public float timeOut = 5f;
    
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        agents = FindObjectsOfType<NavMeshAgent>();
        _lights = FindObjectsOfType<Light>();
        _normalLight = _lights[0].color;
        
    }

    public void OnRedAlert()
    {
        float timer = 0f;
        foreach (var agent in agents)
        {
            agent.SetDestination(player.position);
            agent.speed += 3f;
            agent.angularSpeed += 0.5f;
        }

        foreach (var light in _lights)
        {
            light.color = Color.red;
        }

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        float timer = 0f;

        while (timer < timeOut)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        EndAlert();
    }

    private void EndAlert()
    {
        foreach (var light in _lights)
        {
            light.color = _normalLight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

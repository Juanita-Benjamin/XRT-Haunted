using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool _isPaused = false;

    public CanvasGroup pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !_isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.alpha = 1f;
            _isPaused = true;
        }

       else if (Input.GetKeyDown(KeyCode.P) && _isPaused)
        {
            Time.timeScale = 1;
            pauseScreen.alpha = 0f;
            _isPaused = false;
        }
    }
}

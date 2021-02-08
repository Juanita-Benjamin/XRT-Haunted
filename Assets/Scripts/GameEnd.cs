using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour
{
    public float fadeDuration = 1f;

    public float displayImageDuration = 1f;

    public GameObject player;

    public CanvasGroup exitImage;

    public CanvasGroup caughtImage;

    private bool _isPlayerAtExit, _isPlayerCaught;

    private float _timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _isPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        _isPlayerCaught = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel(exitImage, false);
        }
        
        else if (_isPlayerCaught)
        {
            EndLevel(caughtImage, true);
        }
    }

    void EndLevel(CanvasGroup canvasGroup, bool restart)
    {
        _timer += Time.deltaTime;
        canvasGroup.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration + displayImageDuration)
        {
            if (restart)
            {
                Restart();
            }

            else
            {
                //End game or reload level
                SceneManager.LoadScene(0);
            }
            
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

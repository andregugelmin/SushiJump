using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void game_paused()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }
    private void OnApplicationPause(bool pause)
    {
        isPaused = true;
        Time.timeScale = 0;
    }
}

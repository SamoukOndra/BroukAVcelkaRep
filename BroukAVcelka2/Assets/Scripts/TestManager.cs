using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public bool gameIsPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!gameIsPaused)
            {
                gameIsPaused = true;
                Time.timeScale = 0;
            }
            else
            {
                gameIsPaused = false;
                Time.timeScale = 1;
            }
                
        }
    }
}

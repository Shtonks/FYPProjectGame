using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : Menu
{
    public GameObject pauseMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public override void Pause()
    {
        pauseMenuUI.SetActive(true);
        base.Pause();
    }

    public override void Resume()
    {
        pauseMenuUI.SetActive(false);
        base.Resume();
    }
}

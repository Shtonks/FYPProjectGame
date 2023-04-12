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
            if(!GameIsPaused && GameManager.menuOpen.Equals("")) {
                Pause();
                GameManager.menuOpen = "pauseMenu";
            } else if(GameManager.menuOpen.Equals("pauseMenu")) {
                Resume();
                GameManager.menuOpen = "";
            }
            Debug.Log("GameManager.menuOpen status in Pause menu: "+ GameManager.menuOpen);
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

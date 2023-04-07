using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Can be gotten from anywhere and GameIsPaused belongs to the class, not object
    public static bool GameIsPaused = false;

    public virtual void Pause() {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public virtual void Resume() {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu() {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("GameWorld");
    }
}

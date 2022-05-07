using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    public GameManager() {
        instance = this;
    }

    private void Start() {
        Time.timeScale = 0f;
    }

    public GameObject menu;
    public GameObject player;
    public EndGame End;

    public void OnStart() {
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart() {
        SceneManager.LoadScene(0);
    }
    public void Quit() {
        Application.Quit();
    }
}
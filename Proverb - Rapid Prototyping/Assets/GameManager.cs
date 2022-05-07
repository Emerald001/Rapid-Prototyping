using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;

    private void Awake() {
        instace = this;
    }

    public GameObject player;
    public GameObject surroudings;
    public int MaxburnableObjects;
    public int burnableObjects;
    public LoopThroughText loopThroughText;
    public Fade fade;

    private void Start() {
        MaxburnableObjects = surroudings.GetComponentsInChildren<IBurnable>().Length;
        burnableObjects = surroudings.GetComponentsInChildren<IBurnable>().Length;
    }

    private void Update() {
        burnableObjects = surroudings.GetComponentsInChildren<IBurnable>().Length;
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
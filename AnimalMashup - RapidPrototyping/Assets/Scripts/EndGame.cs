using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endGameCanvas;
    public bool end;

    private void OnTriggerEnter(Collider other) {
        endGameCanvas.SetActive(true);
        end = true;
    }
}
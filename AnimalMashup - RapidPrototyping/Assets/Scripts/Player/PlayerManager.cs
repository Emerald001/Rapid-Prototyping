using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private PlayerHealth health;
    private Movement movement;
    private Attack attack;

    [HideInInspector] public Animator animate;
    [SerializeField] private GameObject playerCanvas;

    private void Start() {
        animate = GetComponent<Animator>();
        health = GetComponent<PlayerHealth>();
        health.owner = this;
        movement = GetComponent<Movement>();
        movement.owner = this;
        attack = GetComponent<Attack>();
        attack.owner = this;
    }

    private void Update() {
        if (GameManager.instance.End.end) {
            Cursor.lockState = CursorLockMode.None;
            return;
        }

        if (health.Died) {
            animate.SetTrigger("Died");
            playerCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        
        if (!health.Stunned) {
            movement.OnUpdate();
            attack.OnUpdate();
        }
    }
}
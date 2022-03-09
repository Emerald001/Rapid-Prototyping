using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private HealthComponent health;
    private Movement movement;
    private Attack attack;

    private void OnEnable() {

    }
    private void OnDisable() {

    }

    private void Start() {
        health = GetComponent<HealthComponent>();
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
    }

    private void Update() {
        if (!health.Stunned) {
            movement.OnUpdate();
            attack.OnUpdate();
        }
    }
}
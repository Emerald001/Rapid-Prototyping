using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Visuals;

    private HealthComponent health;

    void Start() {
        health = GetComponent<HealthComponent>();
    }

    void Update() {
        if(!health.Stunned)
            Move();
    }

    private void Move() {
        //move towards player within certain range
    }
}
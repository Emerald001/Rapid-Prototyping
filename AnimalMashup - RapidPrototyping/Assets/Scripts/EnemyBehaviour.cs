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
        transform.position = Vector3.MoveTowards(transform.position.normalized, GameManager.instance.player.transform.position, speed);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float viewRange;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Visuals;

    private HealthComponent health;
    private GameObject Player;

    private bool CanAttack = true;

    void Start() {
        Player = GameManager.instance.player;
        health = GetComponent<HealthComponent>();
    }

    void Update() {
        if (Vector3.Distance(transform.position, Player.transform.position) < attackRange) {
            Attack();
            return;
        }

        if(!health.Stunned)
            if(Vector3.Distance(transform.position, Player.transform.position) < viewRange)
                Move();
    }

    private void Move() {
        var playerPos = Player.transform.position;

        Vector3 dir = (playerPos - transform.position).normalized;
        dir *= speed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;

        if (dir != Vector3.zero) {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            Visuals.transform.rotation = Quaternion.Slerp(Visuals.transform.rotation, newRotation, 10f * Time.deltaTime);
        }
    }

    private void Attack() {
        if (!CanAttack)
            return;

        var playerHealth = Player.GetComponent<HealthComponent>();
        playerHealth.TakeDamage(damage);

        var dir = (Player.transform.position - transform.position).normalized;
        playerHealth.KnockBack(dir, 10f);

        StartCoroutine(CanAttackReset());
    }

    private IEnumerator CanAttackReset() {
        CanAttack = false;
        yield return new WaitForSeconds(1f);
        CanAttack = true;
    }
}
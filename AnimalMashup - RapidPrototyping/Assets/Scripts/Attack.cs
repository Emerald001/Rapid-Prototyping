using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class Attack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;

    [SerializeField] private float directResetTime;
    [SerializeField] private float spinResetTime;

    [SerializeField] private GameObject Visuals;

    private bool CanDirectAttack = true;
    private bool CanSpinAttack = true;

    void Update() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            DirectAttack();
        }
        if (Input.GetKey(KeyCode.Mouse1)) {
            SpinAttack();
        }
    }

    private void DirectAttack() {
        if (!CanDirectAttack)
            return;

        var hitEnemies = Physics.OverlapSphere(transform.position, attackRange);

        Collider closestEnemy = null;
        foreach (Collider col in hitEnemies) {
            if (col.GetComponentInParent<IDamageble>() == null || col.CompareTag("Player"))
                continue;

            if (closestEnemy == null)
                closestEnemy = col;

            if(Vector3.Distance(transform.position, col.transform.position) < Vector3.Distance(transform.position, closestEnemy.transform.position)) {
                closestEnemy = col;
            }
        }

        if (closestEnemy == null)
            return;

        Visuals.transform.rotation = Quaternion.LookRotation(-(transform.position - closestEnemy.transform.position).normalized);

        var hc = closestEnemy.GetComponentInParent<HealthComponent>();
        var tmp = damage - Random.Range(-10f, 10f);
        hc.TakeDamage(tmp);
        hc.KnockBack((closestEnemy.transform.position - transform.position).normalized, 200f);

        StartCoroutine(CanDirectAttackReset());
    }

    private void SpinAttack() {
        if (!CanSpinAttack)
            return;

        var hitEnemies = Physics.OverlapSphere(transform.position, 2f);

        foreach(Collider col in hitEnemies) {
            if (col.GetComponentInParent<IDamageble>() == null || col.CompareTag("Player"))
                continue;

            var tmp = (damage * 1.5f) + Random.Range(-20f, 20f);

            var hc = col.GetComponentInParent<HealthComponent>();
            hc.TakeDamage(tmp);
            hc.KnockBack((col.transform.position - transform.position).normalized, 300f);
        }

        StartCoroutine(CanSpinAttackReset());
    }

    private IEnumerator CanDirectAttackReset() {
        CanDirectAttack = false;
        yield return new WaitForSeconds(directResetTime);
        CanDirectAttack = true;
    }
    private IEnumerator CanSpinAttackReset() {
        CanSpinAttack = false;
        yield return new WaitForSeconds(spinResetTime);
        CanSpinAttack = true;
    }
}

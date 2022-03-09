using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class HealthComponent : MonoBehaviour, IDamageble
{
    public float health;

    public bool Stunned { get; private set; }

    public virtual void TakeDamage(float damage) {
        health -= damage;
    }

    public void KnockBack(Vector3 direction, float strengh) {
        StartCoroutine(TimeStunned());

        var rb = transform.GetComponent<Rigidbody>();
        rb.AddForce(direction * strengh);
    }

    IEnumerator TimeStunned() {
        Stunned = true;
        yield return new WaitForSeconds(.5f);
        Stunned = false;
    }
}

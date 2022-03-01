using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class HealthComponent : MonoBehaviour, IDamageble
{
    public float Health;

    public bool Stunned;

    public void TakeDamage(float damage) {
        Health -= damage;
    }

    public void KnockBack(Vector3 direction, float strengh) {
        StartCoroutine(TimeStunned());
        var rb = transform.GetComponent<Rigidbody>();
        rb.AddForce(direction * strengh);
    }

    IEnumerator TimeStunned() {
        Stunned = true;
        yield return new WaitForSeconds(2f);
        Stunned = false;
    }
}

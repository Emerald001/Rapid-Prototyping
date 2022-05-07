using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float healAmount;

    void Heals(HealthComponent health) {
        health.HealUp(healAmount);
    }

    private void OnCollisionEnter(Collision collision) {
        Heals(collision.gameObject.GetComponent<HealthComponent>());
        Destroy(this.gameObject);
    }
}
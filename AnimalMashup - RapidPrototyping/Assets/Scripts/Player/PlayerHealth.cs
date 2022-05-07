using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthComponent {

    [HideInInspector] public PlayerManager owner;
    [HideInInspector] public bool Died;

    public override void TakeDamage(float damage) {
        health -= damage;

        if(health < 0) {
            Died = true;
        }

        EventManager<float>.RaiseEvent(EventType.OnPlayerDamaged, health);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMissile : State
{
    public GameObject Missile;

    new void OnUpdate() {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(Missile, GameManager.instance.camera.transform.position, Quaternion.identity);
        }
    }
}
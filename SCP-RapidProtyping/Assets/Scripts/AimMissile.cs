using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMissile : MonoBehaviour
{
    public GameObject Missile;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(Missile, GameManager.instance.camera.transform.position, Quaternion.identity);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMissile : MonoBehaviour, State
{
    public GameObject Missile;

    public void OnUpdate() {
        if (Input.GetButtonDown("Fire1")) {
            var tmp = GetComponentInParent<ClickScreen>().GetPos();
            Instantiate(Missile, tmp.point + new Vector3(0, Camera.main.transform.position.y * 2, 0), Quaternion.identity);
        }
    }
}
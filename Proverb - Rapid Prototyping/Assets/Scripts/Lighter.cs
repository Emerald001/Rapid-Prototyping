using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    [SerializeField] private float burnRange;
    [SerializeField] private GameObject Fire;

    [HideInInspector] public bool CanBurn;

    void Update() {
        if (!CanBurn)
            return;

        if (!Input.GetKeyDown(KeyCode.Mouse0))
            return;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, burnRange)) {
            if (hit.collider.transform.GetComponent<IBurnable>() != null) {
                var tmp = hit.collider.GetComponent<IBurnable>();

                if (tmp.IsBurning)
                    return;

                tmp.flames = Instantiate(Fire, hit.transform.position + Vector3.up * hit.collider.bounds.max.y / 2, Quaternion.identity, hit.transform);
                tmp.Light();
            }
            else if (hit.collider.transform.GetComponentInParent<IBurnable>() != null) {
                var tmp = hit.collider.GetComponentInParent<IBurnable>();

                if (tmp.IsBurning)
                    return;

                tmp.flames = Instantiate(Fire, hit.transform.position + Vector3.up * hit.collider.bounds.max.y / 2, Quaternion.identity, hit.transform);
                tmp.Light();
            }
        }
    }
}
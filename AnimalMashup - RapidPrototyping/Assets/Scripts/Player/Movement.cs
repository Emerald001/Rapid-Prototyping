using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject Visuals;
    [SerializeField] private GameObject ForwardsObject;

    [HideInInspector] public PlayerManager owner;

    public void OnUpdate() {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input != Vector2.zero) 
            Move();
    }

    private void Move() {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        Vector3 dir = (ForwardsObject.transform.right * x) + (ForwardsObject.transform.forward * z);
        dir *= speed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;

        if(dir != Vector3.zero) {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            Visuals.transform.rotation = Quaternion.Slerp(Visuals.transform.rotation, newRotation, 10f * Time.deltaTime);
        }
    }
}
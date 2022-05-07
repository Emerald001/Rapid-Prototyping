using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    
    private CharacterController CC;
    private Vector3 velocity;

    void Start() {
        CC = GetComponent<CharacterController>();
    }

    void Update() {
        if (IsGrounded()) 
            velocity.y = 0;
        else {
            velocity.y += gravity * Time.deltaTime;
            CC.Move(velocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            //no workings

        }

        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 move = transform.right * input.x + transform.forward * input.y + transform.up * (Input.GetKeyDown(KeyCode.Space).GetHashCode() * 100);

        CC.Move(move * speed * Time.deltaTime);
    }

    private bool IsGrounded() {
        if(Physics.Raycast(transform.position, Vector3.down, out var hit, .1f))
            return true;

        return false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] Transform playerBody;

    private float xRot;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        var mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;

        xRot -= mouse.y;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouse.x);
    }
}

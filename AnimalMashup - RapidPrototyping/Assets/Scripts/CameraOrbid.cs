using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbid : MonoBehaviour
{
    [SerializeField] private Transform camAnchor;

    [SerializeField] private float sensitivity;

    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;

    private float curXRot;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void LateUpdate() {
        float x = Input.GetAxis("Mouse X");
        float y = -Input.GetAxis("Mouse Y");

        camAnchor.eulerAngles += Vector3.up * x * sensitivity * Time.deltaTime;

        curXRot += y * sensitivity * Time.deltaTime;
        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);

        var clampedAngle = camAnchor.eulerAngles;
        clampedAngle.x = curXRot;
        camAnchor.eulerAngles = clampedAngle;
    }
}
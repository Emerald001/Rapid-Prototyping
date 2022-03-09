using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbid : MonoBehaviour
{
    [SerializeField] private Transform CamAnchor;
    [SerializeField] private Transform ForwardsAnchor;

    [SerializeField] private float sensitivity;

    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;

    private float curXRot;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate() {
        float x = Input.GetAxis("Mouse X");
        float y = -Input.GetAxis("Mouse Y");
        float z = Input.mouseScrollDelta.y;

        ForwardsAnchor.eulerAngles += Vector3.up * x * sensitivity * Time.deltaTime;

        curXRot += y * sensitivity * Time.deltaTime;
        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);

        var clampedAngle = CamAnchor.eulerAngles;
        clampedAngle.x = curXRot;
        CamAnchor.eulerAngles = clampedAngle;
    }
}
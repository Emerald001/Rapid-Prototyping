using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
	public float sensitivity;

	public float clampAmount;

	private float xRotation = 0f;
	private float yRotation = 0f;

    private void Start() {
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
		xRotation -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
		yRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

		xRotation = Mathf.Clamp(xRotation, -clampAmount, clampAmount);
		yRotation = Mathf.Clamp(yRotation, -clampAmount, clampAmount);

		transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ClickScreen : MonoBehaviour
{
	public Camera screenCam;

	public RaycastHit GetPos() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit)) {
			if (hit.collider.CompareTag("Screen")) {
				var localPoint = hit.textureCoord;

				Ray portalRay = screenCam.ScreenPointToRay(new Vector2(localPoint.x * screenCam.pixelWidth, localPoint.y * screenCam.pixelHeight));
				RaycastHit portalHit;

				if (Physics.Raycast(portalRay, out portalHit)) {
					return portalHit;
				}
			}
		}
		return hit;
	}
}
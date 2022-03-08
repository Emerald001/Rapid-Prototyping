using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerOnCanvas : MonoBehaviour
{
    public GameObject cursor3D;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    Canvas canvas;

    void Start() {
        m_Raycaster = GetComponentInParent<GraphicRaycaster>();
        m_EventSystem = GetComponentInParent<EventSystem>();
        canvas = GetComponentInParent<Canvas>();

        m_PointerEventData = new PointerEventData(m_EventSystem);
    }

    private void Update() {
        OnUpdate();
    }

    public void OnUpdate() {
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        m_Raycaster.Raycast(m_PointerEventData, results);

        foreach (RaycastResult result in results) {
            var rect = result.gameObject.GetComponent<RectTransform>();

            if (rect) {
                var camera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, result.screenPosition, camera, out var worldPosition)) {
                    cursor3D.transform.SetPositionAndRotation(worldPosition, result.gameObject.transform.rotation);
                    break;
                }
            }
        }
    }
}

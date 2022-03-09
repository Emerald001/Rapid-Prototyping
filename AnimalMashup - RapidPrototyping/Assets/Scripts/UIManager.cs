using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    private void OnEnable() {
        EventManager<float>.AddListener(EventType.OnPlayerDamaged, setValue);
    }

    private void OnDisable() {
        EventManager<float>.RemoveListener(EventType.OnPlayerDamaged, setValue);
    }

    public void setValue(float Value) {
        healthBar.value = Value;
    }
}
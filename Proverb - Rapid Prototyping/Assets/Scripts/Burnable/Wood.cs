using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour, IBurnable
{
    [SerializeField] private float scaler;

    private float HeatValue;
    public bool isBurning;
    public float heatValue { get { return HeatValue; } }
    public bool IsBurning { get { return isBurning; } }
    public GameObject flames { get; set; }

    public void Light() {
        HeatValue = 10f;
        isBurning = true;

        Invoke("BurnUp", 30f);
    }

    private void Update() {
        if (!isBurning)
            return;

        if (flames.transform.localScale.x < 3) {
            flames.transform.localScale += Vector3.one * scaler * Time.deltaTime;
            HeatValue += Time.deltaTime * scaler;
        }
    }

    public void BurnUp() {
        Destroy(this.gameObject);
    }
}
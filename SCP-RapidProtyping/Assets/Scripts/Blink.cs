using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Color onColor;
    public Color offColor;

    private void Start() {
        Invoke("Die", 4f);
    }

    private void Update()
    {
        var tmp = Mathf.Sin(Time.time * 10);

        if (tmp > 0) {
            GetComponent<Renderer>().material.color = onColor;
        }
        else {
            GetComponent<Renderer>().material.color = offColor;
        }
    }

    void Die() {
        Destroy(transform.parent.gameObject);
    }
}

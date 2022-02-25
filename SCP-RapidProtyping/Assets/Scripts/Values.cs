using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    public Text cValue;
    public Text aValue;
    public Text tValue;

    public int cDeadAmount;
    public int aDeadAmount;
    public float timeSinceLaunch;

    // Update is called once per frame
    void Update()
    {
        timeSinceLaunch += Time.deltaTime;

        tValue.text = Mathf.RoundToInt(timeSinceLaunch).ToString();
        cValue.text = cDeadAmount.ToString();
        aValue.text = aDeadAmount.ToString();
    }
}
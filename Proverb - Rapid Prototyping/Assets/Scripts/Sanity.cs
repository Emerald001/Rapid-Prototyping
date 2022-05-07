using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour 
{
    [SerializeField] private Slider sanityBar;
    [SerializeField] private float fireRange;

    private LoopThroughText textLoop;
    private float currentHeatValue;
    private float sanityValue;

    [HideInInspector] public bool SanityDrain;
    [HideInInspector] public bool TextChange;

    private void Start() {
        textLoop = GameManager.instace.loopThroughText;
        sanityValue = sanityBar.maxValue * .5f;
        sanityBar.value = sanityValue;
    }

    private void Update() {
        if (!SanityDrain)
            return;

        FindFires();

        float threshold = sanityBar.maxValue * .5f;
        float mappedValue = (currentHeatValue - threshold) / threshold;

        sanityValue += mappedValue * Time.deltaTime;

        if (sanityValue >= sanityBar.maxValue)
            sanityValue = sanityBar.maxValue;
        if (sanityValue <= 0) {
            sanityValue = 0;
            GetComponent<BurnYourself>().BurnMe();
        }

        sanityBar.value = sanityValue;
        
        if (TextChange) {
            if (sanityValue > sanityBar.maxValue - 10) {
                textLoop.text.text = textLoop.CautionTexts[2];
            }
            else if (sanityValue < sanityBar.minValue + 10) {
                textLoop.text.text = textLoop.CautionTexts[3];
            }
            else if (currentHeatValue > threshold) {
                textLoop.text.text = textLoop.CautionTexts[1];
            } 
            else if (currentHeatValue < 10) {
                textLoop.text.text = textLoop.CautionTexts[0];
            } 
        }
    }

    private void FindFires() {
        currentHeatValue = 0f;

        var hits = Physics.OverlapSphere(transform.position, fireRange);

        foreach (Collider hit in hits) {
            if (hit == null)
                continue;

            var tmp = hit.GetComponent<IBurnable>();
            if (tmp != null)
                currentHeatValue += tmp.heatValue;
            else {
                tmp = hit.GetComponentInParent<IBurnable>();
                if (tmp != null)
                    currentHeatValue += tmp.heatValue;
            }
        }
    }
}
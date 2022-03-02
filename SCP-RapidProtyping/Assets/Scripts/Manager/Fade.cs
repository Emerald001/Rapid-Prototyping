using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public CanvasGroup fadeinImage;

    public bool FIn;
    public bool FOut;

    private void Update() {
        if (FIn)
            In();
        if (FOut)
            Out();
    }

    private void In() {
        if (fadeinImage.alpha > 0) {
            fadeinImage.alpha -= Time.deltaTime / 2;
        }
        else
            FIn = false;
    }
    private void Out() {
        if (fadeinImage.alpha < 1) {
            fadeinImage.alpha += Time.deltaTime / 2;
        }
        else
            FOut = false;
    }
}

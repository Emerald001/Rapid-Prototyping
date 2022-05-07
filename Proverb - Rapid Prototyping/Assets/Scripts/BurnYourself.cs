using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurnYourself : MonoBehaviour
{
    [SerializeField] private GameObject Fire;

    public void BurnMe() {
        GetComponent<Sanity>().TextChange = false;
        GameManager.instace.loopThroughText.text.text = GameManager.instace.loopThroughText.CautionTexts[4];
        var tmp = GetComponent<Human>();
        tmp.flames = Instantiate(Fire, transform);
        tmp.Light();
        Invoke("Fade", 4f);
    }

    private void Fade() {
        GameManager.instace.fade.FOut = true;
        Invoke("Restart", 2f);
    }

    private void Restart() {
        GameManager.instace.Restart();
    }
}
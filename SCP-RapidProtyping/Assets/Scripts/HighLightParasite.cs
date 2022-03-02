using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighLightParasite : MonoBehaviour
{
    public Color HighlightedColor;
    public GameObject ScreenColor;
    public Button inputButton;

    public bool CanInvoke = true;

    public void TurnOnHightlight() {
        if(CanInvoke)
            StartCoroutine(HighLight());
    }

    private IEnumerator HighLight() {
        GameManager.instance.parasite.ChangeMaterial(GameManager.instance.parasite.currentHost, HighlightedColor);
        ScreenColor.SetActive(true);
        inputButton.interactable = false;

        yield return new WaitForSeconds(3f);

        GameManager.instance.parasite.ChangeMaterial(GameManager.instance.parasite.currentHost, GameManager.instance.parasite.CurrentHostMaterial);
        ScreenColor.SetActive(false);

        yield return new WaitForSeconds(10f);

        inputButton.interactable = true;
        CanInvoke = true;
    }
}

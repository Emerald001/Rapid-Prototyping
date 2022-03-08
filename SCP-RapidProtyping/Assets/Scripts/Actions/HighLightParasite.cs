using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighLightParasite : MonoBehaviour
{
    public Color HighlightedColor;
    public GameObject ScreenColor;
    public Button inputButton;

    public GameObject HighlightedDude;

    public bool CanInvoke = true;

    public void TurnOnHightlight() {
        if(CanInvoke)
            StartCoroutine(HighLight());
    }

    private IEnumerator HighLight() {
        HighlightedDude = GameManager.instance.parasite.currentHost;

        GameManager.instance.parasite.ChangeMaterial(HighlightedDude, HighlightedColor);
        ScreenColor.SetActive(true);
        inputButton.interactable = false;

        for (int i = 0; i < 30; i++) {
            if(GameManager.instance.parasite.currentHost != HighlightedDude) {
                GameManager.instance.parasite.ChangeMaterial(HighlightedDude, GameManager.instance.parasite.CurrentHostMaterial);
                HighlightedDude = GameManager.instance.parasite.currentHost;
                GameManager.instance.parasite.ChangeMaterial(HighlightedDude, HighlightedColor);
            }
            yield return new WaitForSeconds(.1f);
        }

        GameManager.instance.parasite.ChangeMaterial(HighlightedDude, GameManager.instance.parasite.CurrentHostMaterial);
        ScreenColor.SetActive(false);

        yield return new WaitForSeconds(10f);

        inputButton.interactable = true;
        CanInvoke = true;
    }
}
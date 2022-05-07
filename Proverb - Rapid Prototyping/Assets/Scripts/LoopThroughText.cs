using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopThroughText : MonoBehaviour
{
    [SerializeField] private List<string> FirstSequence = new List<string>();
    [SerializeField] private List<string> SecondSequence = new List<string>();
    public List<string> CautionTexts = new List<string>();
    [SerializeField] private Text introText;
    public Text text;

    private int index = 0;
    private bool textShow;
    private bool one = true;
    private bool two = true;

    private Sanity sanity;
    private Lighter lighter;

    private void Start() {
        sanity = GameManager.instace.player.GetComponent<Sanity>();
        lighter = GameManager.instace.player.GetComponentInChildren<Lighter>();

        NextText();
    }

    private void Update() {
        if(textShow)
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                introText.gameObject.SetActive(false);
                textShow = false;
            }

        if (GameManager.instace.burnableObjects < 1 && two) {
            index = 0;
            NextTextSecond();
            two = false;
        }
        else if (GameManager.instace.burnableObjects < GameManager.instace.MaxburnableObjects / 2 && one) {
            sanity.TextChange = false;
            text.text = CautionTexts[5];
            Invoke("ResetSanityText", 4f);
            one = false;
        }
    }

    private void ResetSanityText() {
        sanity.TextChange = true;
    }

    private void NextText() {
        text.text = FirstSequence[index];

        if(index < FirstSequence.Count - 1) {
            index++;
            Invoke("NextText", 4f);
        }
        else {
            sanity.SanityDrain = true;
            sanity.TextChange = true;
            lighter.CanBurn = true;
            Tutorial();
        }
    }
    private void NextTextSecond() {
        sanity.TextChange = false;
        lighter.CanBurn = false;

        text.text = SecondSequence[index];

        if (index < SecondSequence.Count - 1) {
            index++;
            Invoke("NextTextSecond", 4f);
        }
        else {
            GameManager.instace.player.GetComponent<BurnYourself>().BurnMe();
        }
    }

    private void Tutorial() {
        introText.gameObject.SetActive(true);
        textShow = true;
    }
}
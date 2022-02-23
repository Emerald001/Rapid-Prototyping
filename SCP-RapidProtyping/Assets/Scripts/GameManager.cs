using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    public AgentManager agentManager;
    public Parasite parasite;
    public Camera camera;

    private IEnumerator EndGame() {
        yield return new WaitForSeconds(10f);
    }
}

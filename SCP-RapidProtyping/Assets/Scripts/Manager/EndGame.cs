using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject screen;
    public GameObject ParasiteCanvas;
    public GameObject EndCanvas;
    public GameObject RetryCanvas;

    AgentManager agentManager;
    CameraMovement cameraMovement;

    void Start() {
        agentManager = GameManager.instance.agentManager;
        cameraMovement = GameManager.instance.cameraMovement;
    }

    public void StartSequence() {
        StartCoroutine(Sequence());
    }

    public IEnumerator Sequence() {


        yield return new WaitForSeconds(1f);

        ParasiteCanvas.SetActive(true);

        yield return new WaitForSeconds(3f);

        ParasiteCanvas.SetActive(false);
        EndCanvas.SetActive(true);

        for (int i = 0; i < 30; i++) {
            foreach (GameObject dude in agentManager.Crowd) {
                dude.GetComponent<Agent>().agent.speed = Random.Range(1f, 7f);
            }
            cameraMovement.gameObject.transform.position = new Vector3(Random.Range(cameraMovement.minX, cameraMovement.maxX), Random.Range(cameraMovement.minZ, cameraMovement.maxZ), Random.Range(cameraMovement.minY, cameraMovement.maxY));

            yield return new WaitForSeconds(.1f);
        }
        agentManager.Reset();

        yield return new WaitForSeconds(1f);

        screen.SetActive(false);

        yield return new WaitForSeconds(1f);

        EndCanvas.SetActive(false);
        RetryCanvas.SetActive(true);
    }

    public void Restart() {
        RetryCanvas.SetActive(false);
        screen.SetActive(true);
    }
}
using UnityEngine;

public class InvestigatorControl : MonoBehaviour, State {
    private AgentManager AgentManager;

    private int currentCase = 0;

    private void Start() {
        AgentManager = GameManager.instance.agentManager;
    }

    public void OnUpdate() {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
            return;

        var tmp = GetComponentInParent<ClickScreen>().GetPos();

        if (tmp.collider.CompareTag("Human")) {
            foreach (GameObject investigator in AgentManager.Investigators) {
                investigator.GetComponent<Investigator>().DudeToCatch = tmp.collider.gameObject;
            }
        }
        else {
            foreach (GameObject investigator in AgentManager.Investigators) {
                if (tmp.point != Vector3.zero) {
                    investigator.GetComponent<Investigator>().DudeToCatch = null;
                    investigator.GetComponent<Investigator>().targetPostion = tmp.point;
                }
            }
        }
    }
}

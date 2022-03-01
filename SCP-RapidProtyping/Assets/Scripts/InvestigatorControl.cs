using UnityEngine;

public class InvestigatorControl : State
{
    private AgentManager AgentManager;

    private int currentCase;

    new void OnUpdate() {
        switch (currentCase) {
            case 0:
                foreach(GameObject investigator in AgentManager.Investigators) {
                    var tmp = GetComponentInParent<ClickScreen>().GetPos();

                    Debug.Log(tmp);

                    if(tmp != Vector3.zero)
                        investigator.GetComponent<Investigator>().targetPostion = tmp;
                }
            break;

            case 1:
                break;
        }
    }
}

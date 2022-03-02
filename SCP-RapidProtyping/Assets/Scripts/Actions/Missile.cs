using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject Explosion;
    AgentManager agent;

    public float flightSpeed;

    private void Start() {
        agent = GameManager.instance.agentManager;
    }

    void Update() {
        transform.position += new Vector3(0, -flightSpeed, 0) * Time.deltaTime;

        if(transform.position.y < 1) {
            var tmp = agent.GetCloseEnemies(this.gameObject, 5f);

            foreach(Collider dude in tmp) {
                if (dude.CompareTag("Human")) {
                    if (dude.gameObject == GameManager.instance.parasite.currentHost)
                        GameManager.instance.parasite.CaughtOrKilled();

                    if (agent.Crowd.Contains(dude.gameObject)) {
                        agent.Crowd.Remove(dude.gameObject);
                        GameManager.instance.values.cDeadAmount++;
                    }
                    else if (agent.Investigators.Contains(dude.gameObject)) {
                        agent.Investigators.Remove(dude.gameObject);
                        GameManager.instance.values.aDeadAmount++;
                    }

                    else if (agent.DeadCrowd.Contains(dude.gameObject)) 
                        agent.DeadCrowd.Remove(dude.gameObject);

                    Destroy(dude.gameObject);
                }
            }
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
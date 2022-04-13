using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    private Bounds floorBounds;
    private Vector3 moveTo;
    private void Start() {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        floorBounds = GameObject.Find("Floor").GetComponent<Renderer>().bounds;
    }

    private void SetRandomDestination() {
        float randomXValue = Random.Range(floorBounds.min.x, floorBounds.max.x);
        float randomZValue = Random.Range(floorBounds.min.z, floorBounds.max.z);

        moveTo = new Vector3(randomXValue, this.transform.position.y, randomZValue);
        Debug.Log("Current Destination =" + moveTo);
        navMeshAgent.SetDestination(moveTo);
    }



    void Update() {
        if (!navMeshAgent.pathPending && !navMeshAgent.hasPath) {
            SetRandomDestination();
        }
    }
}

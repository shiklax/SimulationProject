using UnityEngine;
using UnityEngine.AI;
public class AgentController : MonoBehaviour {
    private NavMeshAgent navMeshAgent;
    public AgentSettings settings;
    private Bounds floorBounds;
    private Vector3 randomDestination;


    private int lifePoints;


    public Camera cam;


    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        floorBounds = GameObject.Find("Floor").GetComponent<Renderer>().bounds;
        lifePoints = settings.lifePoints;
    }
    private void SetRandomDestination() {
        float randomXValue = Random.Range(floorBounds.min.x, floorBounds.max.x);
        float randomZValue = Random.Range(floorBounds.min.z, floorBounds.max.z);
        randomDestination = new Vector3(randomXValue, this.transform.position.y, randomZValue);
        //Debug.Log(randomDestination);
        navMeshAgent.SetDestination(randomDestination);

    }





    void Update() {
        navMeshAgent.speed = settings.speed;
        navMeshAgent.angularSpeed = settings.angularSpeed;
        navMeshAgent.acceleration = settings.acceleration;



        if (!navMeshAgent.pathPending && !navMeshAgent.hasPath) {
            SetRandomDestination();
        }

    }
}


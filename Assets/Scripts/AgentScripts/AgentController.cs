using UnityEngine;
using UnityEngine.AI;
public class AgentController : MonoBehaviour {
    private NavMeshAgent navMeshAgent;
    public AgentSettings settings;
    public Camera cam;
    private GameManagerScript gameManagerScript;
    private Bounds floorBounds;
    private Vector3 randomDestination;
    private int lifePoints;
    private void Start() {
        gameManagerScript = GameObject.Find("Managers/GameManager").GetComponent<GameManagerScript>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        floorBounds = GameObject.Find("Floor").GetComponent<Renderer>().bounds;
        lifePoints = settings.lifePoints;
    }
    private void SetRandomDestination() {
        float randomXValue = Random.Range(floorBounds.min.x, floorBounds.max.x);
        float randomZValue = Random.Range(floorBounds.min.z, floorBounds.max.z);
        randomDestination = new Vector3(randomXValue, this.transform.position.y, randomZValue);
        navMeshAgent.SetDestination(randomDestination);
    }
    void Update() {
        navMeshAgent.speed = settings.speed;
        navMeshAgent.angularSpeed = settings.angularSpeed;
        navMeshAgent.acceleration = settings.acceleration;
        if (lifePoints == 0) {
            string tempName = this.gameObject.name;
            gameManagerScript.AgentsList.Remove(tempName.Substring(0, tempName.Length - 7));
            Destroy(this.gameObject);
        }
        if (!navMeshAgent.pathPending && !navMeshAgent.hasPath && lifePoints != 0) {
            SetRandomDestination();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Agent")) {

            lifePoints -= 1;
        }
    }
}


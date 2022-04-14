using UnityEngine;

public class AgentSpawnerScript : MonoBehaviour {
    private float nextSpawnTime;
    [SerializeField]
    private GameObject objectToBeSpawned;
    [SerializeField]
    [Range(2.0f, 10.0f)]
    private float spawnDelay = 2f;

    [SerializeField]
    [Range(1, 30)]
    private int spawnCap = 15;


    GameObject[] AgentsList;
    private void Update() {

        AgentsList = GameObject.FindGameObjectsWithTag("Agent");
        Debug.Log(AgentsList.Length);
        if (ShouldSpawn() && AgentsList.Length < spawnCap) {
            SpawnAgent();
        }
    }
    private void SpawnAgent() {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(objectToBeSpawned);
    }
    private bool ShouldSpawn() {
        return Time.time >= nextSpawnTime;
    }
}

using System;
using UnityEngine;

public class AgentSpawnerScript : MonoBehaviour {
    private float nextSpawnTime;
    [SerializeField]
    [HideInInspector]
    private GameObject objectToBeSpawned;
    [SerializeField]
    [Range(2f, 10.0f)]
    private float spawnDelay = 2f;
    [SerializeField]
    [Range(1, 30)]
    private int spawnCap = 15;
    [SerializeField]
    private GameManagerScript gameManagerScript;
    [HideInInspector]
    public string cloneID;

    private void Update() {
        //Debug.Log(AgentsList.Length);
        if (ShouldSpawn() && gameManagerScript.AgentsList.Count < spawnCap) {
            cloneID = Guid.NewGuid().ToString();
            SpawnAgent();
        }
    }
    private void SpawnAgent() {
        nextSpawnTime = Time.time + spawnDelay;
        objectToBeSpawned.name = cloneID;
        Instantiate(objectToBeSpawned, transform);
        gameManagerScript.AgentsList.Add(cloneID);
    }
    private bool ShouldSpawn() {
        return Time.time >= nextSpawnTime;
    }
}

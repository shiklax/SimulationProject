using UnityEngine;

public class AgentSpawnerScript : MonoBehaviour {
    public GameObject objectToBeSpawned;




    private void Start() {
        InvokeRepeating("AgentSpawning", 1f, 2f);
    }


    private void Update() {
        GameObject[] agents = GameObject.FindGameObjectsWithTag("Agent");
        Debug.Log(agents.Length);



    }

    void AgentSpawning() {
        Instantiate(objectToBeSpawned);
    }


}

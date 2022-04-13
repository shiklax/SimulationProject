using UnityEngine;

[CreateAssetMenuAttribute(fileName = "AgentData")]
public class AgentData : ScriptableObject {

    public string agentName;
    public int maxHealth = 3;
    public int damage = 1;
    public float speed = 2f;

}

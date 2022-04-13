
using UnityEngine;

[CreateAssetMenu(menuName = "AgentSettings")]
public class AgentSettings : ScriptableObject {
    public float speed;
    public float angularSpeed;
    public float acceleration;
    public int lifePoints;

}

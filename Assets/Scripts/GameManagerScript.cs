using System.Collections.Generic;
using UnityEngine;
public class GameManagerScript : MonoBehaviour {
    public List<string> AgentsList = new List<string>();
    [SerializeField]
    public float maxCameraSize = 9f;
    [SerializeField]
    public float minCameraSize = 3f;
    [SerializeField]
    public float cameraTweenTimeIn = 0.3f;
    [SerializeField]
    public float cameraTweenTimeOut = 0.5f;
    public bool ClickedOnAnObjectState;

    public string currentClickedOnAnObjectName;


    void Start() {
        ClickedOnAnObjectState = false;
    }

    private void Update() {
    }



}

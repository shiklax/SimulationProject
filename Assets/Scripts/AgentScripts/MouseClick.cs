using UnityEngine;
public class MouseClick : MonoBehaviour {
    private GameObject cameraPivot;
    private Camera cam;
    private GameManagerScript gameManagerScript;
    private ParticleSystem particles;
    public bool isObjectClicked;
    private void Start() {
        cameraPivot = GameObject.Find("Environment/CameraPivot");
        cam = GameObject.Find("Environment/CameraPivot/MainCamera").GetComponent<Camera>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        particles = GetComponentInChildren<ParticleSystem>();
        particles.Stop();
    }
    private void Update() {
        if (isObjectClicked == true) {
            cameraPivot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            if (Input.GetMouseButtonDown(1)) {
                ClickedOffState();
            }
        }
    }
    private void OnMouseDown() {
        if (gameManagerScript.ClickedOnAnObjectState == false) {
            ClickedOnState();
        }
    }
    private void OnMouseEnter() {
        if (isObjectClicked == false && gameManagerScript.ClickedOnAnObjectState == false) {
            particles.Play();
        }
    }
    private void OnMouseExit() {
        particles.Stop();
    }
    private void ClickedOnState() {
        isObjectClicked = true;
        gameManagerScript.ClickedOnAnObjectState = true;
        string tempName = this.gameObject.name;
        gameManagerScript.currentClickedOnAnObjectName = tempName.Substring(0, tempName.Length - 7);
        LeanTween.value(cam.gameObject, gameManagerScript.maxCameraSize, gameManagerScript.minCameraSize, gameManagerScript.cameraTweenTimeIn).setOnUpdate(UpdateCamOrthoSize);
    }
    private void ClickedOffState() {
        gameManagerScript.ClickedOnAnObjectState = false;
        LeanTween.move(cameraPivot, Vector3.zero, gameManagerScript.cameraTweenTimeOut);
        LeanTween.value(cam.gameObject, gameManagerScript.minCameraSize, gameManagerScript.maxCameraSize, gameManagerScript.cameraTweenTimeOut).setOnUpdate(UpdateCamOrthoSize);
        isObjectClicked = false;
    }
    private void UpdateCamOrthoSize(float value) {
        cam.orthographicSize = value;
    }
}

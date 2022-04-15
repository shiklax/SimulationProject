using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour {
    public VisualElement heartImage0;
    public VisualElement heartImage1;
    public VisualElement heartImage2;
    public VisualElement rightPopUp;
    public VisualElement backGround;
    public Label agentNameLabel;
    public GameManagerScript gameManagerScript;
    private void Start() {
        var root = GetComponent<UIDocument>().rootVisualElement;
        gameManagerScript = GameObject.Find("Managers/GameManager").GetComponent<GameManagerScript>();
        agentNameLabel = root.Q<Label>("AgentName");
        heartImage0 = root.Q<VisualElement>("HeartImage0");
        heartImage1 = root.Q<VisualElement>("HeartImage1");
        heartImage2 = root.Q<VisualElement>("HeartImage2");
        backGround = root.Q<VisualElement>("Background");
        rightPopUp = root.Q<VisualElement>("RightPopUp");
    }
    private void Update() {
        agentNameLabel.text = gameManagerScript.currentClickedOnAnObjectName;
        UiHandler();
    }
    void UiHandler() {
        if (gameManagerScript.ClickedOnAnObjectState) {
            switch (gameManagerScript.currentClickedAgentLifePoints) {
                case 3:
                    heartImage2.visible = true;
                    heartImage1.visible = true;
                    heartImage0.visible = true;
                    break;
                case 2:
                    heartImage2.visible = false;
                    heartImage1.visible = true;
                    heartImage0.visible = true;
                    break;
                case 1:
                    heartImage2.visible = false;
                    heartImage1.visible = false;
                    heartImage0.visible = true;
                    break;
                case 0:
                    heartImage2.visible = false;
                    heartImage1.visible = false;
                    heartImage0.visible = false;
                    break;
                default:
                    break;
            }
            backGround.visible = true;
        } else {
            backGround.visible = false;
            heartImage2.visible = false;
            heartImage1.visible = false;
            heartImage0.visible = false;
            backGround.visible = false;
        }
    }
}
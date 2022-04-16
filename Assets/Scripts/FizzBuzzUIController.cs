using UnityEngine;
using UnityEngine.UIElements;
public class FizzBuzzUIController : MonoBehaviour {
    public Button showFizzBuzzButton;
    public Label fizzBuzzAnswerLabel;
    public VisualElement fizzBuzzContainer;
    public VisualElement mainContainer;
    private bool isShowFizzBuzzButtonClicked = false;
    //public string fizzBuzzString;


    void Start() {
        var root = GetComponent<UIDocument>().rootVisualElement;
        showFizzBuzzButton = root.Q<Button>("ShowFizzBuzzButton");
        fizzBuzzAnswerLabel = root.Q<Label>("FizzBuzzAnswer");
        fizzBuzzContainer = root.Q<VisualElement>("FizzBuzzContainer");
        mainContainer = root.Q<VisualElement>("MainContainer");
        fizzBuzzContainer.visible = false;
        showFizzBuzzButton.clicked += ShowFizzBuzzButtonPressed;
    }



    void ShowFizzBuzzButtonPressed() {
        isShowFizzBuzzButtonClicked = !isShowFizzBuzzButtonClicked;
        if (isShowFizzBuzzButtonClicked) {
            fizzBuzzContainer.visible = true;
            fizzBuzzAnswerLabel.text = FizzBuzzAnswer();
        } else {
            fizzBuzzContainer.visible = false;
        }


    }
    string FizzBuzzAnswer() {
        string FizzBuzzString = string.Empty;
        for (int i = 1; i < 101; i++) {
            if (i % 3 == 0 & i % 5 == 0) {
                FizzBuzzString += ("MarcoPolo\n");

            } else if (i % 3 == 0) {
                FizzBuzzString += ("Marko\n");
            } else if (i % 5 == 0) {
                FizzBuzzString += ("Polo\n");
            } else {
                FizzBuzzString += (i + "\n");
            }
        }
        return FizzBuzzString;

    }
}

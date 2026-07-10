using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DialogueChoiceButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    private DialogueChoice choice;
    
    public void Setup(DialogueChoice newChoice)
    {
        choice = newChoice;

        buttonText.text = choice.choiceText;
        
        GetComponent<Button>().onClick.AddListener(Choose);
    }


    private void Choose()
    {
        DialogueManager.instance.PerformAction(choice.action);

        DialogueManager.instance.ChooseOption(choice.nextPage);

    }
}
using UnityEngine;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueTxt;

    private DialogueData currentDialogue;
    private int currentLineIndex;
    private bool isDialogueActive = false;

    void Awake()
    {
        instance = this;
    }

    public bool IsDialogueActive => isDialogueActive;

    public void StartDialogue(DialogueData dialogue)
    {
        if (dialogue == null || dialogue.lines.Length == 0) return;
        
        currentDialogue = dialogue;
        currentLineIndex = 0;
        isDialogueActive = true;

        dialoguePanel.SetActive(true);
        dialogueTxt.text = currentDialogue.lines[currentLineIndex];

    }

    public void ProgressDialogue()
    {
        if (!isDialogueActive) return;

        currentLineIndex++;

        if(currentLineIndex >= currentDialogue.lines.Length)
        {
            EndDialogue();
            return;
        }

        dialogueTxt.text = currentDialogue.lines[currentLineIndex];

    }

    private void EndDialogue()
    {
        isDialogueActive = false;

        dialoguePanel.SetActive(false);
    }

}

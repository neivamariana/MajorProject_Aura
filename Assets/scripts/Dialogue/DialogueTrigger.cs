using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueData currentDialogue;

    public void Interact()
    {
        if (DialogueManager.instance != null)
        {
        Debug.Log("dialogue trigger is being called hurrayyy");
        DialogueManager.instance.StartDialogue(currentDialogue);}
        

                
    }

    public void ChangeDialogue(DialogueData newDialogue)
    {
        currentDialogue = newDialogue;

        Debug.Log("new dialogue has entered the chat");
    }
}

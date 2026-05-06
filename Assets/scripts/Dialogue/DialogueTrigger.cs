using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueData dialogue;

    public void Interact()
    {
        if (DialogueManager.instance != null)
        {
            Debug.Log("dialogue trigger is being called hurrayyy");
            DialogueManager.instance.StartDialogue(dialogue);
        }
    }
}

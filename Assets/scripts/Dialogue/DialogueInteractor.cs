/*using UnityEngine;

I'm making this script which is also an interactor because I was getting confused 
because when I was tying to change the interactor to add the dialogue system i thought
it would be confusing to have all of it in one place
thanks for coming to my Ted talk :D


public class DialogueInteractor : MonoBehaviour
{
   public void HandleDialogueInteract(IInteractable interactable)
    {
        if (DialogueManager.instance == null) return;

        if(DialogueManager.instance.IsDialogueActive)
        {
            DialogueManager.instance.ProgressDialogue();
        }
        else
        {
            interactable?.Interact();
        }
    }
}

This didn't work
*/


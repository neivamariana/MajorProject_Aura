using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactDistance = 10f;
    [SerializeField] private GameObject interactPrompt;
    [SerializeField] private PlayerInputHandler inputHandler;


    private IInteractable currentInteractable;
    //private DialogueInteractor dialogueInteractor;



    void Update()
    {



        CheckForInteractable();

        if (inputHandler != null && inputHandler.InteractTriggered)
        {
            //dialogue  
            if (DialogueManager.instance != null && DialogueManager.instance.IsDialogueActive)
                    {
                        DialogueManager.instance.ProgressDialogue();
                    }
            //book 
            else if (Book.IsBookOpen)
            {
                Debug.Log("BOOK IDK MAN");
                FindFirstObjectByType<Book>()?.Interact();
            }
            //Normal interactions
            else if (currentInteractable != null)
            {
                Debug.Log("Interacting with object #we did it guys");
                currentInteractable.Interact();
            }

            inputHandler.ResetInteract();
        }
    }

        void CheckForInteractable()
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.SphereCast(ray, 0.5f, out RaycastHit hit, interactDistance))
            {
                IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

                if (interactable != null)
                {
                    //Debug.Log("I SPY WITH MY LITTLE EYE A...." + hit.collider.name);


                    currentInteractable = interactable;
                    interactPrompt.SetActive(true);
                    return;
                }
            }

            currentInteractable = null;
            interactPrompt.SetActive(false);
        }



}

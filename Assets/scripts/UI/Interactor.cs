using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactDistance = 10f;
    [SerializeField] private GameObject interactPrompt;
    [SerializeField] private PlayerInputHandler inputHandler;


    private IInteractable currentInteractable;

    void Update()
    {

        if (Time.timeScale == 0f) return;

        CheckForInteractable();

        if (inputHandler != null && inputHandler.InteractTriggered)
        {
            if (currentInteractable != null)
            {
                Debug.Log("interacting with object YIPEE");
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
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    currentInteractable = interactable;
                    interactPrompt.SetActive(true);
                    return;
                }
            }

            currentInteractable = null;
            interactPrompt.SetActive(false);
        }

   

}
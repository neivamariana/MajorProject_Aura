using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private PlayerInputHandler inputHandler;

    private bool isPaused;



    private void Start()
    {
        menuCanvas.SetActive(false);

    }

    private void Update()
    {
        if(inputHandler.PauseTriggered)
        {
            TogglePause();
            inputHandler.ResetPause();

        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        menuCanvas.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;

        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;

    }

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Book : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject bookUI;

    private bool isOpen = false;
    public static bool IsBookOpen;

    public void Interact()
    {

        isOpen = !isOpen;
        IsBookOpen = isOpen;
        bookUI.SetActive(isOpen);

        Time.timeScale = isOpen ? 0f : 1f;

        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isOpen;
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour, IInteractable
{
    [SerializeField] private string sceneName;

    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}

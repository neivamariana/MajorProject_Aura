using UnityEngine;

public class NPCDialogue : MonoBehaviour, IInteractable
{
    [Header("Dialogue")]
    public DialogueData dialogueData;
    [Header("Quest")]
    public QuestData questData;

    [Header("Current Conversation")]
    public ConversationType currentConversation = ConversationType.Intro;


    public void Interact()
    {
        Debug.Log("NPC wants to talk :D");

        DialogueManager.instance.StartDialogue(dialogueData, (int)currentConversation, this);
    }


    public void ChangeConversation(ConversationType newConversation)
    {
        currentConversation = newConversation;

        Debug.Log("NPC conversation changed!! :D");
    }
}